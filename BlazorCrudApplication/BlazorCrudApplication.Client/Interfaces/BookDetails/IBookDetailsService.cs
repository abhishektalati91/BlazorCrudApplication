namespace BlazorCrudApplication.Client.Interfaces.BookDetails
{
    using BlazorCrudApplication.Client.Model;
    public interface IBookDetailsService
    {
        Task<BookDetailsModel> AddBookDetails(BookDetailsModel bookdetailsModel);
    }
}
