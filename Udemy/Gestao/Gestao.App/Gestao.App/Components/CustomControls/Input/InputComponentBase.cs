using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Gestao.App.Components.CustomControls.Input
{

    /***************************************************************************
        InputDecimal Sample
        https://blazorcomponentauthority.com/
        https://lively-sea-07d95cd0f.2.azurestaticapps.net/ 

        https://www.youtube.com/watch?v=nkfF8q754ys
    ***************************************************************************/
    public class InputComponentBase : ComponentBase
    {

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? AdditionalAttributes { get; set; }

        /// <summary>
        /// The input Id.
        /// Can be used to uniquely identify instances of the component.
        /// Helps with making UI testing less brittle.
        /// </summary>
        [Parameter]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The title or tooltip to show when the user hovers over the input.
        /// </summary>
        [Parameter]
        public string Title { get; set; } = string.Empty;

        [CascadingParameter]
        protected EditContext? _EditContext { get; set; }

        /// <summary>
        /// The name of the EditContext model property bound to this input.
        /// Required to display the model property validation messages.
        /// </summary>
        [Parameter]
        public string? For { get; set; }

        /// <summary>
        /// The label to be displayed.
        /// </summary>
        [Parameter]
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// The class to be applied to the input element.
        /// </summary>
        [Parameter]
        public string ClassInput { get; set; } = string.Empty;

        /// <summary>
        /// The class to be applied to the label element.
        /// </summary>
        [Parameter]
        public string ClassLabel { get; set; } = string.Empty;

        /// <summary>
        /// The class to be applied to the div that wraps the component.
        /// </summary>
        [Parameter]
        public string ClassDiv { get; set; } = string.Empty;

        /// <summary>
        /// The class to be applied to the input when the input value is valid.
        /// </summary>
        [Parameter]
        public string ClassValid { get; set; } = "valid";

        /// <summary>
        /// The class to be applied to the input when the input value has been modified.
        /// </summary>
        [Parameter]
        public string ClassModified { get; set; } = "valid modified";

        /// <summary>
        /// The class to be applied to the input when the input value is invalid.
        /// </summary>
        [Parameter]
        public string ClassInvalid { get; set; } = "invalid";

        protected string ValidationResultClass { get; set; } = string.Empty;

        /// <summary>
        /// The class to be applied to the validation message.
        /// </summary>
        [Parameter]
        public string ClassValidationMessage { get; set; } = "validation-message";

        /// <summary>
        /// The list of validation messages.
        /// </summary>
        public List<string> ValidationMessages { get; set; } = new List<string>();
    }
}

