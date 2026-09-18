using System;
using System.Collections.Generic;
using System.Text;

namespace MudBlazorBolos.Lib.Models
{
    public class BoloRepository
    {
        private static IList<Bolo> _bolos = null!;

        private static IList<Bolo> Bolos
        {
            get
            {
                if (_bolos == null)
                    CreateBolos();

                return _bolos!;
            }

            set => _bolos = value;
        }

        private static void CreateBolos()
        {
            _bolos = new List<Bolo> {
                new Bolo{ Id = 1,  Nome = "Chocolate",        Descricao = "Chocolate com morango",                    Preco = 100, ImageURL = "https://placehold.co/400x300?text=Chocolate" },
                new Bolo{ Id = 2,  Nome = "Cenoura",          Descricao = "Cenoura com cobertura de brigadeiro",      Preco = 75,  ImageURL = "https://placehold.co/400x300?text=Cenoura" },
                new Bolo{ Id = 3,  Nome = "Red Velvet",       Descricao = "Massa aveludada com cream cheese",         Preco = 130, ImageURL = "https://placehold.co/400x300?text=Red+Velvet" },
                new Bolo{ Id = 4,  Nome = "Limão",            Descricao = "Massa cítrica com merengue maçaricado",    Preco = 85,  ImageURL = "https://placehold.co/400x300?text=Limao" },
                new Bolo{ Id = 5,  Nome = "Prestígio",        Descricao = "Chocolate com recheio de coco",            Preco = 110, ImageURL = "https://placehold.co/400x300?text=Prestigio" },
                new Bolo{ Id = 6,  Nome = "Ninho com Nutella",Descricao = "Creme de leite ninho e Nutella",           Preco = 145, ImageURL = "https://placehold.co/400x300?text=Ninho+Nutella" },
                new Bolo{ Id = 7,  Nome = "Floresta Negra",   Descricao = "Chocolate, chantilly e cerejas",           Preco = 140, ImageURL = "https://placehold.co/400x300?text=Floresta+Negra" },
                new Bolo{ Id = 8,  Nome = "Fubá",             Descricao = "Fubá cremoso com erva-doce",               Preco = 55,  ImageURL = "https://placehold.co/400x300?text=Fuba" },
                new Bolo{ Id = 9,  Nome = "Milho",            Descricao = "Milho verde com leite condensado",         Preco = 60,  ImageURL = "https://placehold.co/400x300?text=Milho" },
                new Bolo{ Id = 10, Nome = "Maracujá",         Descricao = "Mousse de maracujá com calda azedinha",    Preco = 95,  ImageURL = "https://placehold.co/400x300?text=Maracuja" },
                new Bolo{ Id = 11, Nome = "Banana",           Descricao = "Banana caramelizada com canela",           Preco = 70,  ImageURL = "https://placehold.co/400x300?text=Banana" },
                new Bolo{ Id = 12, Nome = "Abacaxi",          Descricao = "Abacaxi com creme de baunilha",            Preco = 90,  ImageURL = "https://placehold.co/400x300?text=Abacaxi" },
                new Bolo{ Id = 13, Nome = "Doce de Leite",    Descricao = "Massa branca com doce de leite argentino", Preco = 115, ImageURL = "https://placehold.co/400x300?text=Doce+de+Leite" },
                new Bolo{ Id = 14, Nome = "Ameixa",           Descricao = "Creme branco com calda de ameixa",         Preco = 105, ImageURL = "https://placehold.co/400x300?text=Ameixa" },
                new Bolo{ Id = 15, Nome = "Café",             Descricao = "Café espresso com ganache meio amargo",    Preco = 120, ImageURL = "https://placehold.co/400x300?text=Cafe" },
                new Bolo{ Id = 16, Nome = "Coco Gelado",      Descricao = "Massa branca molhadinha com coco ralado",  Preco = 80,  ImageURL = "https://placehold.co/400x300?text=Coco+Gelado" },
                new Bolo{ Id = 17, Nome = "Morango",          Descricao = "Chantilly com morangos frescos",           Preco = 125, ImageURL = "https://placehold.co/400x300?text=Morango" },
                new Bolo{ Id = 18, Nome = "Nozes",            Descricao = "Nozes trituradas com creme de baunilha",   Preco = 150, ImageURL = "https://placehold.co/400x300?text=Nozes" },
                new Bolo{ Id = 19, Nome = "Formigueiro",      Descricao = "Baunilha com granulado de chocolate",       Preco = 65,  ImageURL = "https://placehold.co/400x300?text=Formigueiro" },
                new Bolo{ Id = 20, Nome = "Brigadeiro Belga", Descricao = "Chocolate belga com brigadeiro cremoso",   Preco = 160, ImageURL = "https://placehold.co/400x300?text=Brigadeiro+Belga" }
            };
        }

        public async Task<IList<Bolo>> ListAsync() => Bolos;

        public void Insert(Bolo bolo)
        {
            Bolos.Add(bolo);
        }

        public Bolo Select(int id)
        {
            return Bolos.First(i => i.Id == id);
        }

        public void Update(Bolo bolo)
        {
            var boloList = Bolos.First(i => i.Id == bolo.Id);
            Bolos.Remove(boloList);
            Bolos.Add(bolo);
        }

        public void Delete(int id)
        {
            var bolo = Select(id);
            Bolos.Remove(bolo);
        }
    }
}
