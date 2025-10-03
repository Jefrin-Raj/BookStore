using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Business.Interface
{
    public interface IBooksBusiness
    {
    Task<IEnumerable<Books>> GetBooksAsync();
    Task<InsertRecordResponse> InsertRecord(InsertRecordRequest insertRecordRequest);
    }
}