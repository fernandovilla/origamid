namespace BlazorWebApp.Models
{
    public class Email : ISenderMessage
    {
        public bool Send(string message)
        {
            return true;
        }
    }
}
