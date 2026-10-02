using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace Sistema.WebApp.Components.CustomControls
{
 


    public class AppTextField : AppTextBase<string>
    {
        public AppTextField()
            : base(InputType.Text)
        { }
    }
}
