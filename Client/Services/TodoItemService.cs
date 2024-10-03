using System.Net.Http.Json;
using Models;

namespace Client.Services;

public class TodoItemService(HttpClient httpClient)
{
    public async Task<IEnumerable<TodoItem>> GetTodoList()
    {
        return await httpClient.GetFromJsonAsync<List<TodoItem>>("api/Todo");
    }
    public async Task SaveNewTodoItem(TodoItem todoItem)
    {
        await httpClient.PostAsJsonAsync("api/Todo", todoItem);
    }
    public async Task DeleteTodoItem(string todoItemName)
    {
        await httpClient.DeleteAsync($"api/Todo/{todoItemName}");
    }
}
