using Assignment2PRN221_BlogPost.ViewModels;
using BlogPostBO.Enums;
using BlogPostBO.Model;
using BlogPostService;
using BlogPostService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Assignment2PRN221_BlogPost.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddBlogModel AddBlogModelRequest { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        private readonly IBlogService blogService;

        public AddModel(IBlogService blog) => blogService = blog;
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var blog = new BlogPost()
            {
                Heading = AddBlogModelRequest.Heading,
                Content = AddBlogModelRequest.Content,
                PageTitle = AddBlogModelRequest.PageTitle,
                ShortDescription = AddBlogModelRequest.ShortDescription,
                ImageUrl = AddBlogModelRequest.ImageUrl,
                UrlHandle = AddBlogModelRequest.UrlHandle,
                PublishedDate = AddBlogModelRequest.PublishedDate,
                AccountId = 1,
                Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag
                {
                    Name = x.Trim()
                }))
            };
            await blogService.AddBlogPost(blog);

            var noti = new Notification
            {
                Type = NotificationType.Success,
                Message = "New Blog Post Created !"
            };
            TempData["Notification"] = JsonSerializer.Serialize(noti);
            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
