string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dados.csv");
string fileDest = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "script.sql");

if (File.Exists(fileDest))
    File.Delete(fileDest);

using (StreamReader stream = new StreamReader(fileName))
{
    int cont = 1;
    string script = "";
    string line = stream.ReadLine();

    while ((line = stream.ReadLine()) != null)
    {
        var v = line.Split(';');

        if (v.Length == 0 || string.IsNullOrEmpty(v[0]))
            continue;

        int id = int.Parse(v[0]) / 10;
        string NCM = v[2];
        string cfopSaida = string.IsNullOrEmpty(v[3]) ? "5405" : v[3];
        string cstICMS = string.IsNullOrEmpty(v[4]) ? "060" : v[4];
        double aliquotaICMS = string.IsNullOrEmpty(v[5]) || v[5] == "(vazio)" ? 0d : double.Parse(v[5]);
        double reducaoBCICMS = string.IsNullOrEmpty(v[6]) ? 0d : double.Parse(v[6]) / 100;
        string cstPIS_COFINS = string.IsNullOrEmpty(v[7]) ? "01" : v[7];

        if (string.IsNullOrEmpty(NCM))
            continue;

        script += "UPDATE T240 SET " +
            $"CP24056 = {NCM}, " +
            $"CP24073 = '{cfopSaida}', " +
            $"CP24048 = '{cstICMS}', " +
            $"CP24057 = {aliquotaICMS.ToString("0.00").Replace(',','.')}, " +
            $"CP24047 = {reducaoBCICMS.ToString("0.00").Replace(',','.')}, " +
            $"CP24069 = '{cstPIS_COFINS}', " +
            $"CP24071 = '{cstPIS_COFINS}', " +
            "CP24036 = -2 " +
            $"WHERE CP24000 = {id};\n";

        if (cont++ == 1000)
            script += "COMMIT WORK;\n";
    }

    script += "COMMIT WORK;";

    File.WriteAllText(fileDest, script);
}

Console.WriteLine("FIM");