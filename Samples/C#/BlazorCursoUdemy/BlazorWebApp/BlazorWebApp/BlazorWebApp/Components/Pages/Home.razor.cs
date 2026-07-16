using BlazorWebApp.Models;
using Microsoft.AspNetCore.Components;
using System.Runtime.InteropServices;

namespace BlazorWebApp.Components.Pages
{
    public partial class Home
    {
        [Inject(Key ="email")]
        public ISenderMessage senderEmail { get; set; }

        [Inject(Key = "sms")]
        public ISenderMessage senderSms { get; set; }
    }
}
