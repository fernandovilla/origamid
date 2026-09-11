using Blazored.LocalStorage;
using Gestao.App.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Gestao.App.Components
{
    public class PageBase : ComponentBase
    {
        [Inject] protected ILocalStorageService LocalStorage { get; set; } = null!;

        [Inject] protected ApplicationDbContext DbContext { get; set; } = null!;

        [Inject] protected NavigationManager NavigationManager { get; set; } = null!;

        [Inject] protected IJSRuntime JSRuntime { get; set; } = null!;



        protected override void OnInitialized()
        {
            //TODO - Verifica se usuário está autenticado
        }
    }
}
