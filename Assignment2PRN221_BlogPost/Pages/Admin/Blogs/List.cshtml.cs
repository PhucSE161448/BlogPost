using Assignment2PRN221_BlogPost.ViewModels;
using BlogPostBO.Model;
using BlogPostService;
using BlogPostService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Assignment2PRN221_BlogPost.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly IBlogService blogService;
        public List<BlogPost> Blogs { get; set; }
        public ListModel(IBlogService blog) => blogService = blog;
        public async Task OnGet()
        {
            var noti = (string)TempData["Notification"];
            if(noti != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(noti);
            }
            Blogs = await blogService.GetAll();
        }
    }
}
