using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StoreWebApplication.Models;

namespace StoreWebApplication.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly StoreWebApplication.Contexts.Ispp2108Context _context;

        public IndexModel(StoreWebApplication.Contexts.Ispp2108Context context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Supplier).ToListAsync();
        }
    }
}
