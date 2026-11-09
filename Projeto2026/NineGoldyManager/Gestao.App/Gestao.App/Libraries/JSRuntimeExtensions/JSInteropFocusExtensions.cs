using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Gestao.App.Libraries.JSRuntimeExtensions
{
    public static class JSInteropFocusExtensions
    {
        public static ValueTask FocusAsync(this IJSRuntime jsRuntime, ElementReference elementReference)
        {
            return jsRuntime.InvokeVoidAsync("FocusElement", elementReference);
        }
    }
}