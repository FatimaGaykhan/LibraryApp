using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Book;
using Service.Services.Interfaces;

namespace LibraryApp.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]BookCreateDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _bookService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), new { Response = "Successfull" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _bookService.GetByIdAsync(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _bookService.DeleteAsync((int)id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromBody] BookEditDto request, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _bookService.EditAsync(request,id);
            return Ok();
        }

        
    }
}

