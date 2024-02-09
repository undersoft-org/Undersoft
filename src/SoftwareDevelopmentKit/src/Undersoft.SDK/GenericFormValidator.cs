//using FluentValidation;
//using FluentValidation.Results;
//using Microsoft.AspNetCore.Components.Forms;
//using Undersoft.SDK.Instant.Proxies;
//using ValidationResult = FluentValidation.Results.ValidationResult;

//namespace Undersoft.SDK.Service.Application.GUI.Generic;

//public class GenericFormValidator<TValidator, TModel> : ComponentBase
//    where TValidator : class, IValidator<IGenericData<TModel>>
//    where TModel : class, IOrigin, IInnerProxy
//{
//    public GenericFormValidator() { }

//    public GenericFormValidator(IServicer servicer)
//    {
//        _servicer = servicer;
//        var service = _servicer.GetService<TValidator>();
//        if (service != null)
//            Validator = (IValidator<IGenericData<TModel>>)service;
//    }

//    [Inject]
//    private IServicer _servicer { get; set; } = default!;

//    [CascadingParameter]
//    private EditContext EditContext { get; set; } = default!;

//    [Inject]
//    private IValidator<IGenericData<TModel>> Validator { get; set; } = default!;

//    private ValidationMessageStore ValidationMessageStore = default!;

//    public override async Task SetParametersAsync(ParameterView parameters)
//    {
//        EditContext previousEditContext = EditContext;
//        Type? previousValidatorType = null;
//        if (Validator != null)
//        {
//            previousValidatorType = Validator.GetType();
//        }
//        await base.SetParametersAsync(parameters);

//        Type currentValidationType = typeof(TValidator);

//        if (currentValidationType != previousValidatorType)
//            ValidatorTypeChanged();

//        if (EditContext != previousEditContext)
//            EditContextChanged();
//    }

//    void ValidatorTypeChanged()
//    {
//        var service = _servicer.GetService<TValidator>();
//        if (service != null)
//            Validator = (IValidator<IGenericData<TModel>>)service;
//    }

//    void EditContextChanged()
//    {
//        System.Diagnostics.Debug.WriteLine("EditContext has changed");

//        ValidationMessageStore = new ValidationMessageStore(EditContext);

//        System.Diagnostics.Debug.WriteLine("New ValidationMessageStore created");

//        HookUpEditContextEvents();
//    }

//    private void HookUpEditContextEvents()
//    {
//        EditContext.OnValidationRequested += ValidationRequested;

//        EditContext.OnFieldChanged += FieldChanged;

//        System.Diagnostics.Debug.WriteLine(
//            "Hooked up EditContext events (OnValidationRequested and OnFieldChanged)"
//        );
//    }

//    async void ValidationRequested(object? sender, ValidationRequestedEventArgs args)
//    {
//        System.Diagnostics.Debug.WriteLine(
//            "OnValidationRequested triggered: Validating whole object"
//        );

//        ValidationMessageStore.Clear();

//        var validationContext = new ValidationContext<IGenericData<TModel>>(
//            (IGenericData<TModel>)EditContext.Model
//        );

//        ValidationResult result = await Validator.ValidateAsync(validationContext);

//        AddValidationResult(EditContext.Model, result);
//    }

//    async void FieldChanged(object? sender, FieldChangedEventArgs args)
//    {
//        System.Diagnostics.Debug.WriteLine(
//            $"OnFieldChanged triggered: Validating a single property named {args.FieldIdentifier.FieldName}"
//                + $" on class {args.FieldIdentifier.Model.GetType().Name}"
//        );

//        FieldIdentifier fieldIdentifier = args.FieldIdentifier;

//        ValidationMessageStore.Clear(fieldIdentifier);

//        var propertiesToValidate = new string[] { fieldIdentifier.FieldName };
//        var fluentValidationContext = new ValidationContext<IGenericData<TModel>>(
//            instanceToValidate: (IGenericData<TModel>)fieldIdentifier.Model,
//            propertyChain: new FluentValidation.Internal.PropertyChain(),
//            validatorSelector: new FluentValidation.Internal.MemberNameValidatorSelector(
//                propertiesToValidate
//            )
//        );

//        ValidationResult result = await Validator.ValidateAsync(fluentValidationContext);

//        AddValidationResult(fieldIdentifier.Model, result);
//    }

//    void AddValidationResult(object model, ValidationResult validationResult)
//    {
//        foreach (ValidationFailure error in validationResult.Errors)
//        {
//            var fieldIdentifier = new FieldIdentifier(model, error.PropertyName);
//            ValidationMessageStore.Add(fieldIdentifier, error.ErrorMessage);
//        }
//        EditContext.NotifyValidationStateChanged();
//    }
//}
