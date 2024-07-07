using System;
using Domain.Common;

namespace Domain.Entities
{
	public class Author:BaseEntity
	{
		public string Name { get; set; }

		public string Surname { get; set; }

		public int Age { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }


    }
}

