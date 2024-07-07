using System;
using Service.DTOs.Book;

namespace Service.Services.Interfaces
{
	public interface IBookService
	{
		Task CreateAsync(BookCreateDto model);

		Task<IEnumerable<BookDto>> GetAllAsync();

		Task<BookDto> GetByIdAsync(int? id);

		Task DeleteAsync(int? id);

		Task EditAsync(BookEditDto model, int? id);
	}
}

