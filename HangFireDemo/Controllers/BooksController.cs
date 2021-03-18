using Hangfire;
using HangFireDemo.Data;
using HangFireDemo.Models;
using HangFireDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IBackgroundJobClient backgroundJob;


        public BooksController(IBookService bookService, IBackgroundJobClient backgroundJob)
        {
            this._bookService = bookService;
            this.backgroundJob = backgroundJob;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InputBook book)
        {
            var createdId = await _bookService.CreateAsync(book);

            backgroundJob.Schedule<IEmailService>(emailService => emailService.SendEmail(createdId), TimeSpan.FromMinutes(1));

            backgroundJob.Enqueue(() => _bookService.UpdateAsync(createdId, new InputBook {  /* put some data to update book */}));

            //backgroundJob.Enqueue<IBookService>(b => b.UpdateAsync(createdId, new InputBook {  /* put some data to update book */}));


            //var jobId = backgroundJob.Enqueue<IBookService>(b => b.UpdateAsync(createdId, new InputBook {  /* put some data to update book */}));
            //var condition = true;
            //if (condition)
            //{
            //    //change Status
            //    backgroundJob.ChangeState(jobId, new Hangfire.States.DeletedState() { Reason = "some reason" });
            //    //Delete
            //    backgroundJob.Delete(jobId);
            //}

            return RedirectToAction("Index", "Home");
        }


    }
}
