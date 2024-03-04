using BlogPostBO.Model;
using BlogPostService.Interface;
using BlogPostService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Assignment2PRN221_BlogPost.ViewModels;
using BlogPostBO.Enums;
using System.Text.Json;
using System;

namespace Assignment2PRN221_BlogPost.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogService blogService;
        [BindProperty]
        public BlogPost BlogPost { get; set; }
        public EditModel (IBlogService blog) => blogService = blog;
        public async Task OnGet(int id)
        {
            BlogPost = await blogService.GetBlogPostsByFilter(x => x.Id == id);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                await blogService.EditBlogPost(BlogPost);

                ViewData["Notification"] = new Notification
                {
                    Message = "Record Updated Successfully !",
                    Type = NotificationType.Success
                };
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something Went Wrong !" + ex,
                    Type = NotificationType.Error
                };
            }
           
            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var blog = await blogService.DeleteBlogPost(BlogPost.Id);
            if(blog)
            {
                var notification = new Notification
                {
                    Type = NotificationType.Success,
                    Message = "Blog was deleted successfully!"
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Admin/Blogs/List");
            }
            return Page();
        }
    }
}
