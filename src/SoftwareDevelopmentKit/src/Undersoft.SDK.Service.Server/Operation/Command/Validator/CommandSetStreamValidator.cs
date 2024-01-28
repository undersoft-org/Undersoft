﻿namespace Undersoft.SDK.Service.Server.Operation.Command.Validator;



public class CommandSetStreamValidator<TDto> : CommandSetValidator<TDto> where TDto : class, IOrigin, IInnerProxy
{
    public CommandSetStreamValidator(IServicer servicer) : base(servicer) { }
}