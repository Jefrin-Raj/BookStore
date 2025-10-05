using Microsoft.AspNetCore.Mvc;
using BookStore.Data;
using BookStore.Business.Interface;
using BookStore.Models;
using System.Collections.Generic;
using System;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
    private readonly IBooksBusiness BooksBusiness;
    private readonly ILogger<BooksController> Logger;
        

        public BooksController(IBooksBusiness booksBusiness, ILogger<BooksController> logger)
        {
            BooksBusiness = booksBusiness;
            Logger = logger;
        }

        [HttpGet]
        [Route("getbooks")]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
        {
            try
            {
                var books = await BooksBusiness.GetBooksAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while retrieving books.");
                return StatusCode(500, new { error = $"An error occurred while retrieving books: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("insertrecord")]
        public async Task<ActionResult<InsertRecordResponse>> InsertRecord(InsertRecordRequest insertRecordRequest)
        {
            try
            {
                var books = await BooksBusiness.GetBooksAsync();
                if(books.Any(b => b.Title == insertRecordRequest.Title && b.AuthorId == insertRecordRequest.AuthorId))
                {
                    Logger.LogInformation("Attempt to insert duplicate book with Title: {Title} and AuthorId: {AuthorId}", insertRecordRequest.Title, insertRecordRequest.AuthorId);
                    return StatusCode(409, new { error = "A book with the same title and author already exists." });
                }
                var response = await BooksBusiness.InsertRecord(insertRecordRequest);
                return CreatedAtAction(nameof(GetBooks), new { id = response.BookId }, response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while inserting the record.");
                return StatusCode(500, new { error = $"An error occurred while inserting the record: {ex.Message}" });
            }
        }
    }
}
