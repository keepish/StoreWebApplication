using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreWebApplication.Models;

namespace StoreWebApplication.Pages
{
    public class LoginModel : PageModel
    {
        private readonly StoreWebApplication.Contexts.Ispp2108Context _context;

        public LoginModel(StoreWebApplication.Contexts.Ispp2108Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostLoginAsync()
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == User.Login);

            if (user != null && user.Password == User.Password)
            {
                HttpContext.Session.SetString("UserRole", user.Role);
                HttpContext.Session.SetString("UserName", user.FullName);
                //return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }

        public IActionResult OnPostGuestAsync()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("UserRole", "Guest");
            return RedirectToPage("./Index");
        }
    }
}
