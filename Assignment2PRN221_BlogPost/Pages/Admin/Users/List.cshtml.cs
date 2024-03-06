using Assignment2PRN221_BlogPost.ViewModels;
using BlogPostBO.Model;
using BlogPostService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Assignment2PRN221_BlogPost.Pages.Admin.Users
{
    public class ListModel : PageModel
    {
        private readonly IAccountService service ;
        public List<Account> accounts { get; set; }
        public ListModel(IAccountService _service) => service = _service;
        public async Task OnGet()
        {
            var noti = (string)TempData["Notification"];
            if (noti != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(noti);
            }
            accounts = await service.GetAll();
        }
    }
}
