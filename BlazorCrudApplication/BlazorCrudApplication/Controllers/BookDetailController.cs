using BlazorCrudApplication.Client.Interfaces.BookDetails;
using BlazorCrudApplication.Client.Model;
using BlazorCrudApplication.Client.Pages.BookManagementSystem;
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
        public async Task<ActionResult<BookDetailsModel>> AddBookDetails(BookDetailsModel bookdetailsModal)
        {
            return null;
            
        }
    }
}
