﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SDK.Service.Infrastructure.Store.Relation;

using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Infrastructure.Store;

public class RelatedSetToSet<TLeft, TRight>
    where TLeft : class, IOrigin, IInnerProxy
    where TRight : class, IOrigin, IInnerProxy
{
    private readonly string RELATION_TABLE_NAME;
    private readonly string LEFT_TABLE_NAME = typeof(TLeft).Name + "s";
    private readonly string RIGHT_TABLE_NAME = typeof(TRight).Name + "s";
    private readonly string LEFT_NAME = typeof(TLeft).Name + "s";
    private readonly string RIGHT_NAME =
        typeof(TRight).Name != typeof(TLeft).Name
            ? typeof(TRight).Name.Replace(typeof(TLeft).Name, "") + "s"
            : typeof(TRight).Name + "s";
    private readonly string LEFT_SCHEMA = null;
    private readonly string RIGHT_SCHEMA = null;

    private readonly ExpandSite _expandSite;
    private readonly ModelBuilder _modelBuilder;
    private readonly EntityTypeBuilder<TLeft> _firstBuilder;
    private readonly EntityTypeBuilder<TRight> _secondBuilder;
    private readonly EntityTypeBuilder<RelatedLink<TLeft, TRight>> _relationBuilder;

    public RelatedSetToSet(
        ModelBuilder modelBuilder,
        ExpandSite expandSite = ExpandSite.None,
        string dbSchema = null
    ) : this(modelBuilder, null, null, null, null, expandSite, dbSchema, dbSchema) { }

    public RelatedSetToSet(
        ModelBuilder modelBuilder,
        string leftName,
        string rightName,
        ExpandSite expandSite = ExpandSite.None,
        string dbSchema = null
    )
        : this(
            modelBuilder,
            leftName,
            null,
            rightName,
            null,
            expandSite,
            dbSchema,
            dbSchema
        )
    { }

    public RelatedSetToSet(
        ModelBuilder modelBuilder,
        string leftName,
        string leftTableName,
        string rightName,
        string rightTableName,
        ExpandSite expandSite = ExpandSite.None,
        string parentSchema = null,
        string childSchema = null
    )
    {
        _modelBuilder = modelBuilder;
        _firstBuilder = _modelBuilder.Entity<TLeft>();
        _secondBuilder = _modelBuilder.Entity<TRight>();
        _relationBuilder = _modelBuilder.Entity<RelatedLink<TLeft, TRight>>();
        _expandSite = expandSite;

        if (leftTableName != null)
            LEFT_TABLE_NAME = leftTableName;
        else if (leftName != null)
            LEFT_TABLE_NAME = leftName;
        if (rightTableName != null)
            RIGHT_TABLE_NAME = leftTableName;
        else if (rightName != null)
            RIGHT_TABLE_NAME = rightName;
        if (leftName != null)
            LEFT_NAME = leftName;
        if (rightName != null)
            RIGHT_NAME = rightName;
        if (parentSchema != null)
            LEFT_SCHEMA = parentSchema;
        if (childSchema != null)
            RIGHT_SCHEMA = childSchema;

        RELATION_TABLE_NAME = LEFT_TABLE_NAME + "And" + RIGHT_TABLE_NAME;
    }

    public ModelBuilder Configure(bool autoinclude = false)
    {
        _relationBuilder.ToTable(RELATION_TABLE_NAME, DataStoreSchema.RelationSchema);

        _firstBuilder
            .HasMany<TRight>(RIGHT_NAME)
            .WithMany(LEFT_NAME)
            .UsingEntity<RelatedLink<TLeft, TRight>>(
                j => j.HasOne(a => a.RightEntity).WithMany(),

                j => j.HasOne(a => a.LeftEntity).WithMany(),

                j =>
                {
                    j.HasKey(k => new { k.LeftEntityId, k.RightEntityId });
                }
            );

        if (_expandSite != ExpandSite.None)
        {
            if ((_expandSite & (ExpandSite.OnRight | ExpandSite.WithMany)) > 0)
            {
                if (!autoinclude)
                {
                    _firstBuilder.Navigation(RIGHT_NAME);
                }
                else
                {
                    _firstBuilder.Navigation(RIGHT_NAME).AutoInclude();
                }
            }
            if ((_expandSite & (ExpandSite.OnLeft | ExpandSite.WithMany)) > 0)
            {
                if (!autoinclude)
                {
                    _secondBuilder.Navigation(LEFT_NAME);
                }
                else
                {
                    _secondBuilder.Navigation(LEFT_NAME).AutoInclude();
                }
            }
        }

        return _modelBuilder;
    }
}
