using Hangfire;
using HangFireDemo.Data;
using HangFireDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Services
{
    public class BookService : IBookService
    {
        public BookService(ApplicationDbContext dbContext, IBackgroundJobClient bgjobs)
        {
            DbContext = dbContext;
            BgJobs = bgjobs;
        }

        public ApplicationDbContext DbContext { get; }
        public IBackgroundJobClient BgJobs { get; }

        public async Task<int> CreateAsync(InputBook book)
        {
            var bookToAdd = new Book
            {
                PagesCount = book.PagesCount,
                ShortDescription = book.ShortDescription,
                Title = book.Title
            };
            await DbContext.AddAsync(bookToAdd);
            var result = await DbContext.SaveChangesAsync();
            if (result > 0)
            {
                BgJobs.Enqueue(() => Console.WriteLine("First Background Job"));
            }
            return bookToAdd.Id; // just for test, we return id;
        }

        public async Task UpdateAsync(int id, InputBook bookToUpdate)
        {
            var selectedBook = await DbContext.Books.FindAsync(id);
            if (selectedBook != null)
            {
                // Update Something

                await DbContext.SaveChangesAsync();
            }
        }
    }
}
