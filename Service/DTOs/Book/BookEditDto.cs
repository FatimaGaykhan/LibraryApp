using System;
using FluentValidation;

namespace Service.DTOs.Book
{
	public class BookEditDto
	{
		public string Name { get; set; }


	}
    public class BookEditDtoValidator : AbstractValidator<BookEditDto>
    {
        public BookEditDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");

        }
    }
}

