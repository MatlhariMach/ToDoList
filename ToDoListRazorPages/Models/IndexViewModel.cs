namespace ToDoListRazorPages.Models
{
    public class IndexViewModel
    {
        public IEnumerable<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
        public ToDoItem NewToDoItem { get; set; } = new ToDoItem();
    }
}
