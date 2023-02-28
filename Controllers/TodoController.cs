using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Interface;
using TodoAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController:ControllerBase
    {
        private ITodoService _TodoService;
    
        public TodoController(ITodoService TodoService)
        {
            _TodoService = TodoService;
        }

        [HttpPost]
        public async Task <IActionResult> addTodo([FromBody] Todo todo)
        {
            var checkAdd = _TodoService.addTodo(todo);
            return Ok(checkAdd);
        }


        [HttpGet]
        public async Task <IActionResult> GetTodoList()
        {
            var todoList = _TodoService.getTodoList();
            return Ok(todoList);
        }
    
    }
}