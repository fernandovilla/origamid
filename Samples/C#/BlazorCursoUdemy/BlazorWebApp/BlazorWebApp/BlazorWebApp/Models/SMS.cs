namespace BlazorWebApp.Models
{
    public class SMS : ISenderMessage
    {
        public bool Send(string textMessage)
        {
            return true;
        }
    }
}
