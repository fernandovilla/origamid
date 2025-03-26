using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorApp.Pages
{
    public class IndexModel : PageModel
    {        
        public async Task OnGet()
        {
            //executa ao carregar a página

        }

        public void OnPost()
        {
            //executa sempre que ocorrer um post na página
        }
    }

    
}
