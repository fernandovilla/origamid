// See https://aka.ms/new-console-template for more information
using System.Data.Odbc;

Console.WriteLine("Hello, World!");



var connectionString = "Driver={MySQL ODBC 3.51 Driver};Server=agendabolo.cxfygvtvor4g.us-east-2.rds.amazonaws.com;Database=agendabolo;User=admin;Password=32961200;Option=3;useSSL=false";
using (OdbcConnection conn = new OdbcConnection(connectionString))
{
    conn.Open();

    conn.Close();
}