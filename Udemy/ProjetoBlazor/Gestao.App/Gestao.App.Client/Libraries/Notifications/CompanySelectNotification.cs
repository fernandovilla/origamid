namespace Gestao.App.Client.Libraries.Notifications
{
    public class CompanySelectNotification : ICompanySelectNotification
    {
        public Action? OnCompanySelected { get; set; }

        public void NotificateSelecion()
        {
            OnCompanySelected?.Invoke();
        }
    }
}
