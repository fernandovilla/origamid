using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorWebApp.Components.Pages
{
    public partial class Separation
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; } = default!;

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            var modulo = JSRuntime.InvokeAsync<IJSObjectReference>("import", "./Components/Pages/Separation.razor.js").Result;
         }

        public string Texto { get; set; } = $"Código C# - {DateTime.Now}";
    }
}
