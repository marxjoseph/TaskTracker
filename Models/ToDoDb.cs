using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace ListWebsite.Models
{
    public class ToDoDb
    {
        private readonly HttpClient HttpClient;
        private List<ToDo> toDos = new List<ToDo>();

        public ToDoDb(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
        public async Task LoadToDoDataAsync()
        {
            try
            {
                var response = await HttpClient.GetAsync("Db.json");
                response.EnsureSuccessStatusCode(); // Ensure response is successful
                var json = await response.Content.ReadAsStringAsync();
                toDos = JsonSerializer.Deserialize<List<ToDo>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to fetch JSON data: {ex.Message}");
            }
        }

        public ToDo[] GetToDos()
        {
            return toDos.ToArray();
        }

        public void AddToDo(ToDo todo)
        {
            todo.Id = toDos.Max(todo => todo.Id) + 1;
            toDos.Add(todo);
        }

        public ToDo GetToDo(int id)
        {
            return toDos.Find(toDo => id == toDo.Id) ?? throw new Exception("Not in To Do List");
        }
        public void UpdateToDo(ToDo newToDo)
        {
            ToDo oldToDo = GetToDo(newToDo.Id);
            oldToDo.Name = newToDo.Name;
            oldToDo.Type = newToDo.Type;
            oldToDo.Priority = newToDo.Priority;
            oldToDo.DueDate = newToDo.DueDate;
        }
        public void DeleteToDo(int id)
        {
            ToDo toDo = GetToDo(id);
            toDos.Remove(toDo);
        }
    }
}