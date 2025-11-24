using BlazorCrudApplication.Client.Model;
using System.Threading.Tasks;

namespace BlazorCrudApplication.Client.Interfaces
{
    public interface IBookDetailsService
    {
        Task<BookDetailsModel> Add(BookDetailsModel bookDetailsModel);
        Task<List<BookDetailsModel>> GetAll();
        Task<BookDetailsModel> GetById(int id);
        Task<BookDetailsModel> Update(BookDetailsModel bookDetailsModel);
        Task<bool> Delete(int id);
    }
}
