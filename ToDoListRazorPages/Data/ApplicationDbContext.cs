using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ToDoListRazorPages.Models;

namespace ToDoListRazorPages.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
