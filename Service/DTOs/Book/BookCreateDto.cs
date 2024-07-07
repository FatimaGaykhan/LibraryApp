using System;
using FluentValidation;

namespace Service.DTOs.Book
{
	public class BookCreateDto
	{
		public string Name { get; set; }

        public List<int> AuthorIds { get; set; }

    }

    public class BookCreateDtoValidator : AbstractValidator<BookCreateDto>
    {
        public BookCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");

        }
    }
}

