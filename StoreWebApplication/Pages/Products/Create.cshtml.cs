using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreWebApplication.Contexts;
using StoreWebApplication.Models;

namespace StoreWebApplication.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly StoreWebApplication.Contexts.Ispp2108Context _context;

        public CreateModel(StoreWebApplication.Contexts.Ispp2108Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Id");
        ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
