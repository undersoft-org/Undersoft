using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Undersoft.SDK.Service.Application.GUI.View.Generic.Validator
{
    public partial class GenericValidator<TValidator, TModel> : FluentComponentBase, IViewValidator where TValidator : class, IValidator<IViewData<TModel>> where TModel : class, IOrigin, IInnerProxy
    {
        [CascadingParameter]
        private EditContext FormContext { get; set; } = default!;

        [CascadingParameter]
        private IViewData<TModel> Content { get; set; } = default!;

        private ValidationMessageStore ValidationMessageStore = default!;

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            EditContext previousEditContext = FormContext;

            var previousContent = Content;

            await base.SetParametersAsync(parameters);

            if (previousContent != Content)
                Content.Validator = this;

            if (FormContext != previousEditContext)
                FormContextChanged();
        }

        void FormContextChanged()
        {
            ValidationMessageStore = new ValidationMessageStore(FormContext);

            FormContext.OnFieldChanged += FieldChanged;
        }

        public async Task<ValidationResult> ValidateAsync()
        {
            ValidationMessageStore.Clear();
            Content.ClearErrors();

            var context = new ValidationContext<IViewData<TModel>>(Content);
            var result = await Validator.ValidateAsync(context);

            if (result.Errors.Any())
            {
                result.Errors.GroupBy(e => e.PropertyName).ForEach(r =>
                {
                    var rubric = Content.Rubrics[r.Key.Split(".").LastOrDefault()];
                    if (rubric != null)
                    {
                        rubric.Errors.Clear();
                        r.ForEach(e =>
                        {
                            if (rubric.Errors.TryAdd(e.ErrorMessage))
                                ValidationMessageStore.Add(rubric.FieldIdentifier, e.ErrorMessage);
                        });
                    }
                });
            }
            Content.RenderView();
            FormContext.NotifyValidationStateChanged();
            return result;
        }

        public async Task<ValidationResult> ValidateAsync(string propertyName)
        {
            IViewRubric rubric = Content.Rubrics[propertyName];

            ValidationMessageStore.Clear(rubric.FieldIdentifier);
            rubric.Errors.Clear();

            var context = new ValidationContext<IViewData<TModel>>(Content);
            var result = await Validator.ValidateAsync(context);
            var _result = new ValidationResult(result.Errors.Where(e => rubric.RubricName.Equals(e.PropertyName.Split(".").LastOrDefault())));

            if (_result.Errors.Any())
            {
                _result.Errors.ForEach(e =>
                {
                    if (rubric.Errors.TryAdd(e.ErrorMessage))
                        ValidationMessageStore.Add(rubric.FieldIdentifier, e.ErrorMessage);
                });
            }
            rubric.View.RenderView();
            FormContext.NotifyValidationStateChanged();
            return _result;
        }

        async void FieldChanged(object? sender, FieldChangedEventArgs args)
        {
            ValidationMessageStore.Clear(args.FieldIdentifier);
            dynamic field = args.FieldIdentifier.Model;
            IViewRubric rubric = field.Rubric;
            rubric.Errors.Clear();

            var context = new ValidationContext<IViewData<TModel>>(Content);
            var result = await Validator.ValidateAsync(context);
            var _result = new ValidationResult(result.Errors.Where(e => rubric.RubricName.Equals(e.PropertyName.Split(".").LastOrDefault())));

            if (_result.Errors.Any())
            {
                _result.Errors.ForEach(e =>
                {
                    if (rubric.Errors.TryAdd(e.ErrorMessage))
                        ValidationMessageStore.Add(args.FieldIdentifier, e.ErrorMessage);
                });
            }
            rubric.View.RenderView();
            FormContext.NotifyValidationStateChanged();
        }
    }
}