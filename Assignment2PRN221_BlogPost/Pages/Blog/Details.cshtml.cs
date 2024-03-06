using BlogPostBO.Model;
using BlogPostService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment2PRN221_BlogPost.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogService blog;
        public BlogPost BlogPost { get; set; }

        public DetailsModel(IBlogService blog)
        {
            this.blog = blog;
        }
        public async Task<IActionResult> OnGet(string urlHandle)
        {
            BlogPost = await blog.GetBlogPostsByFilter(x => x.UrlHandle == urlHandle);
            return Page();
        }

      
    }
}
