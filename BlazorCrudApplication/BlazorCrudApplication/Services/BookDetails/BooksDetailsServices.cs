using BlazorCrudApplication.Client.Interfaces.BookDetails;
using BlazorCrudApplication.Client.Model;
using BlazorCrudApplication.Data;


namespace BlazorCrudApplication.Services.BookDetails
{
    public class BooksDetailsServices : IBookDetailsService
    {
        private readonly BookDbContext _context;

        public BooksDetailsServices(BookDbContext context)
        {
            _context = context;
        }

        public async Task<BookDetailsModel> AddBookDetails(BookDetailsModel bookdetailsModel)
        {
            if (bookdetailsModel == null)
            {
                throw new ArgumentNullException(nameof(bookdetailsModel));
            }

            _context.Books.Add(bookdetailsModel); // Add the new book to the DbSet
            await _context.SaveChangesAsync(); // Save changes to the database

            return bookdetailsModel; // Optionally return the added book details
        }
    }
}
