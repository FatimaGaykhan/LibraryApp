using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Author;
using Service.Services;
using Service.Services.Interfaces;

namespace LibraryApp.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AuthorCreateDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _authorService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { Response = "Succesfull" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _authorService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _authorService.GetByIdAsync(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _authorService.DeleteAsync((int)id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromBody] AuthorEditDto request, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _authorService.EditAsync(request,id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromQuery] int bookId, [FromQuery] int authorId)
        {
            await _authorService.AddToBookAsync(bookId, authorId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook([FromQuery] int bookId, [FromQuery] int authorId)
        {
            await _authorService.DeleteBookAsync(bookId, authorId);
            return Ok();
        }
    }
}

