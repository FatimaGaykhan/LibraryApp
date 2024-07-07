using System;
using System.Text.RegularExpressions;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.DTOs.Author;
using Service.DTOs.Book;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class AuthorService:IAuthorService
	{
        private readonly IAuthorRepository _authorRepo;
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;
        private readonly IBookAuthorRepository _bookAuthorRepo;

		public AuthorService(IAuthorRepository authorRepo,
                             IMapper mapper,
                             IBookRepository bookRepo,
                             IBookAuthorRepository bookAuthorRepo)
		{
            _authorRepo = authorRepo;
            _mapper = mapper;
            _bookRepo = bookRepo;
            _bookAuthorRepo = bookAuthorRepo;
		}

        public async Task AddToBookAsync(int? bookId, int? authorId)
        {
            if (bookId is null) throw new ArgumentNullException();

            var existBook = await _bookRepo.FindBy(m => m.Id == bookId, source => source.Include(m => m.BookAuthors).ThenInclude(m => m.Author)).FirstOrDefaultAsync();

            var authors = await _authorRepo.GetAllAsync();

            var author = authors.FirstOrDefault(m => m.Id == authorId);

            if (author is null) throw new NullReferenceException();

            var bookAuthor = new BookAuthor
            {
                BookId = existBook.Id,
                AuthorId = author.Id
            };

            existBook.BookAuthors.Add(bookAuthor);

            await _bookRepo.EditAsync(existBook);
        }

        public async Task CreateAsync(AuthorCreateDto model)
        {
            if (model is null) throw new ArgumentNullException();

            await _authorRepo.CreateAsync(_mapper.Map<Author>(model));
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            var existAuthor = await _authorRepo.GetById((int)id);

            if (existAuthor is null) throw new NullReferenceException();

            await _authorRepo.DeleteAsync(existAuthor);
        }

        public async Task DeleteBookAsync(int? bookId, int? authorId)
        {
            if (bookId is null) throw new ArgumentNullException(nameof(bookId));
            if (authorId is null) throw new ArgumentNullException(nameof(authorId));

            var existBook = await _bookRepo.FindBy(m => m.Id == bookId, source => source.Include(m => m.BookAuthors)).FirstOrDefaultAsync();
            if (existBook == null)
            {
                throw new NullReferenceException("Book not found.");
            }

            var authorBook = existBook.BookAuthors.FirstOrDefault(m => m.AuthorId == authorId);

            if (authorBook == null)
            {
                throw new NullReferenceException("AuthorBook relationship not found.");
            }

            await _bookAuthorRepo.DeleteAsync(authorBook);
        }

        public async Task EditAsync(AuthorEditDto model, int? id)
        {
            if (id is null) throw new ArgumentNullException();

            var existAuthor = await _authorRepo.GetById((int)id);

            if (existAuthor is null) throw new NullReferenceException();

            await _authorRepo.EditAsync(_mapper.Map(model,existAuthor));
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<AuthorDto>>(await _authorRepo.Find(source=>source.Include(m=>m.BookAuthors).ThenInclude(m=>m.Book)).ToListAsync());
        }

        public async Task<AuthorDto> GetByIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            var existAuthor = await _authorRepo.GetById((int)id);

            if (existAuthor is null) throw new NullReferenceException();

            var author = await _authorRepo.FindBy(m => m.Id == id, source => source.Include(m => m.BookAuthors)
                                                               .ThenInclude(m => m.Book))
                                                                .FirstOrDefaultAsync();
            return _mapper.Map<AuthorDto>(author);
        }




    }
}

