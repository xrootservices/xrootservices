namespace xRootServices.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string content { get; set; }
        public string? cover_image_url { get; set; }
        public string? meta_keywords { get; set; }
        public string? meta_description { get; set; }
        public int? author_id { get; set; }
        public bool is_published { get; set; }
        public DateTime? date_published { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public Author? Author { get; set; }
        //public ICollection<BlogCategoryMap> BlogCategoryMaps { get; set; }
    }
}
