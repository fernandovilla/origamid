// See https://aka.ms/new-console-template for more information
using TesteDapper;


using(var unit = new UnitOfWork())
{
    var repository = unit.GetIngredienteRepository();

    foreach (var i in repository.GetAll())
    {
        var ing = repository.Get(i.Id);
        Console.WriteLine($"{ing.Nome.PadRight(30)} Embalagens: {ing.Embalagens.Count()}");
    }

    var ingrediente = repository.Get(337);
}

Console.ReadKey();