
using ScreenSound.Domain.Database;
using ScreenSound.Domain.Models;



using var context = new DatabaseContext();

var artistaDal = new ArtistaDAL(context);
var musicaDal = new MusicaDAL(context);

//var artista = new Artista("JOTA QUEST", "É uma banda pop-rock mineira");
//artistaDAL.Add(artista);
//context.SaveChanges();

Console.WriteLine("Artistas");
foreach (var a in artistaDal.List())
    Console.WriteLine(a);

Console.WriteLine("\n\nMúsicas");
foreach (var m in musicaDal.List())
    Console.WriteLine(m);


var jota = artistaDal.SelectBy(i => i.Nome.ToUpper().StartsWith("JOTA"));

//if (jota != null)
//{
//    jota.Musicas.Add(new Musica
//    {
//        Nome = "Dias Melhores",
//        AnoLancamento = 2000,
//        Compositor = "Jota Quest"
//    });

//    artistaDal.Update(jota);
//    context.SaveChanges();
//}


