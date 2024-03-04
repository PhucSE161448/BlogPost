using BlogPostBO.Model;
using BlogPostService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment2PRN221_BlogPost.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogService blogService;

        public List<BlogPost> Blogs { get; set; }
        public List<Tag> Tags { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlogService _blog)
        {
            _logger = logger;
            blogService = _blog;
        }

        public async Task<IActionResult> OnGet()
        {
            Blogs = await blogService.GetAll();
            return Page();
        }
    }
}