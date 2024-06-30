using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MovieReview.Models;
using MovieReview.Repos;
using MovieReview.Services;

namespace MovieReview.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserController> _logger;

        public UserController(ApplicationDbContext context, ILogger<UserController> logger, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _context = context;
            _logger = logger;
        }

        [HttpPost]

        public IActionResult Register(string firstName, string lastName, string address)
        {
            // Check if mail already exists
            if (_context.Users.Any(u => u.Address == address))
            {
                ModelState.AddModelError("Email", "Email already exists.");
                return View();
            }

            // Create new user
            var newUser = new ApplicationUser
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address
            };

            // Add user to the database
            _context.Add(newUser);
            _context.SaveChanges();

            // Return new user
            return View("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(string email, string firstname)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _context.Users.FirstOrDefault(u => u.Email == email && u.FirstName == firstname);
                    if (user != null)
                    {
                        // If user found, redirect to home page
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // If user not found, add error to ModelState and return the view
                        ModelState.AddModelError(string.Empty, "Email and/or first name do not match any user.");
                        return View(); // Make sure your view is returned with correct model or data
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception
                    _logger.LogError($"Error logging in: {ex.Message}");

                    ModelState.AddModelError(string.Empty, "Error while you were trying to log in. Please try again later.");
                    return View(); // Make sure your view is returned with correct model or data
                }
            }

            // If ModelState is not valid, return the view with errors
            return View();
        }

        [HttpGet]

        public IActionResult GetProfile(int userId)
        {
            try
            {
                // get user profile from repository
                ApplicationUser profile = _userRepository.GetUserById(userId);

                if (profile == null)
                {
                    // If user not found, return not found page
                    return NotFound();
                }

                // return view with users profile
                return View(profile);
            }
            catch (Exception ex)
            {
                // log the exception
                _logger.LogError($"Error retrieving profile for user ID {userId}: {ex.Message}");

                return StatusCode(500, "A problem occurred while you were trying to find this person.");
            }
        }

    }
}
