using Assignment2PRN221_BlogPost.ViewModels;
using BlogPostBO.Enums;
using BlogPostBO.Model;
using BlogPostService.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Assignment2PRN221_BlogPost.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Register RegisterViewModel { get; set; }
        private readonly IAccountService _service;

        public RegisterModel(IAccountService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = new Account()
                {
                    Name = RegisterViewModel.Name,
                    Email = RegisterViewModel.Email,
                    Password = RegisterViewModel.Password,
                    Role = "User"
                };
                var addRolesResult = await _service.AddAccount(user);

                if (addRolesResult)
                {
                    ViewData["Notification"] = new Notification
                    {
                        Type = NotificationType.Success,
                        Message = "User registered successfully."
                    };

                    return Page();
                }
                ViewData["Notification"] = new Notification
                {
                    Type = NotificationType.Error,
                    Message = "Something went wrong."
                };
                return Page();
            }
            else
            {
                return Page();
            }

        }
    }
}
