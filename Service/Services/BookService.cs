using System;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.DTOs.Book;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class BookService:IBookService
	{
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;

		public BookService(IBookRepository bookRepo,
                           IMapper mapper)
		{
            _bookRepo = bookRepo;
            _mapper = mapper;
		}

        public async Task CreateAsync(BookCreateDto model)
        {
            if (model is null) throw new ArgumentNullException();

            Book book = _mapper.Map<Book>(model);

            List<BookAuthor> bookAuthors = new();

            foreach (var authorId in model.AuthorIds)
            {
                bookAuthors.Add(new BookAuthor { BookId = book.Id, AuthorId = authorId });
            }

            book.BookAuthors = bookAuthors;


            await _bookRepo.CreateAsync(book);

        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            var existBook = await _bookRepo.GetById((int)id);

            if (existBook is null) throw new NullReferenceException();

            await _bookRepo.DeleteAsync(existBook);
        }

        public async Task EditAsync(BookEditDto model, int? id)
        {
            if (id is null) throw new ArgumentNullException();

            var existBook = await _bookRepo.GetById((int)id);

            if (existBook is null) throw new NullReferenceException();

            await _bookRepo.EditAsync(_mapper.Map(model, existBook));
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<BookDto>>(await _bookRepo.Find(source=>source.Include(m=>m.BookAuthors).ThenInclude(m=>m.Author)).ToListAsync());
        }

        public async Task<BookDto> GetByIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            var existBook = await _bookRepo.GetById((int)id);

            if (existBook is null) throw new NullReferenceException();

            var book =  await _bookRepo.FindBy(m => m.Id == id, source => source.Include(m => m.BookAuthors)
                                                               .ThenInclude(m => m.Author))
                                                                .FirstOrDefaultAsync();
            return _mapper.Map<BookDto>(book);
        }
    }
}

