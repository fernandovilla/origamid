

var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "estoque.csv");
using(var reader =  new StreamReader(fileName))
{
    int cont = 0;
    int codigo = 0;
    int estoque = 0;

    string script = "UPDATE T240 SET CP24032 = 0 WHERE CP24032 <= 0;\n" +
        "COMMIT WORK;\n";


    string line = reader.ReadLine(); // Lê o cabeçalho e ignora

    while((line = reader.ReadLine()) != null)
    {
        var v = line.Split(';');

        if (v.Length == 0)
            continue;

        if (v[0] == codigo.ToString())
            continue;

        codigo = int.Parse(v[0]);
        estoque = int.Parse(v[8]);

        script += $"UPDATE T240 SET CP24032 = {estoque}, CP24036 = -2 WHERE CP24000 = {(int)(codigo / 10)};\n";

        cont++;
        if (cont >= 200 && cont % 200 == 0)
            script += "COMMIT WORK;\n";
    }

    script += "COMMIT WORK;\n";

    string fileScript = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "script.sql");

    if (File.Exists(fileScript))
        File.Delete(fileScript);

    File.WriteAllText(fileScript, script);
}