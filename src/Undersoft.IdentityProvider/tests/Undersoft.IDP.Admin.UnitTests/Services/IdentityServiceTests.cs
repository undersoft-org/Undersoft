﻿using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moq;
using NicmanGroup.AuditLogging.Services;
using Undersoft.IDP.Admin.BusinessLogic.Identity.Dtos.Identity;
using Undersoft.IDP.Admin.BusinessLogic.Identity.Mappers;
using Undersoft.IDP.Admin.BusinessLogic.Identity.Resources;
using Undersoft.IDP.Admin.BusinessLogic.Identity.Services;
using Undersoft.IDP.Admin.BusinessLogic.Identity.Services.Interfaces;
using Undersoft.IDP.Admin.EntityFramework.Identity.Repositories;
using Undersoft.IDP.Admin.EntityFramework.Identity.Repositories.Interfaces;
using Undersoft.IDP.Admin.EntityFramework.Shared.DbContexts;
using Undersoft.IDP.Admin.EntityFramework.Shared.Entities.Identity;
using Undersoft.IDP.Admin.UnitTests.Mocks;
using Xunit;

namespace Undersoft.IDP.Admin.UnitTests.Services
{
    public class IdentityServiceTests
    {
        public IdentityServiceTests()
        {
            var databaseName = Guid.NewGuid().ToString();

            _dbContextOptions = new DbContextOptionsBuilder<AdminIdentityDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;

            _storeOptions = new ConfigurationStoreOptions();
            _operationalStore = new OperationalStoreOptions();
        }

        private readonly DbContextOptions<AdminIdentityDbContext> _dbContextOptions;
        private readonly ConfigurationStoreOptions _storeOptions;
        private readonly OperationalStoreOptions _operationalStore;

        private IIdentityRepository<UserIdentity, UserIdentityRole, long,
            UserIdentityUserClaim, UserIdentityUserRole, UserIdentityUserLogin, UserIdentityRoleClaim,
            UserIdentityUserToken> GetIdentityRepository(AdminIdentityDbContext dbContext,
            UserManager<UserIdentity> userManager,
            RoleManager<UserIdentityRole> roleManager,
            IMapper mapper)
        {
            return new IdentityRepository<AdminIdentityDbContext, UserIdentity, UserIdentityRole, long,
                UserIdentityUserClaim, UserIdentityUserRole, UserIdentityUserLogin, UserIdentityRoleClaim,
                UserIdentityUserToken>(dbContext, userManager, roleManager, mapper);
        }

        private IIdentityService<UserDto<long>, RoleDto<long>, UserIdentity,
            UserIdentityRole, long,
            UserIdentityUserClaim, UserIdentityUserRole, UserIdentityUserLogin, UserIdentityRoleClaim,
            UserIdentityUserToken,
            UsersDto<UserDto<long>, long>, RolesDto<RoleDto<long>, long>, UserRolesDto<RoleDto<long>, long>,
            UserClaimsDto<UserClaimDto<long>, long>, UserProviderDto<long>, UserProvidersDto<UserProviderDto<long>, long>, UserChangePasswordDto<long>,
            RoleClaimsDto<RoleClaimDto<long>, long>, UserClaimDto<long>, RoleClaimDto<long>> GetIdentityService(IIdentityRepository<UserIdentity, UserIdentityRole, long, UserIdentityUserClaim, UserIdentityUserRole, UserIdentityUserLogin, UserIdentityRoleClaim, UserIdentityUserToken> identityRepository,
            IIdentityServiceResources identityServiceResources,
            IMapper mapper, IAuditEventLogger auditEventLogger)
        {
            return new IdentityService<UserDto<long>, RoleDto<long>, UserIdentity,
                UserIdentityRole, long,
                UserIdentityUserClaim, UserIdentityUserRole, UserIdentityUserLogin, UserIdentityRoleClaim,
                UserIdentityUserToken,
                UsersDto<UserDto<long>, long>, RolesDto<RoleDto<long>, long>, UserRolesDto<RoleDto<long>, long>,
                UserClaimsDto<UserClaimDto<long>, long>, UserProviderDto<long>, UserProvidersDto<UserProviderDto<long>, long>, UserChangePasswordDto<long>,
                RoleClaimsDto<RoleClaimDto<long>, long>, UserClaimDto<long>, RoleClaimDto<long>>(identityRepository, identityServiceResources, mapper, auditEventLogger);
        }

        private IMapper GetMapper()
        {
            return new MapperConfiguration(cfg => cfg.AddProfile<IdentityMapperProfile<UserDto<long>, RoleDto<long>, UserIdentity, UserIdentityRole, long,
                        UserIdentityUserClaim, UserIdentityUserRole, UserIdentityUserLogin, UserIdentityRoleClaim,
                        UserIdentityUserToken,
                        UsersDto<UserDto<long>, long>, RolesDto<RoleDto<long>, long>, UserRolesDto<RoleDto<long>, long>,
                        UserClaimsDto<UserClaimDto<long>, long>, UserProviderDto<long>, UserProvidersDto<UserProviderDto<long>, long>,
                        RoleClaimsDto<RoleClaimDto<long>, long>, UserClaimDto<long>, RoleClaimDto<long>>>())
                .CreateMapper();
        }

        private UserManager<UserIdentity> GetTestUserManager(AdminIdentityDbContext context)
        {
            var testUserManager = IdentityMock.TestUserManager(new UserStore<UserIdentity, UserIdentityRole, AdminIdentityDbContext, long, UserIdentityUserClaim, UserIdentityUserRole, UserIdentityUserLogin, UserIdentityUserToken, UserIdentityRoleClaim>(context, new IdentityErrorDescriber()));

            return testUserManager;
        }

        private RoleManager<UserIdentityRole> GetTestRoleManager(AdminIdentityDbContext context)
        {
            var testRoleManager = IdentityMock.TestRoleManager(new RoleStore<UserIdentityRole, AdminIdentityDbContext, long, UserIdentityUserRole, UserIdentityRoleClaim>(context, new IdentityErrorDescriber()));

            return testRoleManager;
        }

        private IIdentityService<UserDto<long>, RoleDto<long>, UserIdentity,
            UserIdentityRole, long,
            UserIdentityUserClaim, UserIdentityUserRole, UserIdentityUserLogin, UserIdentityRoleClaim,
            UserIdentityUserToken,
            UsersDto<UserDto<long>, long>, RolesDto<RoleDto<long>, long>,
            UserRolesDto<RoleDto<long>, long>,
            UserClaimsDto<UserClaimDto<long>, long>, UserProviderDto<long>, UserProvidersDto<UserProviderDto<long>, long>, UserChangePasswordDto<long>,
            RoleClaimsDto<RoleClaimDto<long>, long>, UserClaimDto<long>, RoleClaimDto<long>> GetIdentityService(AdminIdentityDbContext context)
        {
            var testUserManager = GetTestUserManager(context);
            var testRoleManager = GetTestRoleManager(context);
            var mapper = GetMapper();

            var identityRepository = GetIdentityRepository(context, testUserManager, testRoleManager, mapper);
            var localizerIdentityResource = new IdentityServiceResources();

            var auditLoggerMock = new Mock<IAuditEventLogger>();
            var auditLogger = auditLoggerMock.Object;

            var identityService = GetIdentityService(identityRepository, localizerIdentityResource, mapper, auditLogger);

            return identityService;
        }

        [Fact]
        public async Task AddUserAsync()
        {
            using (var context = new AdminIdentityDbContext(_dbContextOptions))
            {
                var identityService = GetIdentityService(context);

                //Generate random new user
                var userDto = IdentityDtoMock<long>.GenerateRandomUser();

                await identityService.CreateUserAsync(userDto);

                //Get new user
                var user = await context.Users.Where(x => x.UserName == userDto.UserName).SingleOrDefaultAsync();
                userDto.Id = user.Id;

                var newUserDto = await identityService.GetUserAsync(userDto.Id);

                //Assert new user
                userDto.Should().BeEquivalentTo(newUserDto);
            }
        }

        [Fact]
        public async Task DeleteUserProviderAsync()
        {
            using (var context = new AdminIdentityDbContext(_dbContextOptions))
            {
                var identityService = GetIdentityService(context);

                //Generate random new user
                var userDto = IdentityDtoMock<long>.GenerateRandomUser();

                await identityService.CreateUserAsync(userDto);

                //Get new user
                var user = await context.Users.Where(x => x.UserName == userDto.UserName).SingleOrDefaultAsync();
                userDto.Id = user.Id;

                var newUserDto = await identityService.GetUserAsync(userDto.Id);

                //Assert new user
                userDto.Should().BeEquivalentTo(newUserDto);

                var userProvider = IdentityMock.GenerateRandomUserProviders(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                    newUserDto.Id);

                //Add new user login
                await context.UserLogins.AddAsync(userProvider);
                await context.SaveChangesAsync();

                //Get added user provider
                var addedUserProvider = await context.UserLogins.Where(x => x.ProviderKey == userProvider.ProviderKey && x.LoginProvider == userProvider.LoginProvider).SingleOrDefaultAsync();
                addedUserProvider.Should().NotBeNull();

                var userProviderDto = IdentityDtoMock<long>.GenerateRandomUserProviders(userProvider.ProviderKey, userProvider.LoginProvider,
                    userProvider.UserId);

                await identityService.DeleteUserProvidersAsync(userProviderDto);

                //Get deleted user provider
                var deletedUserProvider = await context.UserLogins.Where(x => x.ProviderKey == userProvider.ProviderKey && x.LoginProvider == userProvider.LoginProvider).SingleOrDefaultAsync();
                deletedUserProvider.Should().BeNull();
            }
        }

        [Fact]
        public async Task AddUserRoleAsync()
        {
            using (var context = new AdminIdentityDbContext(_dbContextOptions))
            {
                var identityService = GetIdentityService(context);

                //Generate random new user
                var userDto = IdentityDtoMock<long>.GenerateRandomUser();

                await identityService.CreateUserAsync(userDto);

                //Get new user
                var user = await context.Users.Where(x => x.UserName == userDto.UserName).SingleOrDefaultAsync();
                userDto.Id = user.Id;

                var newUserDto = await identityService.GetUserAsync(userDto.Id);

                //Assert new user
                userDto.Should().BeEquivalentTo(newUserDto);

                //Generate random new role
                var roleDto = IdentityDtoMock<long>.GenerateRandomRole();

                await identityService.CreateRoleAsync(roleDto);

                //Get new role
                var role = await context.Roles.Where(x => x.Name == roleDto.Name).SingleOrDefaultAsync();
                roleDto.Id = role.Id;

                var newRoleDto = await identityService.GetRoleAsync(roleDto.Id.ToString());

                //Assert new role
                roleDto.Should().BeEquivalentTo(newRoleDto);

                var userRoleDto = IdentityDtoMock<long>.GenerateRandomUserRole<RoleDto<long>>(roleDto.Id, userDto.Id);

                await identityService.CreateUserRoleAsync(userRoleDto);

                //Get new role
                var userRole = await context.UserRoles.Where(x => x.RoleId == roleDto.Id && x.UserId == userDto.Id).SingleOrDefaultAsync();

                userRole.Should().NotBeNull();
            }
        }

        [Fact]
        public async Task DeleteUserRoleAsync()
        {
            using (var context = new AdminIdentityDbContext(_dbContextOptions))
            {
                var identityService = GetIdentityService(context);

                //Generate random new user
                var userDto = IdentityDtoMock<long>.GenerateRandomUser();

                await identityService.CreateUserAsync(userDto);

                //Get new user
                var user = await context.Users.Where(x => x.UserName == userDto.UserName).SingleOrDefaultAsync();
                userDto.Id = user.Id;

                var newUserDto = await identityService.GetUserAsync(userDto.Id);

                //Assert new user
                userDto.Should().BeEquivalentTo(newUserDto);

                //Generate random new role
                var roleDto = IdentityDtoMock<long>.GenerateRandomRole();

                await identityService.CreateRoleAsync(roleDto);

                //Get new role
                var role = await context.Roles.Where(x => x.Name == roleDto.Name).SingleOrDefaultAsync();
                roleDto.Id = role.Id;

                var newRoleDto = await identityService.GetRoleAsync(roleDto.Id.ToString());

                //Assert new role
                roleDto.Should().BeEquivalentTo(newRoleDto);

                var userRoleDto = IdentityDtoMock<long>.GenerateRandomUserRole<RoleDto<long>>(roleDto.Id, userDto.Id);

                await identityService.CreateUserRoleAsync(userRoleDto);

                //Get new role
                var userRole = await context.UserRoles.Where(x => x.RoleId == roleDto.Id && x.UserId == userDto.Id).SingleOrDefaultAsync();
                userRole.Should().NotBeNull();

                await identityService.DeleteUserRoleAsync(userRoleDto);

                //Get deleted role
                var userRoleDeleted = await context.UserRoles.Where(x => x.RoleId == roleDto.Id && x.UserId == userDto.Id).SingleOrDefaultAsync();
                userRoleDeleted.Should().BeNull();
            }
        }

        [Fact]
        public async Task AddUserClaimAsync()
        {
            using (var context = new AdminIdentityDbContext(_dbContextOptions))
            {
                var identityService = GetIdentityService(context);

                //Generate random new user
                var userDto = IdentityDtoMock<long>.GenerateRandomUser();

                await identityService.CreateUserAsync(userDto);

                //Get new user
                var user = await context.Users.Where(x => x.UserName == userDto.UserName).SingleOrDefaultAsync();
                userDto.Id = user.Id;

                var newUserDto = await identityService.GetUserAsync(userDto.Id);

                //Assert new user
                userDto.Should().BeEquivalentTo(newUserDto);

                //Generate random new user claim
                var userClaimDto = IdentityDtoMock<long>.GenerateRandomUserClaim(0, userDto.Id);

                await identityService.CreateUserClaimsAsync(userClaimDto);

                //Get new user claim
                var claim = await context.UserClaims.Where(x => x.ClaimType == userClaimDto.ClaimType && x.ClaimValue == userClaimDto.ClaimValue).SingleOrDefaultAsync();
                userClaimDto.ClaimId = claim.Id;

                var newUserClaim = await identityService.GetUserClaimAsync(userDto.Id.ToString(), claim.Id);

                //Assert new user claim
                userClaimDto.Should().BeEquivalentTo(newUserClaim);
            }
        }

        [Fact]
        public async Task DeleteUserClaimAsync()
        {
            using (var context = new AdminIdentityDbContext(_dbContextOptions))
            {
                var identityService = GetIdentityService(context);

                //Generate random new user
                var userDto = IdentityDtoMock<long>.GenerateRandomUser();

                await identityService.CreateUserAsync(userDto);

                //Get new user
                var user = await context.Users.Where(x => x.UserName == userDto.UserName).SingleOrDefaultAsync();
                userDto.Id = user.Id;

                var newUserDto = await identityService.GetUserAsync(userDto.Id);

                //Assert new user
                userDto.Should().BeEquivalentTo(newUserDto);

                //Generate random new user claim
                var userClaimDto = IdentityDtoMock<long>.GenerateRandomUserClaim(0, userDto.Id);

                await identityService.CreateUserClaimsAsync(userClaimDto);

                //Get new user claim
                var claim = await context.UserClaims.Where(x => x.ClaimType == userClaimDto.ClaimType && x.ClaimValue == userClaimDto.ClaimValue).SingleOrDefaultAsync();
                userClaimDto.ClaimId = claim.Id;

                var newUserClaim = await identityService.GetUserClaimAsync(userDto.Id.ToString(), claim.Id);

                //Assert new user claim
                userClaimDto.Should().BeEquivalentTo(newUserClaim);

                await identityService.DeleteUserClaimAsync(userClaimDto);

                //Get deleted user claim
                var deletedClaim = await context.UserClaims.Where(x => x.ClaimType == userClaimDto.ClaimType && x.ClaimValue == userClaimDto.ClaimValue).SingleOrDefaultAsync();
                deletedClaim.Should().BeNull();
            }
        }

        [Fact]
        public async Task UpdateUserAsync()
        {
            using (var context = new AdminIdentityDbContext(_dbContextOptions))
            {
                var identityService = GetIdentityService(context);

                //Generate random new user
                var userDto = IdentityDtoMock<long>.GenerateRandomUser();

                await identityService.CreateUserAsync(userDto);

                //Get new user
                var user = await context.Users.Where(x => x.UserName == userDto.UserName).SingleOrDefaultAsync();
                userDto.Id = user.Id;

                var newUserDto = await identityService.GetUserAsync(userDto.Id);

                //Assert new user
                userDto.Should().BeEquivalentTo(newUserDto);

                //Detached the added item
                context.Entry(user).State = EntityState.Detached;

                //Generete new user with added item id
                var userDtoForUpdate = IdentityDtoMock<long>.GenerateRandomUser(user.Id);

                //Update user
                await identityService.UpdateUserAsync(userDtoForUpdate);

                var updatedUser = await identityService.GetUserAsync(userDtoForUpdate.Id);

                //Assert updated user
                userDtoForUpdate.Should().BeEquivalentTo(updatedUser);
            }
        }

        [Fact]
        public async Task DeleteUserAsync()
        {
            using (var context = new AdminIdentityDbContext(_dbContextOptions))
            {
                var identityService = GetIdentityService(context);

                //Generate random new user
                var userDto = IdentityDtoMock<long>.GenerateRandomUser();

                await identityService.CreateUserAsync(userDto);

                //Get new user
                var user = await context.Users.Where(x => x.UserName == userDto.UserName).SingleOrDefaultAsync();
                userDto.Id = user.Id;

                var newUserDto = await identityService.GetUserAsync(userDto.Id);

                //Assert new user
                userDto.Should().BeEquivalentTo(newUserDto);

                //Remove user
                await identityService.DeleteUserAsync(newUserDto.Id.ToString(), newUserDto);

                //Try Get Removed user
                var removeUser = await context.Users.Where(x => x.Id == user.Id)
                    .SingleOrDefaultAsync();

                //Assert removed user
                removeUser.Should().BeNull();
            }
        }

        [Fact]
        public async Task AddRoleAsync()
        {
            using (var context = new AdminIdentityDbContext(_dbContextOptions))
            {
                var identityService = GetIdentityService(context);

                //Generate random new role
                var roleDto = IdentityDtoMock<long>.GenerateRandomRole();

                await identityService.CreateRoleAsync(roleDto);

                //Get new role
                var role = await context.Roles.Where(x => x.Name == roleDto.Name).SingleOrDefaultAsync();
                roleDto.Id = role.Id;

                var newRoleDto = await identityService.GetRoleAsync(roleDto.Id.ToString());

                //Assert new role
                roleDto.Should().BeEquivalentTo(newRoleDto);
            }
        }

        [Fact]
        public async Task UpdateRoleAsync()
        {
            using (var context = new AdminIdentityDbContext(_dbContextOptions))
            {
                var identityService = GetIdentityService(context);

                //Generate random new role
                var roleDto = IdentityDtoMock<long>.GenerateRandomRole();

                await identityService.CreateRoleAsync(roleDto);

                //Get new role
                var role = await context.Roles.Where(x => x.Name == roleDto.Name).SingleOrDefaultAsync();
                roleDto.Id = role.Id;

                var newRoleDto = await identityService.GetRoleAsync(roleDto.Id.ToString());

                //Assert new role
                roleDto.Should().BeEquivalentTo(newRoleDto);

                //Detached the added item
                context.Entry(role).State = EntityState.Detached;

                //Generete new role with added item id
                var roleDtoForUpdate = IdentityDtoMock<long>.GenerateRandomRole(role.Id);

                //Update role
                await identityService.UpdateRoleAsync(roleDtoForUpdate);

                var updatedRole = await identityService.GetRoleAsync(roleDtoForUpdate.Id.ToString());

                //Assert updated role
                roleDtoForUpdate.Should().BeEquivalentTo(updatedRole);
            }
        }

        [Fact]
        public async Task DeleteRoleAsync()
        {
            using (var context = new AdminIdentityDbContext(_dbContextOptions))
            {
                var identityService = GetIdentityService(context);

                //Generate random new role
                var roleDto = IdentityDtoMock<long>.GenerateRandomRole();

                await identityService.CreateRoleAsync(roleDto);

                //Get new role
                var role = await context.Roles.Where(x => x.Name == roleDto.Name).SingleOrDefaultAsync();
                roleDto.Id = role.Id;

                var newRoleDto = await identityService.GetRoleAsync(roleDto.Id.ToString());

                //Assert new role
                roleDto.Should().BeEquivalentTo(newRoleDto);

                //Remove role
                await identityService.DeleteRoleAsync(newRoleDto);

                //Try Get Removed role
                var removeRole = await context.Roles.Where(x => x.Id == role.Id)
                    .SingleOrDefaultAsync();

                //Assert removed role
                removeRole.Should().BeNull();
            }
        }

        [Fact]
        public async Task AddRoleClaimAsync()
        {
            using (var context = new AdminIdentityDbContext(_dbContextOptions))
            {
                var identityService = GetIdentityService(context);

                //Generate random new role
                var roleDto = IdentityDtoMock<long>.GenerateRandomRole();

                await identityService.CreateRoleAsync(roleDto);

                //Get new role
                var role = await context.Roles.Where(x => x.Name == roleDto.Name).SingleOrDefaultAsync();
                roleDto.Id = role.Id;

                var newRoleDto = await identityService.GetRoleAsync(roleDto.Id.ToString());

                //Assert new role
                roleDto.Should().BeEquivalentTo(newRoleDto);

                //Generate random new role claim
                var roleClaimDto = IdentityDtoMock<long>.GenerateRandomRoleClaim(0, roleDto.Id);

                await identityService.CreateRoleClaimsAsync(roleClaimDto);

                //Get new role claim
                var roleClaim = await context.RoleClaims.Where(x => x.ClaimType == roleClaimDto.ClaimType && x.ClaimValue == roleClaimDto.ClaimValue).SingleOrDefaultAsync();
                roleClaimDto.ClaimId = roleClaim.Id;

                var newRoleClaimDto = await identityService.GetRoleClaimAsync(roleDto.Id.ToString(), roleClaimDto.ClaimId);

                //Assert new role
                roleClaimDto.Should().BeEquivalentTo(newRoleClaimDto, options => options.Excluding(o => o.RoleName));
            }
        }

        [Fact]
        public async Task RemoveRoleClaimAsync()
        {
            using (var context = new AdminIdentityDbContext(_dbContextOptions))
            {
                var identityService = GetIdentityService(context);

                //Generate random new role
                var roleDto = IdentityDtoMock<long>.GenerateRandomRole();

                await identityService.CreateRoleAsync(roleDto);

                //Get new role
                var role = await context.Roles.Where(x => x.Name == roleDto.Name).SingleOrDefaultAsync();
                roleDto.Id = role.Id;

                var newRoleDto = await identityService.GetRoleAsync(roleDto.Id.ToString());

                //Assert new role
                roleDto.Should().BeEquivalentTo(newRoleDto);

                //Generate random new role claim
                var roleClaimDto = IdentityDtoMock<long>.GenerateRandomRoleClaim(0, roleDto.Id);

                await identityService.CreateRoleClaimsAsync(roleClaimDto);

                //Get new role claim
                var roleClaim = await context.RoleClaims.Where(x => x.ClaimType == roleClaimDto.ClaimType && x.ClaimValue == roleClaimDto.ClaimValue).SingleOrDefaultAsync();
                roleClaimDto.ClaimId = roleClaim.Id;

                var newRoleClaimDto = await identityService.GetRoleClaimAsync(roleDto.Id.ToString(), roleClaimDto.ClaimId);

                //Assert new role
                roleClaimDto.Should().BeEquivalentTo(newRoleClaimDto, options => options.Excluding(o => o.RoleName));

                await identityService.DeleteRoleClaimAsync(roleClaimDto);

                var roleClaimToDelete = await context.RoleClaims.Where(x => x.ClaimType == roleClaimDto.ClaimType && x.ClaimValue == roleClaimDto.ClaimValue).SingleOrDefaultAsync();

                //Assert removed role claim
                roleClaimToDelete.Should().BeNull();
            }
        }
    }
}
