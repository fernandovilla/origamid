using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace NGManager.Components.CustomControls
{
    public class AppPasswordField : AppTextBase<string>
    {
        public AppPasswordField() : base(InputType.Password)
        {            
            AdornmentIcon = Icons.Material.Filled.VisibilityOff;
            AdornmentAriaLabel = "Mostrar";
            Adornment = Adornment.End;
            OnAdornmentClick = EventCallback.Factory.Create<MouseEventArgs>(this, TogglePasswordVisibility);
        }

        private void TogglePasswordVisibility(MouseEventArgs args)
        {
            if (InputType == InputType.Password)
            {
                InputType = InputType.Text;
                AdornmentIcon = Icons.Material.Filled.Visibility;
                AdornmentAriaLabel = "Ocultar";
            }
            else
            {
                InputType = InputType.Password;
                AdornmentIcon = Icons.Material.Filled.VisibilityOff;
                AdornmentAriaLabel = "Mostrar";
            }
        }
    }
}
