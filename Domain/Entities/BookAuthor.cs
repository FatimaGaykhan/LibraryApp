using System;
using Domain.Common;

namespace Domain.Entities
{
	public class BookAuthor:BaseEntity
	{
		public Book Book { get; set; }

		public int BookId { get; set; }

		public Author Author { get; set; }

		public int AuthorId { get; set; }

	}
}

