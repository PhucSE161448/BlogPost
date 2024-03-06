using Assignment2PRN221_BlogPost.ViewModels;
using BlogPostBO.Enums;
using BlogPostBO.Model;
using BlogPostService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Assignment2PRN221_BlogPost.Pages.Admin.Users
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddUserModel AddUserModelRequest { get; set; }

        private readonly IAccountService service;

        public AddModel(IAccountService _service) => service = _service;
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var acc = new Account()
            {
                Email = AddUserModelRequest.Email,
                Name = AddUserModelRequest.Name,
                Password = AddUserModelRequest.Password,
                Role = AddUserModelRequest.Role,
            };
            await service.AddAccount(acc);

            var noti = new Notification
            {
                Type = NotificationType.Success,
                Message = "New Account Created !"
            };
            TempData["Notification"] = JsonSerializer.Serialize(noti);
            return RedirectToPage("/Admin/Users/List");
        }
    }
}
