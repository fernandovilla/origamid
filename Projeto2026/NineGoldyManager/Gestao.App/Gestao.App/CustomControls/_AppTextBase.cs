using MudBlazor;

namespace Ninegoldy.Components.CustomControls
{
    public class _AppTextBase<T> : MudTextField<T>
    {
        public _AppTextBase(InputType inputType)
        {
            InputType = inputType;
            Margin = Margin.Dense;
            Variant = Variant.Outlined;
            Clearable = true;
        }
    }
}
