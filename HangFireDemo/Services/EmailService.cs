using HangFireDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Services
{
    public class EmailService : IEmailService
    {
        public EmailService(IBookService bookService)
        {
            BookService = bookService;
        }

        public IBookService BookService { get; }

        public bool IsEmailDelivered(int id)
        {
            // 
            return true;
        }

        public async Task SendEmail(int id)
        {
            //best practice to check if job is done after re-execute it again in retry.
            if (!this.IsEmailDelivered(id))
            {

                //do something (send email)
                Console.WriteLine("Send Email  By Book Id : " + id);

                //do something with database 
                await BookService.UpdateAsync(id, new InputBook {  /* put some data to update book */});
            }
        }
    }
}
