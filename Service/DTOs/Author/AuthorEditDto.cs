using System;
using FluentValidation;

namespace Service.DTOs.Author
{
	public class AuthorEditDto
	{
		public string Name { get; set; }

		public string Surname { get; set; }

		public int Age { get; set; }

	}

    public class AuthorEditDtoValidator : AbstractValidator<AuthorEditDto>
    {
        public AuthorEditDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age is required");

        }
    }
}

