using BlazorCrudApplication.Client.Interfaces;
using BlazorCrudApplication.Client.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailController : ControllerBase
    {
        private readonly IBookDetailsService _bookDetailsService;
        public BookDetailController(IBookDetailsService bookDetailsService)
        {
            _bookDetailsService = bookDetailsService;
        }

        [HttpPost]
        public async Task<ActionResult<BookDetailsModel>> AddBookDetails(BookDetailsModel bookDetailsModel)
        {
            if (bookDetailsModel == null)
            {
                return BadRequest("Invalid book details.");
            }

            try
            {
                var addedBook = await _bookDetailsService.Add(bookDetailsModel);
                return CreatedAtAction(nameof(AddBookDetails), new { id = addedBook.Id }, addedBook);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]

        public async Task<ActionResult<List<BookDetailsModel>>> GetAllBookDetails()
        {
            try
            {
                var getAllBookDetails = await _bookDetailsService.GetAll();
                return getAllBookDetails;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

    }
}
