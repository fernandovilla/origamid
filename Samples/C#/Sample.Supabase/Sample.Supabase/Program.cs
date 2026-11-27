using Npgsql;

string connString = "Host=db.nkvolqkfkkhfpgbtcasf.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=Z5w0PO1n8ctZ;SSL Mode=Require;Trust Server Certificate=true";


NpgsqlConnection conn = new NpgsqlConnection(connString);
await conn.OpenAsync();

await conn.CloseAsync();