using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using BookStore.Data;
using BookStore.Business.Interface;
using BookStore.Constants;
using Microsoft.Extensions.Logging;

namespace BookStore.Business.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly AppDbContext Context;
        private readonly ILogger<BooksRepository> Logger;

        public BooksRepository(AppDbContext context, ILogger<BooksRepository> logger)
        {
            Context = context;
            Logger = logger;
        }

        public async Task<IEnumerable<Books>> GetBooksAsync()
        {
            Logger.LogInformation("Starting GetBooksAsync at -- " + DateTime.UtcNow.ToString());
            try
            {
                var response = await Context.Books.FromSqlRaw(DBQueryConstants.Usp_GetAllBooks).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while retrieving books.");
                throw;
            }
            finally
            {
                Logger.LogInformation("Ending GetBooksAsync at -- " + DateTime.UtcNow.ToString());
            }
        }

        public async Task<Books> AddBookAsync(Books books)
        {
            Context.Books.Add(books);
            await Context.SaveChangesAsync();
            return books;
        }
    }
}
