using Assignment2PRN221_BlogPost.ViewModels;
using BlogPostBO.Enums;
using BlogPostService.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;

namespace Assignment2PRN221_BlogPost.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login LoginViewModel { get; set; }
        private readonly IAccountService _service;
        public LoginModel(IAccountService service)
        {
            _service = service;
        }
        public IActionResult OnGet()
        {

            if (HttpContext.Session.GetString("loginUser") != null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }
        public async Task<IActionResult> OnPost(string? ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _service.CheckLogin(LoginViewModel.Email, LoginViewModel.Password);

                if (signInResult != null)
                {
                    var loginUser = new AppUser
                    {
                        Id = signInResult.Id,
                        Name = signInResult.Name,
                        Role = signInResult.Role
                    };

                    var loginUserJson = JsonConvert.SerializeObject(loginUser);
                    HttpContext.Session.SetString("loginUser", loginUserJson);
                    if (!string.IsNullOrWhiteSpace(ReturnUrl))
                    {
                        return RedirectToPage(ReturnUrl);
                    }

                    return RedirectToPage("Index");
                }
                else
                {
                    ViewData["Notification"] = new Notification
                    {
                        Type = NotificationType.Error,
                        Message = "Unable to login"
                    };
                    return Page();
                }
            }

            return Page();
        }
    }
}
