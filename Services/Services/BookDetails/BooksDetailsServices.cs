using BlazorCrudApplication.Data;
using BlazorCrudApplication.Client.Model;
using BlazorCrudApplication.Client.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudApplication.Services
{
    public class BooksDetailsServices : IBookDetailsService
    {
        private readonly BookDbContext _context;

        public BooksDetailsServices(BookDbContext context)
        {
            _context = context;
        }

        public async Task<BookDetailsModel> Add(BookDetailsModel bookdetailsModel)
        {
            var hardcodedBook = new BookDetailsModel
            {

                BookName = "The Great Gatsby",
                AuthorName = "F. Scott Fitzgerald",
                UploadBook = "great_gatsby.pdf",  // You can use a mock file path or filename
                BookTag = new List<string> { "classic", "fiction", "american" }
            };

            _context.BookDetails.Add(hardcodedBook);
            await _context.SaveChangesAsync();

            return hardcodedBook;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BookDetailsModel>> GetAll()
        {
           return  await _context.BookDetails.ToListAsync();
        }

        public Task<BookDetailsModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookDetailsModel> Update(BookDetailsModel bookDetailsModel)
        {
            throw new NotImplementedException();
        }
    }
}
