﻿using Microsoft.AspNetCore.Identity.UI.Services;

namespace BreakingNews_Core7._0.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //Email gönderme işlemleri burada yapılabilir
            return Task.CompletedTask;
        }
    }
}
