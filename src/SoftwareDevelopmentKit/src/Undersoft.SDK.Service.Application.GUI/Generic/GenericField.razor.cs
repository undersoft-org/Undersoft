using Microsoft.AspNetCore.Components.Forms;
using Microsoft.FluentUI.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Service.Application.GUI.View;

namespace Undersoft.SDK.Service.Application.GUI.Generic
{
    public partial class GenericField<TModel> : ViewItem<TModel>, IIdentifiable, IViewItem where TModel : class, IOrigin, IInnerProxy
    {
        private Type _type = default!;
        private IProxy _proxy = default!;
        private int _index;
        private int _size;
        private string? _name { get; set; } = "";
        private string _label { get; set; } = default!;
        private bool _required { get; set; }
        private InputMode _inputMode { get; set; } = InputMode.None;
        private TextFieldType _textFieldType { get; set; } = TextFieldType.Text;

        private long? _numberValue
        {
            get => (long?)Value;
            set => Value = value;
        }
        private double? _decimalValue
        {
            get { return (double?)Value; }
            set { Value = value; }
        }
        private string? _textValue
        {
            get { return Value?.ToString(); }
            set { Value = value; }
        }
        private DateTime? _timeValue
        {
            get { return (DateTime?)Value; }
            set { Value = value; }
        }
        private bool _bitValue
        {
            get => (Value != null) ? (bool)Value : false;
            set => Value = value;
        }

        protected override void OnInitialized()
        {
            _type = Rubric.RubricType;
            _proxy = Data.Model.Proxy;
            _index = Rubric.RubricId;
            _size = Rubric.RubricSize;
            _name = Rubric.RubricName;
            _label = (Rubric.DisplayName != null) ? Rubric.DisplayName : Rubric.RubricName;
            _required = Rubric.Required;
            _inputMode = GetInputMode();
            _textFieldType = GetTexType();
            Id = Rubric.Id;
            TypeId = Model.TypeId;
            Rubric.FieldIdentifier = new FieldIdentifier(this, _name);
            Rubric.View = this;
        }

        public override string Label { get => _label; set { _label = value; } }

        [CascadingParameter]
        public override IViewData<TModel> GenericData { get => (IViewData<TModel>)base.Data; set => base.Data = value; }

        [CascadingParameter]
        protected EditContext FormContext { get; set; } = default!;

        public override object? Value
        {
            get { return _proxy[_index]; }
            set
            {
                _proxy[_index] = value;
                if (ValueChanged.HasDelegate)
                    ValueChanged.InvokeAsync(value);
            }
        }

        private EventCallback<object?> ValueChanged { get; set; }

        [Parameter]
        public override IViewRubric Rubric { get; set; } = default!;

        private InputMode GetInputMode()
        {
            if (_name != null)
            {
                if (_name.ToLower().Contains("phone"))
                    return InputMode.Telephone;
                if (_name.ToLower().Contains("search"))
                    return InputMode.Search;
                if (_name.ToLower().Contains("url"))
                    return InputMode.Url;
                if (_type.IsAssignableTo(typeof(decimal)))
                    return InputMode.Decimal;
            }
            return InputMode.Text;
        }

        private TextFieldType GetTexType()
        {
            if (_name != null)
            {
                if (_name.ToLower().Contains("passw"))
                    return TextFieldType.Password;
                if (_name.ToLower().Contains("email"))
                    return TextFieldType.Email;
                if (_name.ToLower().Contains("phone"))
                    return TextFieldType.Tel;
                if (_name.ToLower().Contains("url"))
                    return TextFieldType.Url;
            }
            return TextFieldType.Text;
        }

        protected bool TryParseValueFromString(
            string? value,
            [MaybeNullWhen(false)] out object result,
            [NotNullWhen(false)] out string? validationErrorMessage
        )
        {
            result = null;
            validationErrorMessage = "";
            if (_type.IsPrimitive)
            {
                if (_type.IsAssignableTo(typeof(long)))
                {
                    if (long.TryParse(value, out long _result))
                        result = _result;
                }
                if (_type.IsAssignableTo(typeof(decimal)))
                {
                    if (decimal.TryParse(value, out decimal _result))
                        result = _result;
                }
                else if (_type.IsAssignableTo(typeof(DateTime)))
                {
                    if (DateTime.TryParse(value, out DateTime _result))
                        result = _result;
                }
                else if (_type.IsAssignableTo(typeof(bool)))
                {
                    if (bool.TryParse(value, out bool _result))
                        result = _result;
                }
                else if (_type.IsAssignableTo(typeof(Enum)))
                {
                    Enum.TryParse(_type, value, out result);
                }
            }
            else if (_type == typeof(string) || _type.IsAssignableTo(typeof(IFormattable)))
            {
                result = value;
            }
            if (result != null)
                return false;
            validationErrorMessage = "Unable to parse value";
            result = "";
            return true;
        }
    }



}
