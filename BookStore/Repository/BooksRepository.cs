using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using BookStore.Data;
using BookStore.Business.Interface;

namespace BookStore.Business.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly AppDbContext Context;

        public BooksRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<Books>> GetBooksAsync()
        {
            return await Context.Books.ToListAsync();
        }

        public async Task<Books> AddBookAsync(Books books)
        {
            Context.Books.Add(books);
            await Context.SaveChangesAsync();
            return books;
        }
    }
}
