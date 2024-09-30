using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.DTO;
using TodoList.Interface;
using TodoList.Models;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly ITodo todo;
        public ToDoController(ApplicationDbContext context , ITodo todo)
        {
            this.context = context;
            this.todo = todo;
        }

        [HttpGet]
        public Task<IEnumerable<ToDo>> GetAllToDo()
        {
            return todo.GetTodo();
        }
        [HttpPost]
        public Task<TodoDto> Create(TodoDto todoDto)
        {
            return todo.CreateTodo(todoDto);
        }
        [HttpPut]

        public Task<TodoDto> Update(ToDo todoUpdate)
        {
            return todo.UpdateTodo(todoUpdate);
        }
        [HttpDelete]
        [Route("{id}")]
        public Task<string> Delete(int id)
        {
            return todo.DeleteTodo(id);
        }
        [HttpGet]
        [Route("{id}")]
        public Task<IEnumerable<ToDo>> GetById(int id)
        {
            return todo.GetTodoById(id);
        }
    }
}
