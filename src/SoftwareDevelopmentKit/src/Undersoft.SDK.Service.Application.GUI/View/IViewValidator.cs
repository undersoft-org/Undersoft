using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Undersoft.SDK.Service.Application.GUI.View
{
    public interface IViewValidator
    {
        Task<ValidationResult> ValidateAsync();
        Task<ValidationResult> ValidateAsync(string propertyName);
    }
}