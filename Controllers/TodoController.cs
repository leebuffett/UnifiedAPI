using Microsoft.AspNetCore.Mvc;
using TodoAPI.Interface;
using TodoAPI.Model;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private ITodoService _TodoService;

        public TodoController(ITodoService TodoService)
        {
            _TodoService = TodoService;
        }

        [HttpPost]
        public async Task<IActionResult> addTodo([FromBody] Todo todo)
        {
            var checkAdd = await _TodoService.addTodo(todo);
            return Ok(checkAdd);
        }


        [HttpGet]
        public async Task<IActionResult> GetTodoList()
        {
            var todoList = await _TodoService.getTodoList();
            return Ok(todoList);
        }

    }
}