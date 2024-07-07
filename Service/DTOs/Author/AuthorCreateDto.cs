using System;
using FluentValidation;
using Service.DTOs.Book;

namespace Service.DTOs.Author
{
	public class AuthorCreateDto
	{
		public string Name { get; set; }

		public string Surname { get; set; }

		public int Age { get; set; }

	}

    public class AuthorCreateDtoValidator : AbstractValidator<AuthorCreateDto>
    {
        public AuthorCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age is required");

        }
    }
}

