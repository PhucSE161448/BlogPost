using Assignment2PRN221_BlogPost.ViewModels;
using BlogPostBO.Enums;
using BlogPostBO.Model;
using BlogPostService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Assignment2PRN221_BlogPost.Pages.Admin.Users
{
    public class EditModel : PageModel
    {
        private readonly IAccountService service;
        [BindProperty]
        public Account account { get; set; }

        public EditModel(IAccountService _service) => service = _service;
        public async Task OnGet(int id)
        {
            account = await service.GetAccountById(id);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                
                await service.EditAccount(account);

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
            var acc = await service.DeleteAccount(account.Id);
            if (acc)
            {
                var notification = new Notification
                {
                    Type = NotificationType.Success,
                    Message = "User was deleted successfully!"
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Admin/Users/List");
            }
            return Page();
        }

    }
}
