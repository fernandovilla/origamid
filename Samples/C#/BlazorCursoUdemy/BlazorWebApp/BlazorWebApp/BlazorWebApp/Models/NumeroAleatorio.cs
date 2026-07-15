namespace BlazorWebApp.Models
{
    public class NumeroAleatorio
    {
        public int NumeroiIdentificado { get; set; }

        public NumeroAleatorio()
        {
            Random rdn = new Random();
            NumeroiIdentificado = rdn.Next(0, 10000);
        }
    }
}
