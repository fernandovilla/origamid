using MudBlazor;

namespace Ninegoldy.Components.CustomControls
{
    public class AppTextBase<T> : MudTextField<T>
    {
        public AppTextBase(InputType inputType)
        {
            InputType = inputType;
            Margin = Margin.Dense;
            Variant = Variant.Outlined;
            Clearable = true;
        }
    }
}
