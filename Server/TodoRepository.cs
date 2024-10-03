using System.Text.Json;
using Models;

namespace Server;

public class TodoRepository
{
    private readonly List<TodoItem> _todoList = new List<TodoItem>();
    private readonly string _jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "todoList.json");

    public TodoRepository()
    {
        // Read from the JSON file if it exists
        if (File.Exists(_jsonFilePath))
        {
            var jsonData = File.ReadAllText(_jsonFilePath);
            _todoList = JsonSerializer.Deserialize<List<TodoItem>>(jsonData) ?? new List<TodoItem>();
        }
        else
        {
            // Add default list if the file doesn't exist
            _todoList.Add(new TodoItem("Shop", 8, new DateTime(2003, 2, 24)));
            _todoList.Add(new TodoItem("Work", 9, new DateTime(2004, 4, 20)));
            SaveToFile(); // Save initial data to file
        }
    }

    public IEnumerable<TodoItem> GetTodoList()
    {
        return _todoList;
    }

    public void AddTodoItem(TodoItem todoItem)
    {
        _todoList.Add(todoItem);
        SaveToFile(); // Save changes to the file
    }

    public void DeleteTodoItem(string itemName)
    {
        _todoList.RemoveAll(todoItem => todoItem.ItemName == itemName);
        SaveToFile(); // Save changes to the file
    }

    private void SaveToFile()
    {
        // Convert the list to JSON and write it to the file
        var jsonData = JsonSerializer.Serialize(_todoList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_jsonFilePath, jsonData);
    }
}
