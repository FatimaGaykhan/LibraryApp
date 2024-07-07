using System;
using Domain.Common;

namespace Domain.Entities
{
	public class Book:BaseEntity
	{
		public string Name { get; set; }

		public ICollection<BookAuthor> BookAuthors { get; set; }

	}
}

