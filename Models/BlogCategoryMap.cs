namespace xRootServices.Models
{
    public class BlogCategoryMap
    {
        public int BlogId { get; set; }
        public int CategoryId { get; set; }

        public Blog Blog { get; set; }
        public BlogCategory BlogCategory { get; set; }
    }
}
