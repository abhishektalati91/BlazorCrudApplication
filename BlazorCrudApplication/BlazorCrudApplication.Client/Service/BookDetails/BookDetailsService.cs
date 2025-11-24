using BlazorCrudApplication.Client.Interfaces;
using BlazorCrudApplication.Client.Model;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorCrudApplication.Client.Service.BookDetails
{
    public class BookDetailsService : IBookDetailsService
    {
        private readonly HttpClient _httpClient;

        // Constructor to inject HttpClient
        public BookDetailsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Method to add book details
        public async Task<BookDetailsModel> Add(BookDetailsModel bookdetailsModel)
        {
            try
            {
                // Send the POST request
                var response = await _httpClient.PostAsJsonAsync("api/BookDetail", bookdetailsModel);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // If successful, deserialize the response content and return it
                    var result = await response.Content.ReadFromJsonAsync<BookDetailsModel>();
                    return result; // Return the deserialized object
                }
                else
                {
                    // Log the error or throw an exception as needed
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return null; // Return null in case of failure
                }
            }
            catch (Exception ex)
            {
                // Log or handle any exceptions that occur
                Console.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task<List<BookDetailsModel>> GetAll()
        {

                try
                {
                    // Send the Get request
                    var response = await _httpClient.GetAsync("api/BookDetail");

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                    var books = await response.Content.ReadFromJsonAsync<List<BookDetailsModel>>();
                    return books ?? new List<BookDetailsModel>(); // 
                }
                    else
                    {
                        // Log the error or throw an exception as needed
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        return null; // Return null in case of failure
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle any exceptions that occur
                    Console.WriteLine($"Exception: {ex.Message}");
                    return null;
                }

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
