
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MovieReview.Models;

namespace MovieReview.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }
        public async Task<IActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();
            return LocalRedirect("/");
        }
        public async Task<IActionResult> OnPost()
        {
            await _signInManager.SignOutAsync();
            return LocalRedirect("/");
        }
    }
}
