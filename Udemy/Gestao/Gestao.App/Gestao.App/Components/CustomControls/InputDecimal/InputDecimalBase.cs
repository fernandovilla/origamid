using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Globalization;

namespace Gestao.App.Components.CustomControls.InputDecimal
{
    public class InputDecimalBase: InputComponentBase
    {
        private decimal? originalValue { get; set; }
        private decimal? value { get; set; }

        /// <summary>
        /// The string value of the input
        /// </summary>
        [Parameter]
        public decimal? Value
        {
            get { return value; }

            set
            {
                if (this.value == value)
                {
                    return;
                }

                if (Min > value || value > Max)
                {
                    return;
                }

                this.value = value;

                if (ValueChanged.HasDelegate)
                {
                    ValueChanged.InvokeAsync(value);
                }

                if (OnChanged.HasDelegate)
                {
                    OnChanged.InvokeAsync(value);
                }

                if (_EditContext != null && For != null)
                {
                    var fieldIdentifier = _EditContext.Field(For);
                    _EditContext.NotifyFieldChanged(fieldIdentifier);
                }
            }
        }

        /// <summary>
        /// The maximum value the user is allowed to enter
        /// </summary>
        [Parameter]
        public decimal? Max { get; set; } = Convert.ToDecimal(int.MaxValue);

        /// <summary>
        /// The minimum value the user is allowed to enter
        /// </summary>
        [Parameter]
        public decimal? Min { get; set; } = Convert.ToDecimal(-int.MaxValue);

        /// <summary>
        /// A callback method used to update the property bound to the Value parameter.
        /// </summary>
        [Parameter]
        public EventCallback<decimal?> ValueChanged { get; set; }

        /// <summary>
        /// A callback method that is invoked when the Value changes.
        /// </summary>
        [Parameter]
        public EventCallback<decimal?> OnChanged { get; set; }

        /// <summary>
        /// String format specifier, default value is C2
        /// C is currency, C2 has 2 decimal places
        /// E is exponential, E3 has 3 decimal places
        /// F is fixed point, F0-9
        /// G is general
        /// N is number, N0-9
        /// P is percentage, P0-9
        /// </summary>
        [Parameter]
        public string Format { get; set; } = "C2";

        /// <summary>
        /// Provides information about a specific culture (called a locale for unmanaged code development). 
        /// The information includes the names for the culture, the writing system, the calendar used, 
        /// the sort order of strings, and formatting for dates and numbers.
        /// Default value is CultureInfo.CurrentCulture
        /// </summary>
        [Parameter]
        public CultureInfo Provider { get; set; } = CultureInfo.CurrentCulture;

        protected override void OnInitialized()
        {
            if (_EditContext != null && !string.IsNullOrWhiteSpace(For))
            {
                _EditContext.OnFieldChanged += HandleFieldChanged;
                _EditContext.OnValidationStateChanged += HandleValidationStateChanged;
            }

            originalValue = Value;
            ValidationResultClass = ClassValid;
            base.OnInitialized();
        }

        private void HandleFieldChanged(object? sender, FieldChangedEventArgs e)
        {
            GetApplicableValidationMessages();
        }

        private void HandleValidationStateChanged(object? sender, ValidationStateChangedEventArgs e)
        {
            GetApplicableValidationMessages();
        }

        private void GetApplicableValidationMessages()
        {
            if (_EditContext == null || string.IsNullOrWhiteSpace(For)) { return; }

            var fieldIdentifier = _EditContext.Field(For);
            var messages = _EditContext.GetValidationMessages(fieldIdentifier).ToList();
            if (messages.Count == 0)
            {
                ValidationMessages.Clear();
                var isModified = _EditContext.IsModified(fieldIdentifier);

                if (isModified && Value != originalValue)
                {
                    ValidationResultClass = ClassModified;
                }
                else
                {
                    ValidationResultClass = ClassValid;
                }
            }
            else
            {
                ValidationResultClass = ClassInvalid;
                ValidationMessages = messages;
            }
            StateHasChanged();
        }

        protected string? valueAsString { get; set; }

        protected string? ValueAsString
        {
            get
            {
                if (valueAsString == null && value == null)
                {
                    return "-";
                }

                if (valueAsString == "-" && value == null)
                {
                    return "-";
                }

                try
                {
                    return value?.ToString(Format, Provider);
                }
                catch (Exception ex)
                {
                    ValidationMessages.Clear();
                    ValidationMessages.Add(ex.Message);
                    return null;
                }
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    HandleValueChange(null, null);
                    return;
                }

                value = value.Trim().Trim('%').Trim();

                if (value == "-")
                {
                    HandleValueChange(value, null);
                    return;
                }

                if (Format.Contains('P'))
                {
                    HandlePercentageInput(value);
                    return;
                }

                try
                {
                    var newValue = Decimal.Parse(value, NumberStyles.AllowExponent |
                                                        NumberStyles.AllowDecimalPoint |
                                                        NumberStyles.AllowCurrencySymbol |
                                                        NumberStyles.AllowParentheses |
                                                        NumberStyles.AllowLeadingSign |
                                                        NumberStyles.AllowThousands);

                    if (newValue < Min)
                    {
                        ValidationMessages.Add($"The minimum value is {Min}.");
                        return;
                    }

                    if (newValue > Max)
                    {
                        ValidationMessages.Add($"The maximum value is {Max}.");
                        return;
                    }

                    HandleValueChange(value, newValue);
                }
                catch (Exception ex)
                {
                    ValidationMessages.Clear();
                    ValidationMessages.Add(ex.Message);
                    return;
                }
            }
        }

        void HandlePercentageInput(string value)
        {
            try
            {
                var newValue = Decimal.Parse(value, NumberStyles.AllowExponent |
                                                        NumberStyles.AllowDecimalPoint |
                                                        NumberStyles.AllowCurrencySymbol |
                                                        NumberStyles.AllowParentheses |
                                                        NumberStyles.AllowLeadingSign |
                                                        NumberStyles.AllowThousands);
                newValue = newValue / 100;

                if (newValue < Min)
                {
                    ValidationMessages.Add($"The minimum value is {Min}.");
                    return;
                }

                if (newValue > Max)
                {
                    ValidationMessages.Add($"The maximum value is {Max}.");
                    return;
                }

                HandleValueChange(value, newValue);
            }
            catch (Exception ex)
            {
                ValidationMessages.Clear();
                ValidationMessages.Add(ex.Message);
                return;
            }
        }

        void HandleValueChange(string? stringValue, decimal? decimalValue)
        {
            valueAsString = stringValue;
            this.value = decimalValue;

            if (ValueChanged.HasDelegate)
            {
                ValueChanged.InvokeAsync(value);
            }

            if (OnChanged.HasDelegate)
            {
                OnChanged.InvokeAsync(value);
            }

            if (_EditContext != null && For != null)
            {
                var fieldIdentifier = _EditContext.Field(For);
                _EditContext.NotifyFieldChanged(fieldIdentifier);
            }
        }

        protected void Dispose()
        {
            if (_EditContext == null) { return; }
            _EditContext.OnFieldChanged -= HandleFieldChanged;
            _EditContext.OnValidationStateChanged -= HandleValidationStateChanged;
        }
    }
}
