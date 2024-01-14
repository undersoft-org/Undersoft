﻿using FluentValidation;
using System.Collections;
using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Server.Operation.Remote.Command.Validator;

using Undersoft.SDK.Service.Server.Operation.Remote.Command;
using Undersoft.SDK.Service.Server.Operation.Command;

using Undersoft.SDK.Service.Server.Operation.Remote.Validator;
using Undersoft.SDK.Service.Infrastructure.Store;

public class RemoteCommandValidator<TModel> : RemoteCommandValidatorBase<RemoteCommand<TModel>> where TModel : class, IDataObject
{
    public RemoteCommandValidator(IServicer ultimateService) : base(ultimateService) { }

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

    protected void ValidationScope(CommandMode commandMode, Action actions)
    {
        WhenAsync(
            (cmd, cancel) =>
                Task.Run(
                    () =>
                    {
                        return ((int)cmd.CommandMode & (int)commandMode) > 0;
                    },
                    cancel
                ),
            actions
        );
    }

    protected void ValidateRequired(params Expression<Func<RemoteCommand<TModel>, object>>[] members)
    {
        foreach (var member in members)
        {
            RuleFor(member)
                .NotEmpty()
                .WithMessage($"{member.Parameters.FirstOrDefault().Name} is required!");
        }
    }

    protected void ValidateEmail(params Expression<Func<RemoteCommand<TModel>, string>>[] members)
    {
        foreach (var member in members)
        {
            RuleFor(member).EmailAddress().WithMessage($"Invalid email address.");
        }
    }

    protected void ValidateLength(
        int min,
        int max,
        params Expression<Func<RemoteCommand<TModel>, string>>[] members
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
        params Expression<Func<RemoteCommand<TModel>, ICollection>>[] members
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

    protected void ValidateEnum(params Expression<Func<RemoteCommand<TModel>, string>>[] members)
    {
        foreach (var member in members)
        {
            RuleFor(member).IsInEnum().WithMessage($"Incorrect enum value");
        }
    }

    protected void ValidateNotEqual(
        object item,
        params Expression<Func<RemoteCommand<TModel>, object>>[] members
    )
    {
        foreach (var member in members)
        {
            RuleFor(member).NotEqual(item).WithMessage($"value not equal: {item}");
        }
    }

    protected void ValidateEqual(
        object item,
        params Expression<Func<RemoteCommand<TModel>, object>>[] members
    )
    {
        foreach (var member in members)
        {
            RuleFor(member).Equal(item).WithMessage($"value equal: {item}");
        }
    }

    protected void ValidateLanguage(params Expression<Func<RemoteCommand<TModel>, object>>[] members)
    {
        foreach (var member in members)
        {
            RuleFor(member)
                .Must(SupportedLanguages.Contains)
                .WithMessage("Agreement language must conform to ISO 639-1.");
        }
    }

    protected void ValidateExist<TStore, TEntity>(
        Func<TModel, Expression<Func<TEntity, bool>>> command
    )
        where TEntity : class, IDataObject
        where TStore : IDataServerStore
    {
        var _repository = uservice.Use<TStore, TEntity>();

        RuleFor(e => e.Model)
            .MustAsync(
                async (cmd, cancel) =>
                {
                    return await _repository.Exist(command.Invoke((TModel)cmd));
                }
            )
            .WithMessage($"{typeof(TEntity).Name} does not exists");
    }

    protected void ValidateNotExist<TStore, TEntity>(
        Func<TModel, Expression<Func<TEntity, bool>>> command
    )
        where TEntity : class, IDataObject
        where TStore : IDataServerStore
    {
        var _reposiotry = uservice.Use<TStore, TEntity>();

        RuleFor(e => e.Model)
            .MustAsync(
                async (cmd, cancel) =>
                {
                    return await _reposiotry.NotExist(command.Invoke((TModel)cmd));
                }
            )
            .WithMessage($"{typeof(TEntity).Name} already exists");
    }
}
