using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Services
{
    public interface IEmailService
    {
        Task SendEmail(int id);

        bool IsEmailDelivered(int id);

    }
}
