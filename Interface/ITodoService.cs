using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Model;

namespace TodoAPI.Interface
{
    public interface ITodoService
    {
        Task <bool> addTodo(Todo todo);
        Task <List<Todo>> getTodoList();
        
    }
}