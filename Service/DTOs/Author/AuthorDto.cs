﻿using System;
namespace Service.DTOs.Author
{
	public class AuthorDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public int Age { get; set; }

		public string CreatedDate { get; set; }


		public List<string> Books { get; set; }

	}
}

