using System.ComponentModel.DataAnnotations;

namespace Models;

public class TodoItem
{
    [Required(ErrorMessage = "Item name is required.")]
    public string ItemName { get; set; }
    public int Priority { get; set; }
    public DateTime? DateDue { get; set; }

    public TodoItem(string itemName, int priority, DateTime? dateDue)
    {
        ItemName = itemName;
        Priority = priority;
        DateDue = dateDue;
    }

    public TodoItem()
    {
        ItemName = "";
        Priority = 0;
        DateDue = null;

    }
}
