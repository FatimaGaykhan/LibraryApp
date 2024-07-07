using System;
using AutoMapper;
using Domain.Entities;
using Service.DTOs.Account;
using Service.DTOs.Author;
using Service.DTOs.Book;

namespace Service.Helpers
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
            CreateMap<AuthorCreateDto, Author>();
			CreateMap<Author, AuthorDto>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate.ToString("dd.MM.yyyy")))
								.ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.BookAuthors.Select(m => m.Book.Name)));
            CreateMap<AuthorEditDto, Author>();

            CreateMap<BookCreateDto, Book>();
            CreateMap<Book, BookDto>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate.ToString("dd.MM.yyyy")))
                    .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.BookAuthors.Select(m => m.Author.Name)));

            CreateMap<BookEditDto, Book>();


            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, UserDto>();
        }
    }
}

