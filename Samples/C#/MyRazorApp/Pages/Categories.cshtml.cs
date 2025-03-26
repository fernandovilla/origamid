using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorApp.Pages
{
    public class CategoriesModel : PageModel
    {

        public int count = 0;
        public List<Category> Categories { get; set; } = new();


        public void OnGet(int skip = 0, int take = 25)
        {
            //executa qdo a página é carregada
            this.count = 20;

            //await Task.Delay(5000); //simulando o request do servidor
            var categoriesTemp = new List<Category>();

            for (int i = 0; i <= 1798; i++)
                categoriesTemp.Add(new Category(i, $"ITEM {i}", 0.25m * (new Random().Next())));


            this.Categories = categoriesTemp
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public void OnPost()
        {
            //executa sempre que ocorrer um post na página
        }

        public record Category(int id, string name, decimal price);
    }
}