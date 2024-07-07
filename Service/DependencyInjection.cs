using System;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Service.DTOs.Account;
using Service.DTOs.Author;
using Service.DTOs.Book;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;

namespace Service
{
	public static class DependencyInjection
	{
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });

            services.AddScoped<IValidator<BookCreateDto>, BookCreateDtoValidator>();
            services.AddScoped<IValidator<BookEditDto>, BookEditDtoValidator>();

            services.AddScoped<IValidator<AuthorCreateDto>, AuthorCreateDtoValidator>();
            services.AddScoped<IValidator<AuthorEditDto>, AuthorEditDtoValidator>();



            services.AddScoped<IValidator<RegisterDto>, RegisterDtoValidator>();



            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IAccountService, AccountService>();



            return services;


        }
    }
}

