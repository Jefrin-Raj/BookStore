using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Business.Interface
{
    public interface IBooksRepository
    {
    Task<IEnumerable<Books>> GetBooksAsync();
    Task<Books> AddBookAsync(Books books);
    }
}
