using System.ComponentModel.DataAnnotations;

namespace BlazorCrudApplication.Client.Model
{
    public class BookDetailsModel
    {
        [Key]
        public int Id { get; set; }
        public string? BookName { get; set; } = "Abc";
        public string? AuthorName { get; set; } = "Cde";
        public string? UploadBook { get; set; } = "Xyz";
        public List<string>? BookTags { get; set; } = new List<string>();
   
    }
}
