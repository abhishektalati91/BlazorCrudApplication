namespace BlazorCrudApplication.Client.Model
{
    public class BookDetailsModel
    {
        public int Id { get; set; }
        public string? BookName { get; set; }
        public string? AuthorName { get; set; }
        public string? UploadBook { get; set; }
        public List<string> BookTags { get; set; } = new List<string>();
    }
}
