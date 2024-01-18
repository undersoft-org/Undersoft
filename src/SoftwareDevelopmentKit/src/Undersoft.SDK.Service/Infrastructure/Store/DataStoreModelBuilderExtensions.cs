using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SDK.Service.Infrastructure.Store;

using Data.Entity;
using System.Linq.Expressions;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;

public abstract class EntityTypeMapping<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class
{
    protected ModelBuilder modelBuilder;

    public virtual void SetBuilder(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }

    public abstract void Configure(EntityTypeBuilder<TEntity> builder);
}

public static class DataStoreModelBuilderExtensions
{
    public static ModelBuilder ApplyIdentity<TContext>(this ModelBuilder builder)
    {
        foreach (var type in builder.Model.GetEntityTypes().ToList())
        {
            var clr = type.ClrType;
            if (clr != null && clr.GetInterfaces().Contains(typeof(IEntity)))
            {
                var model = builder.Entity(clr);
                model.HasKey("Id");
                model.HasIndex("Index").IsUnique();
                model.Property("CodeNo").HasMaxLength(32).IsConcurrencyToken(true);
            }
        }
        return builder;
    }

    public static ModelBuilder ApplyMapping<TEntity>(
        this ModelBuilder builder,
        EntityTypeMapping<TEntity> entityBuilder
    ) where TEntity : class
    {
        entityBuilder.SetBuilder(builder);
        builder.ApplyConfiguration(entityBuilder);
        return builder;
    }

    public static ModelBuilder ApplyIdentifiers(this ModelBuilder builder, Type type)
    {
        return new IdentifiersMapping(type, builder).Configure();
    }

    public static ModelBuilder ApplyIdentifiers<TEntity>(this ModelBuilder builder)
        where TEntity : class, IDataObject
    {
        return new IdentifiersMapping<TEntity>(builder).Configure();
    }

    public static ModelBuilder RelateSetToSet<TLeft, TRight>(
        this ModelBuilder builder,
        ExpandSite expandSite = ExpandSite.None,
        bool autoinclude = false,
        string dbSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedSetToSet<TLeft, TRight>(builder, expandSite, dbSchema).Configure(
            autoinclude
        );
    }

    public static ModelBuilder RelateSetToSet<TLeft, TRight>(
        this ModelBuilder builder,
        Expression<Func<TRight, object>> leftMember,
        Expression<Func<TLeft, object>> rightMember,
        ExpandSite expandSite = ExpandSite.None,
        bool autoinclude = false,
        string parentSchema = null,
        string childSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedSetToSet<TLeft, TRight>(
            builder,
            LinqExtension.GetMemberName(leftMember),
            LinqExtension.GetMemberName(rightMember),
            expandSite
        ).Configure(autoinclude);
    }

    public static ModelBuilder RelateSetToSet<TLeft, TRight>(
        this ModelBuilder builder,
        Expression<Func<TRight, object>> leftMember,
        string LeftTableName,
        Expression<Func<TLeft, object>> rightMember,
        string rightTableName,
        ExpandSite expandSite = ExpandSite.None,
        bool autoinclude = false,
        string parentSchema = null,
        string childSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedSetToSet<TLeft, TRight>(
            builder,
            LinqExtension.GetMemberName(leftMember),
            LeftTableName,
            LinqExtension.GetMemberName(rightMember),
            rightTableName,
            expandSite,
            parentSchema,
            childSchema
        ).Configure(autoinclude);
    }

    public static ModelBuilder RelateSetToSet<TLeft, TRight>(
        this ModelBuilder builder,
        string leftName,
        string rightName,
        ExpandSite expandSite = ExpandSite.None,
        bool autoinclude = false,
        string dbSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedSetToSet<TLeft, TRight>(
            builder,
            leftName,
            rightName,
            expandSite,
            dbSchema
        ).Configure(autoinclude);
    }

    public static ModelBuilder RelateSetToSet<TLeft, TRight>(
        this ModelBuilder builder,
        string leftName,
        string leftTableName,
        string rightName,
        string rightTableName,
        ExpandSite expandSite = ExpandSite.None,
        bool autoinclude = false,
        string parentSchema = null,
        string childSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedSetToSet<TLeft, TRight>(
            builder,
            leftName,
            leftTableName,
            rightName,
            rightTableName,
            expandSite,
            parentSchema,
            childSchema
        ).Configure(autoinclude);
    }

    public static ModelBuilder RelateSetToRemoteSet<TLeft, TRight>(
        this ModelBuilder builder,
        ExpandSite expandSite = ExpandSite.None,
        string dbSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedSetToRemoteSet<TLeft, TRight>(builder, expandSite, dbSchema).Configure();
    }

    public static ModelBuilder RelateSetToRemoteSet<TLeft, TRight>(
        this ModelBuilder builder,
        string leftName,
        string rightName,
        ExpandSite expandSite = ExpandSite.None,
        string dbSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedSetToRemoteSet<TLeft, TRight>(
            builder,
            leftName,
            rightName,
            expandSite,
            dbSchema
        ).Configure();
    }

    public static ModelBuilder RelateSetToRemoteSet<TLeft, TRight>(
        this ModelBuilder builder,
        Expression<Func<TLeft, object>> leftMember,
        ExpandSite expandSite = ExpandSite.None,
        string dbSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedSetToRemoteSet<TLeft, TRight>(
            builder,
            LinqExtension.GetMemberName(leftMember),
            expandSite,
            dbSchema
        ).Configure();
    }

    public static ModelBuilder RelateSetToRemoteSet<TLeft, TRight>(
        this ModelBuilder builder,
        Expression<Func<TLeft, object>> leftMember,
        string leftName,
        ExpandSite expandSite = ExpandSite.None,
        string dbSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedSetToRemoteSet<TLeft, TRight>(
            builder,
            LinqExtension.GetMemberName(leftMember),
            leftName,
            expandSite,
            dbSchema
        ).Configure();
    }

    public static ModelBuilder RelateSetToRemoteSet<TLeft, TRight>(
        this ModelBuilder builder,
        string leftName,
        string leftTableName,
        string rightName,
        string rightTableName,
        ExpandSite expandSite = ExpandSite.None,
        string parentSchema = null,
        string childSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedSetToRemoteSet<TLeft, TRight>(
            builder,
            leftName,
            leftTableName,
            expandSite,
            parentSchema,
            childSchema
        ).Configure();
    }

    public static ModelBuilder RelateOneToSet<TLeft, TRight>(
        this ModelBuilder builder,
        ExpandSite expandSite = ExpandSite.None,
        bool autoinclude = false,
        string dbSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedOneToSet<TLeft, TRight>(builder, expandSite).Configure(autoinclude);
    }

    public static ModelBuilder RelateOneToSet<TLeft, TRight>(
        this ModelBuilder builder,
        string leftName,
        string rightName,
        ExpandSite expandSite = ExpandSite.None,
        bool autoinclude = false,
        string dbSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedOneToSet<TLeft, TRight>(
            builder,
            leftName,
            rightName,
            expandSite,
            dbSchema
        ).Configure(autoinclude);
    }

    public static ModelBuilder RelateOneToSet<TLeft, TRight>(
        this ModelBuilder builder,
        Expression<Func<TRight, object>> leftMember,
        Expression<Func<TLeft, object>> rightMember,
        ExpandSite expandSite = ExpandSite.None,
        bool autoinclude = false,
        string dbSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedOneToSet<TLeft, TRight>(
            builder,
            LinqExtension.GetMemberName(leftMember),
            LinqExtension.GetMemberName(rightMember),
            expandSite,
            dbSchema
        ).Configure(autoinclude);
    }

    public static ModelBuilder RelateOneToSet<TLeft, TRight>(
        this ModelBuilder builder,
        string leftName,
        string leftTableName,
        string rightName,
        string rightTableName,
        ExpandSite expandSite = ExpandSite.None,
        bool autoinclude = false,
        string parentSchema = null,
        string childSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedOneToSet<TLeft, TRight>(
            builder,
            leftName,
            leftTableName,
            rightName,
            rightTableName,
            expandSite
        ).Configure(autoinclude);
    }

    public static ModelBuilder RelateOneToOne<TLeft, TRight>(
        this ModelBuilder builder,
        ExpandSite expandSite = ExpandSite.None,
        bool autoinclude = false,
        string dbSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedOneToOne<TLeft, TRight>(builder, expandSite, dbSchema).Configure(
            autoinclude
        );
    }

    public static ModelBuilder RelateOneToOne<TLeft, TRight>(
        this ModelBuilder builder,
        string leftName,
        string rightName,
        ExpandSite expandSite = ExpandSite.None,
        bool autoinclude = false,
        string dbSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedOneToOne<TLeft, TRight>(
            builder,
            leftName,
            rightName,
            expandSite,
            dbSchema
        ).Configure(autoinclude);
    }

    public static ModelBuilder RelateOneToOne<TLeft, TRight>(
        this ModelBuilder builder,
        Expression<Func<TRight, object>> leftMember,
        Expression<Func<TLeft, object>> rightMember,
        ExpandSite expandSite = ExpandSite.None,
        bool autoinclude = false,
        string dbSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedOneToOne<TLeft, TRight>(
            builder,
            LinqExtension.GetMemberName(leftMember),
            LinqExtension.GetMemberName(rightMember),
            expandSite,
            dbSchema
        ).Configure(autoinclude);
    }

    public static ModelBuilder RelateOneToOne<TLeft, TRight>(
        this ModelBuilder builder,
        string leftName,
        string leftTableName,
        string rightName,
        string rightTableName,
        ExpandSite expandSite = ExpandSite.None,
        bool autoinclude = false,
        string parentSchema = null,
        string childSchema = null
    )
        where TLeft : class, IDataObject
        where TRight : class, IDataObject
    {
        return new RelatedOneToOne<TLeft, TRight>(
            builder,
            leftName,
            leftTableName,
            rightName,
            rightTableName,
            expandSite,
            parentSchema,
            childSchema
        ).Configure(autoinclude);
    }
}
