using FluentValidation;
using System.Globalization;
using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Application.GUI.View;

using Proxies;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Data.Store;

public abstract class ViewValidatorBase<TData> : AbstractValidator<TData> where TData : IViewData
{
    protected static readonly string[] SupportedLanguages;

    protected readonly IServicer _servicer;

    static ViewValidatorBase()
    {
        SupportedLanguages = CultureInfo
            .GetCultures(CultureTypes.NeutralCultures)
            .Select(c => c.TwoLetterISOLanguageName)
            .Distinct()
            .ToArray();
    }

    public ViewValidatorBase(IServicer servicer)
    {
        _servicer = servicer;
    }

    protected void ValidateRequired(params string[] propertyNames)
    {
        foreach (string propertyName in propertyNames)
        {
            RuleFor(a => a.Model.Proxy[propertyName])
                .NotEmpty()
                .WithMessage(a => $"{propertyName} is required!");
        }
    }

    protected void ValidateLanguage(params string[] propertyNames)
    {
        foreach (string propertyName in propertyNames)
        {
            RuleFor(a => a.Model.Proxy[propertyName])
                .Must(SupportedLanguages.Contains)
                .WithMessage("Language must conform to ISO 639-1.");
        }
    }

    protected void ValidateNotEqual(object item, params string[] propertyNames)
    {
        foreach (string propertyName in propertyNames)
        {
            RuleFor(e => e.Model.Proxy[propertyName])
                .NotEqual(item)
                .WithMessage($"{propertyName} is not equal: {item}");
        }
    }

    protected void ValidateEqual(object item, params string[] propertyNames)
    {
        foreach (string propertyName in propertyNames)
        {
            RuleFor(e => e.Model.Proxy[propertyName])
                .Equal(item)
                .WithMessage($"{propertyName} is equal: {item}");
        }
    }

    protected void ValidateLength(int min, int max, params string[] propertyNames)
    {
        foreach (string propertyName in propertyNames)
        {
            RuleFor(a => a.Model.Proxy[propertyName].ToString())
                .MinimumLength(min)
                .WithMessage($"{propertyName} minimum text rubricCount: {max} characters")
                .MaximumLength(max)
                .WithMessage($"{propertyName} maximum text rubricCount: {max} characters");
        }
    }

    protected void ValidateEnum(params string[] propertyNames)
    {
        foreach (string propertyName in propertyNames)
        {
            RuleFor(e => e.Model.Proxy[propertyName])
                .IsInEnum()
                .WithMessage($"Incorrect {propertyName} number");
        }
    }

    protected void ValidateEmail(params string[] emailPropertyNames)
    {
        foreach (string emailPropertyName in emailPropertyNames)
        {
            RuleFor(a => a.Model.Proxy[emailPropertyName].ToString())
                .EmailAddress()
                .When(a => !string.IsNullOrEmpty(a.Model.Proxy[emailPropertyName].ToString()))
                .WithMessage($"Invalid {emailPropertyName} address.");
        }
    }

    protected void ValidateExist<TStore, TDto>(LogicOperand operand, params string[] propertyNames)
        where TDto : class, IOrigin, IInnerProxy
        where TStore : IDataServiceStore
    {
        RuleFor(e => e)
            .MustAsync(
                async (cmd, cancel) =>
                {
                    return await _servicer
                        .Open<TStore, TDto>()
                        .Exist(buildPredicate<TDto>(cmd.Model, operand, propertyNames));
                }
            )
            .WithMessage($"{typeof(TDto).Name} already exists");
    }

    protected void ValidateNotExist<TStore, TDto>(
        LogicOperand operand,
        params string[] propertyNames
    )
        where TDto : class, IOrigin, IInnerProxy
        where TStore : IDataServiceStore
    {
        RuleFor(e => e)
            .MustAsync(
                async (cmd, cancel) =>
                {
                    return await _servicer
                        .Open<TStore, TDto>()
                        .NotExist(buildPredicate<TDto>(cmd.Model, operand, propertyNames));
                }
            )
            .WithMessage($"{typeof(TDto).Name} does not exists");
    }

    private Expression<Func<TDto, bool>> buildPredicate<TDto>(
        IInnerProxy dataInput,
        LogicOperand operand,
        params string[] propertyNames
    ) where TDto : class, IOrigin, IInnerProxy
    {
        Expression<Func<TDto, bool>> predicate =
            operand == LogicOperand.And ? predicate = e => true : predicate = e => false;
        foreach (var item in propertyNames)
        {
            predicate =
                operand == LogicOperand.And
                    ? predicate.And(e => e.Proxy[item] == dataInput.Proxy[item])
                    : predicate.Or(e => e.Proxy[item] == dataInput.Proxy[item]);
        }
        return predicate;
    }
}
