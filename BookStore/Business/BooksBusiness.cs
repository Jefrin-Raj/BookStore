using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using BookStore.Enums;
using BookStore.Models;
using BookStore.Data;
using BookStore.Business.Interface;

namespace BookStore.Business
{
    public class BooksBusiness : IBooksBusiness
    {

    private readonly IBooksRepository BooksRepository;

        public BooksBusiness(IBooksRepository booksRepository)
        {
            BooksRepository = booksRepository;
        }

        public async Task<IEnumerable<Books>> GetBooksAsync()
        {
            return await BooksRepository.GetBooksAsync();
        }

        public async Task<InsertRecordResponse> InsertRecord(InsertRecordRequest insertRecordRequest)
        {
            var newBooks = new Books
            {
                Title = insertRecordRequest.Title,
                LanguageId = insertRecordRequest.LanguageId,
                PublicationDate = insertRecordRequest.PublicationDate,
                AuthorId = insertRecordRequest.AuthorId,
                Price = insertRecordRequest.Price,
                Status = insertRecordRequest.Status,
                Stock = insertRecordRequest.Stock,
                Genre = insertRecordRequest.Genre
            };

            var addedBooks = await BooksRepository.AddBookAsync(newBooks);

            return new InsertRecordResponse
            {
                BookId = addedBooks.BookId,
                Title = addedBooks.Title,
                LanguageId = addedBooks.LanguageId,
                PublicationDate = addedBooks.PublicationDate,
                AuthorId = addedBooks.AuthorId,
                Price = addedBooks.Price,
                Status = addedBooks.Status,
                Stock = addedBooks.Stock,
                Genre = addedBooks.Genre
            };
        }
    }
}