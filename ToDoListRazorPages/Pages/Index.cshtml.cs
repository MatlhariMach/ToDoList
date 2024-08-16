using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoListRazorPages.Data;
using ToDoListRazorPages.Models;

namespace ToDoListRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IndexViewModel IndexViewModel { get; set; } = new IndexViewModel();

        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; } = "all";

        [BindProperty(SupportsGet = true)]
        public string Sort { get; set; } = "added-date";

        public async Task OnGetAsync()
        {
            // Retrieve items from the database
            var items = _context.ToDoItems.AsQueryable();

            // Filtering based on completion status
            if (Filter == "completed")
            {
                items = items.Where(i => i.IsCompleted);
            }
            else if (Filter == "pending")
            {
                items = items.Where(i => !i.IsCompleted);
            }

            // Sorting logic
            if (Sort == "due-date")
            {
                items = items.OrderBy(i => i.DueDate);
            }
            else if (Sort == "added-date")
            {
                items = items.OrderBy(i => i.Id);
            }

            // Assign filtered and sorted items to the view model
            IndexViewModel.ToDoItems = await items.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
               
                return Page();
            }

            _context.ToDoItems.Add(IndexViewModel.NewToDoItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

         public async Task<IActionResult> OnPostEditAsync(int id, ToDoItem updatedItem)
        {
            var item = await _context.ToDoItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Description = updatedItem.Description;
            item.DueDate = updatedItem.DueDate;

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var itemToDelete = await _context.ToDoItems.FindAsync(id);

            if (itemToDelete == null)
            {
                return NotFound();
            }

            _context.ToDoItems.Remove(itemToDelete);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostToggleCompletionAsync(int Id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(Id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            toDoItem.IsCompleted = !toDoItem.IsCompleted;
            toDoItem.CompletedDate = toDoItem.IsCompleted ? DateTime.Now : (DateTime?)null;

            _context.Attach(toDoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
