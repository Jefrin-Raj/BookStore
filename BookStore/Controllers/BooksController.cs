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
        

        public BooksController(IBooksBusiness booksBusiness)
        {
            BooksBusiness = booksBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
        {
            try
            {
                var books = await BooksBusiness.GetBooksAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                // Log the exception (logging not shown here)
                return StatusCode(500, $"An error occurred while retrieving books: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("insertrecord")]
        public async Task<ActionResult<InsertRecordResponse>> InsertRecord(InsertRecordRequest insertRecordRequest)
        {
            try
            {
                var response = await BooksBusiness.InsertRecord(insertRecordRequest);
                return CreatedAtAction(nameof(GetBooks), new { id = response.BookId }, response);
            }
            catch (Exception ex)
            {
                // Log the exception (logging not shown here)
                return StatusCode(500, $"An error occurred while inserting the record: {ex.Message}");
            }
        }
    }
}
