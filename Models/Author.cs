namespace xRootServices.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public string? Description { get; set; }
        public string? profile_image_url { get; set; }
        public DateTime created_at { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
