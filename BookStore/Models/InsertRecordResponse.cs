using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using BookStore.Enums;
namespace BookStore.Models
{
	public class InsertRecordResponse
	{
		public int BookId { get; set; } // PK
		public string? Title { get; set; }
		public int LanguageId { get; set; } // FK
		public DateTime PublicationDate { get; set; }
		public int AuthorId { get; set; } // FK
		public float Price { get; set; }
		public bool Status { get; set; }
		public int Stock { get; set; }
		public Genre Genre { get; set; }
	}
}
