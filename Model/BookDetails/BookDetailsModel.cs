using System.ComponentModel.DataAnnotations;

namespace BlazorCrudApplication.Client.Model
{
    public class BookDetailsModel
    {
        [Key]
        public int Id { get; set; }
        public string? BookName { get; set; } 
        public string? AuthorName { get; set; } 
        public string? UploadBook { get; set; } 
        public List<string>? BookTag { get; set; } = new List<string>();
    }
}
