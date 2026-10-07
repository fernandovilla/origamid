using MudBlazor;

namespace NGManager.Components.CustomControls
{
    public class AppTextField : AppTextBase<string>
    {
        public AppTextField()
            : base(InputType.Text)
        { }
    }
}
