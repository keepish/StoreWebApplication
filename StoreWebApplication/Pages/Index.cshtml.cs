using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StoreWebApplication.Models;

namespace StoreWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly StoreWebApplication.Contexts.Ispp2108Context _context;

        public IndexModel(StoreWebApplication.Contexts.Ispp2108Context context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; } = default!;

        public string UserRole { get; set; }
        public string UserName { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            UserRole = HttpContext.Session.GetString("UserRole");

            if (string.IsNullOrWhiteSpace(UserRole))
                return RedirectToPage("Login");

            UserName = HttpContext.Session.GetString("UserName");


            Product = await _context.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Supplier).ToListAsync();

            return Page();
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("./Index");
        }
    }
}
