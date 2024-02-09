using FluentValidation;
using System.Collections;
using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Application.GUI.Generic;

using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Operation.Command;

public class GenericValidator<TModel> : GenericValidatorBase<IGenericData<TModel>>, IValidator<IGenericData<TModel>> where TModel : class, IOrigin, IInnerProxy
{
    public GenericValidator(IServicer servicer) : base(servicer) { }

    protected void ValidationScope<T>(CommandMode commandMode, Action actions)
    {
        ValidationScope(typeof(T), commandMode, actions);
    }

    protected void ValidationScope(Type type, CommandMode commandMode, Action actions)
    {
        WhenAsync(
            (cmd, cancel) =>
                Task.Run(
                    () =>
                    {
                        return ((int)cmd.CommandMode & (int)commandMode) > 0
                            && GetType().UnderlyingSystemType.IsAssignableTo(type);
                    },
                    cancel
                ),
            actions
        );
    }

    protected void ValidationScope(CommandMode GenericDataMode, Action actions)
    {
        WhenAsync(
            (cmd, cancel) =>
                Task.Run(
                    () =>
                    {
                        return ((int)cmd.CommandMode & (int)GenericDataMode) > 0;
                    },
                    cancel
                ),
            actions
        );
    }

    protected void ValidateRequired(params Expression<Func<IGenericData<TModel>, object>>[] members)
    {
        foreach (var member in members)
        {
            RuleFor(member)
                .NotEmpty()
                .WithMessage($"{member.GetMemberName()} is required!");
        }
    }

    protected void ValidateEmail(params Expression<Func<IGenericData<TModel>, string>>[] members)
    {
        foreach (var member in members)
        {
            RuleFor(member).EmailAddress().WithMessage($"Invalid email address.");
        }
    }

    protected void ValidateLength(
        int min,
        int max,
        params Expression<Func<IGenericData<TModel>, string>>[] members
    )
    {
        foreach (var member in members)
        {
            RuleFor(member)
                .MinimumLength(min)
                .WithMessage($"minimum text rubricCount: {max} characters")
                .MaximumLength(max)
                .WithMessage($"maximum text rubricCount: {max} characters");
        }
    }

    protected void ValidateCount(
        int min,
        int max,
        params Expression<Func<IGenericData<TModel>, ICollection>>[] members
    )
    {
        foreach (var member in members)
        {
            RuleFor(member)
                .Must(a => a.Count >= min)
                .WithMessage($"Items count below minimum quantity")
                .Must(a => a.Count <= max)
                .WithMessage($"Items count above maximum quantity");
        }
    }

    protected void ValidateEnum(params Expression<Func<IGenericData<TModel>, string>>[] members)
    {
        foreach (var member in members)
        {
            RuleFor(member).IsInEnum().WithMessage($"Incorrect enum value");
        }
    }

    protected void ValidateNotEqual(
        object item,
        params Expression<Func<IGenericData<TModel>, object>>[] members
    )
    {
        foreach (var member in members)
        {
            RuleFor(member).NotEqual(item).WithMessage($"{member.GetMemberName()} not equal: {item}");
        }
    }

    protected void ValidateNotEqual(
        Expression<Func<IGenericData<TModel>, object>> first,
        Expression<Func<IGenericData<TModel>, object>> second
    )
    {
        RuleFor(first).NotEqual(second).WithMessage($"{first.GetMemberName()} not equal {second.GetMemberName()}");
    }

    protected void ValidateEqual(
        object item,
        params Expression<Func<IGenericData<TModel>, object>>[] members
    )
    {
        foreach (var member in members)
        {
            RuleFor(member).Equal(item).WithMessage($"{member.GetMemberName()} equal: {item}");
        }
    }

    protected void ValidateEqual(
        Expression<Func<IGenericData<TModel>, object>> first,
        Expression<Func<IGenericData<TModel>, object>> second
    )
    {
        RuleFor(first).Equal(second).WithMessage($"{first.GetMemberName()} equal {second.GetMemberName()}");
    }

    protected void ValidateLanguage(params Expression<Func<IGenericData<TModel>, object>>[] members)
    {
        foreach (var member in members)
        {
            RuleFor(member)
                .Must(SupportedLanguages.Contains)
                .WithMessage($"{member.GetMemberName()} language must conform to ISO 639-1.");
        }
    }

    protected void ValidateExist<TStore, TDto>(
        Func<TModel, Expression<Func<TDto, bool>>> dataExpression
    )
        where TDto : class, IOrigin, IInnerProxy
        where TStore : IDataServiceStore
    {
        var _repository = _servicer.Open<TStore, TDto>();

        RuleFor(e => e.Data)
            .MustAsync(
                async (cmd, cancel) =>
                {
                    return await _repository.Exist(dataExpression.Invoke(cmd));
                }
            )
            .WithMessage($"{typeof(TDto).Name} does not exists");
    }

    protected void ValidateNotExist<TStore, TDto>(
        Func<TModel, Expression<Func<TDto, bool>>> dataExpression
    )
        where TDto : class, IOrigin, IInnerProxy
        where TStore : IDataServiceStore
    {
        var _repository = _servicer.Open<TStore, TDto>();

        RuleFor(e => e.Data)
            .MustAsync(
                async (cmd, cancel) =>
                {
                    return await _repository.NotExist(dataExpression.Invoke(cmd));
                }
            )
            .WithMessage($"{typeof(TDto).Name} already exists");
    }
}
