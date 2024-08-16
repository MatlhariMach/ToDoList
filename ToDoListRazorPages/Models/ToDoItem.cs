using System.ComponentModel.DataAnnotations;

namespace ToDoListRazorPages.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; } //created Date

        public DateTime? CompletedDate { get; set; }

        public bool IsCompleted { get; set; }
    }

  /*  public enum PriorityLevel
    {
        Low,
        Medium,
        High
    } */
}

