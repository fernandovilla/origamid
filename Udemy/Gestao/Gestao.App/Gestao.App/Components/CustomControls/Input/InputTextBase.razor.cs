using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Gestao.App.Components.CustomControls.Input
{
    public class InputTextBaseCode : InputComponentBase
    {
        private string? originalValue { get; set; }
        private string? value { get; set; }

        /// <summary>
        /// The string value of the input
        /// </summary>
        [Parameter]
        public string? Value
        {
            get { return value; }

            set
            {
                if (this.value != value)
                {
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
        }

        /// <summary>
        /// A callback method used to update the property bound to the Value parameter.
        /// </summary>
        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        /// <summary>
        /// A callback method that is invoked when the Value changes.
        /// </summary>
        [Parameter]
        public EventCallback<string> OnChanged { get; set; }

        /// <summary>
        /// A value shown in the input when the input is empty or null.
        /// </summary>
        [Parameter]
        public string Placeholder { get; set; } = string.Empty;

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

        private void Dispose()
        {
            if (_EditContext == null) { return; }
            _EditContext.OnFieldChanged -= HandleFieldChanged;
            _EditContext.OnValidationStateChanged -= HandleValidationStateChanged;
        }
    }
}
