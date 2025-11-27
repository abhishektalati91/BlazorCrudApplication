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

            _context.BookDetails.Add(bookdetailsModel);
            await _context.SaveChangesAsync();

            return bookdetailsModel;
        }

        public async Task<bool> Delete(int id)
        {
            var bookToDelete = await _context.BookDetails.FindAsync(id);
            if (bookToDelete != null)
            {
                _context.BookDetails.Remove(bookToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<List<BookDetailsModel>> GetAll()
        {
            return await _context.BookDetails.ToListAsync();
        }

        public async Task<BookDetailsModel> GetById(int id)
        {
            return await _context.BookDetails
                                 .Where(x => x.Id == id)
                                 .FirstOrDefaultAsync();
        }


        public async Task<BookDetailsModel> Update(BookDetailsModel bookDetailsModel)
        {
            var existingBook = await _context.BookDetails
                                              .FirstOrDefaultAsync(x => x.Id == bookDetailsModel.Id);
            if (existingBook == null)
            {
                throw new ArgumentException("Book not found");  
            }\.loi
            existingBook.BookName = bookDetailsModel.BookName;
            existingBook.AuthorName = bookDetailsModel.AuthorName;
            existingBook.UploadBook = bookDetailsModel.UploadBook;
            existingBook.BookTag = bookDetailsModel.BookTag;
            await _context.SaveChangesAsync();

            return existingBook;
        }

    }
}
