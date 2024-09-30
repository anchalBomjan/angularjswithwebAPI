using TodoList.DTO;
using TodoList.Models;

namespace TodoList.Interface
{
    public interface ITodo
    {

        public Task<IEnumerable<ToDo>> GetTodo();
        public Task<IEnumerable<ToDo>> GetTodoById(int id);
        public Task<TodoDto> CreateTodo(TodoDto todo);
        public Task<TodoDto> UpdateTodo(ToDo todoUpdate);
        public Task<string> DeleteTodo(int id);


    }
}
