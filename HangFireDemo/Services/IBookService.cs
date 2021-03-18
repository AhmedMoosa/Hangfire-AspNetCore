using HangFireDemo.Models;
using System.Threading.Tasks;

namespace HangFireDemo.Services
{
    public interface IBookService
    {
        Task<int> CreateAsync(InputBook book);

        Task UpdateAsync(int id, InputBook bookToUpdate);
    }
}