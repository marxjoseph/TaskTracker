using Newtonsoft.Json;

namespace ListWebsite.Models;

public static class ToDoDb
{
    private static readonly List<ToDo> toDos = new()
    {
        new ToDo()
        {
            Id = 1,
            Name = "2050 Assignment 1",
            Type = "School",
            Priority = 10M,
            DueDate = new DateTime(2024, 2, 24)
        },
        new ToDo()
        {
            Id = 2,
            Name = "Practice Blazor",
            Type = "Work",
            Priority = 7.4M,
            DueDate = new DateTime(2024, 2, 19)
        },
        new ToDo()
        {
            Id = 3,
            Name = "Get Skates",
            Type = "Entertainment",
            Priority = 7.9M,
            DueDate = new DateTime(2024, 2, 18)
        }
    };

    public static ToDo[] GetToDos()
    {
        return toDos.ToArray();
    }

    public static void AddToDo(ToDo todo)
    {
        todo.Id = toDos.Max(todo => todo.Id) + 1;
        toDos.Add(todo);
    }

    public static ToDo GetToDo(int id)
    {
        return toDos.Find(toDo => id == toDo.Id) ?? throw new Exception("Not in To Do List");
    }
    public static void UpdateToDo(ToDo newToDo)
    {
        ToDo oldToDo = GetToDo(newToDo.Id);
        oldToDo.Name = newToDo.Name;
        oldToDo.Type = newToDo.Type;
        oldToDo.Priority = newToDo.Priority;
        oldToDo.DueDate = newToDo.DueDate;
    }
    public static void DeleteToDo(int id)
    {
        ToDo toDo = GetToDo(id);
        toDos.Remove(toDo);
    }
}