namespace Gestao.App.Client.Libraries.Notifications
{
    public interface ISelectNotification
    {
        Action? OnCompanySelected { get; set; }
        void NotificateSelecion();        
    }
}
