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

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsModel>> GetBookDetailsById(int id)
        {
            try
            {
                // Fetch book details by ID
                var bookDetails = await _bookDetailsService.GetById(id);

                // If no book is found, return NotFound (404)
                if (bookDetails == null)
                {
                    return NotFound(); // This will return a 404 status code
                }

                // Return the book details with a 200 OK status
                return Ok(bookDetails);
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error in case of an exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookById(int id)
        {
            try
            {
                // Fetch book details by ID
                var bookDetails = await _bookDetailsService.Delete(id);

                // If no book is found, return NotFound (404)
                if (bookDetails == null)
                {
                    return NotFound(); // This will return a 404 status code
                }

                // Return the book details with a 200 OK status
                return Ok(bookDetails);
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error in case of an exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookDetailsModel>> UpdateBookDetails(int id, [FromBody] BookDetailsModel bookDetailsModel)
        {
            // Check if the bookDetailsModel is null
            if (bookDetailsModel == null)
            {
                return BadRequest("Invalid book details.");
            }

            // Check if the ID in the URL matches the ID in the request body
            if (id != bookDetailsModel.Id)
            {
                return BadRequest("Book ID mismatch.");
            }

            try
            {
                // Call the service method to update the book details
                var updatedBook = await _bookDetailsService.Update(bookDetailsModel);

                // If no book was found, return a 404
                if (updatedBook == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }

                // Return the updated book details with a 200 OK status
                return Ok(updatedBook);
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that occur during the update
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
