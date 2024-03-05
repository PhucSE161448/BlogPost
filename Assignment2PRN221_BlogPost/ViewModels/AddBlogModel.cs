namespace Assignment2PRN221_BlogPost.ViewModels
{
    public class AddBlogModel
    {
        public int AccountId { get; set; }
        public string Heading { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
