using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTutorial.Pages
{
    public class TodoListBase : ComponentBase
    {
        protected string todoItem { get; set; } = string.Empty;
        protected List<string> TodoList = new List<string>();

        protected void AddTodo()
        {
            if (!string.IsNullOrEmpty(todoItem))
                TodoList.Add(todoItem);

            todoItem = string.Empty;
        }
    }
}
