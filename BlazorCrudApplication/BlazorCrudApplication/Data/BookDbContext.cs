// File: Data/BookDbContext.cs
using Microsoft.EntityFrameworkCore;  // Add this line
using BlazorCrudApplication.Client.Model;  // Ensure this is correct

namespace BlazorCrudApplication.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        public DbSet<BookDetailsModel> Books { get; set; } // Table for BookDetailsModel
    }
}
