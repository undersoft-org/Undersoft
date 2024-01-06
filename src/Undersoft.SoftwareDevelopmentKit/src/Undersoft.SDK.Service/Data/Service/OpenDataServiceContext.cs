using Microsoft.OData.Client;
using Microsoft.OData.Edm;
using Undersoft.SDK.Security.Identity;

namespace Undersoft.SDK.Service.Data.Service
{
    public partial class OpenDataServiceContext : DataServiceContext
    {
        private ISecurityString _securityString;        

        public OpenDataServiceContext(Uri serviceUri) : base(serviceUri)
        {
            MergeOption = MergeOption.AppendOnly;
            HttpRequestTransportMode = HttpRequestTransportMode.HttpClient;
            IgnoreResourceNotFoundException = true;
            KeyComparisonGeneratesFilterQuery = false;
            DisableInstanceAnnotationMaterialization = true;
            EnableWritingODataAnnotationWithoutPrefix = false;
            AddAndUpdateResponsePreference = DataServiceResponsePreference.NoContent;
            EntityParameterSendOption = EntityParameterSendOption.SendOnlySetProperties;
            SaveChangesDefaultOptions = SaveChangesOptions.BatchWithSingleChangeset;
            ResolveName = (t) => this.GetMappedName(t);
            ResolveType = (n) => this.GetMappedType(n);
            SendingRequest2 += RequestAuthorization;
        }

        private void RequestAuthorization(object sender, SendingRequest2EventArgs e)
        {
            if(_securityString != null)
                e.RequestMessage.SetHeader("Authorization", _securityString.Encoded);
        }

        public async Task<IEdmModel> CreateServiceModel()
        {
            var edmModel = await AddServiceModel();
            Format.LoadServiceModel = GetServiceModel;
            Format.UseJson();
            return edmModel;
        }

        public async Task<IEdmModel> AddServiceModel()
        {
            Type t = GetType();
            if (!OpenDataServiceRegistry.EdmModels.TryGet(t, out IEdmModel edmModel))
                OpenDataServiceRegistry.EdmModels.Add(t, edmModel = OnModelCreating(await this.GetEdmModel()));
            return edmModel;
        }

        public IEdmModel GetServiceModel()
        {
            Type t = GetType();
            OpenDataServiceRegistry.EdmModels.TryGet(t, out IEdmModel edmModel);
            return edmModel;
        }

        protected virtual IEdmModel OnModelCreating(IEdmModel builder)
        {
            return builder;
        }

        public override DataServiceQuery<T> CreateQuery<T>(string resourcePath, bool isComposable)
        {
            return base.CreateQuery<T>(resourcePath, isComposable);
        }

        public void SetSecurityString(string securityString)
        {
            var strings = securityString.Split(" ");
            string prefix = strings.Length > 0 ? strings[0] : null;
            var token = strings.LastOrDefault();
            _securityString = new SecurityString(token,  prefix);
        }

    }
}