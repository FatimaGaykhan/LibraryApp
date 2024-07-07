using System;
namespace Service.DTOs.Book
{
	public class BookDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string CreatedDate { get; set; }

		public List<string> Authors { get; set; }

	}
}

