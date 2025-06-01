namespace xRootServices.Models.ViewModels
{
    public class BlogListItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string? CoverImageUrl { get; set; }
        public DateTime? DatePublished { get; set; }
    }
    public class BlogListViewModel
    {
        public List<BlogListItemViewModel> Blogs { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }

}
