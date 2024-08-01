using Microsoft.AspNetCore.Identity.UI.Services;

namespace HexaShop.Utility
{
    public class EmailServicescs : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
           return Task.CompletedTask;
        }
    }
}
