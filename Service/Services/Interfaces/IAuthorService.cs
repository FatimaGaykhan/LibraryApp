using System;
using Service.DTOs.Author;

namespace Service.Services.Interfaces
{
	public interface IAuthorService
	{
		Task CreateAsync(AuthorCreateDto model);
		Task<IEnumerable<AuthorDto>> GetAllAsync();
		Task<AuthorDto> GetByIdAsync(int? id);
		Task DeleteAsync(int? id);
		Task EditAsync(AuthorEditDto model,int? id);
        Task DeleteBookAsync(int? bookId, int? authorId);
        Task AddToBookAsync(int? bookId, int? authorId);

    }
}

