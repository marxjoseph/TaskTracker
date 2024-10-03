using Microsoft.AspNetCore.Mvc;
using Models;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : Controller
{
    [HttpGet]
    public IEnumerable<TodoItem> GetTodoListAsync([FromServices] TodoRepository todoRepository)
    {
        return todoRepository.GetTodoList();
    }

    [HttpPost]
    public void Post([FromBody] TodoItem todoItem, [FromServices] TodoRepository todoRepository)
    {
        todoRepository.AddTodoItem(todoItem);
    }

    [HttpDelete("{itemName}")]
    public void DeleteAsync(string itemName, [FromServices] TodoRepository todoRepository)
    {
        todoRepository.DeleteTodoItem(itemName);
    }
}
