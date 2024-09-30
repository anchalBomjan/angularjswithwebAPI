using Dapper;
using TodoList.DTO;
using TodoList.Interface;
using TodoList.Models;

namespace TodoList.Data
{

    public class ToDoRepository:ITodo
    {

        private readonly ApplicationDbContext context;
        private readonly DapperContext dapper;

        public ToDoRepository(ApplicationDbContext context, DapperContext dapper)
        {
            this.context = context;
            this.dapper = dapper;
        }
        public async Task<TodoDto> CreateTodo(TodoDto todo)
        {
            string sql = "insert into ToDos (Title,Content,IsEditing,Done) values(@title,@content,@IsEditing,@Done)";
            using (var connection = dapper.CreateConnection())
            {
                var parameter = new
                {
                    Title = todo.Title,
                    Content = todo.Content,
                    IsEditing = false,
                    Done = false,
                };
                var result = await connection.ExecuteAsync(sql, parameter);
                return new TodoDto
                {
                    Title = todo.Title,
                    Content = todo.Content,
                };
            }
        }

        public async Task<string> DeleteTodo(int id)
        {
            var sql = "delete  from ToDos where Id=@Id";
            using (var connection = dapper.CreateConnection())
            {
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                if (result > 0)
                {
                    return "Deleted Successfully";
                }
                else
                {
                    return "Error while deleting ";
                }
            }
        }

        public async Task<IEnumerable<ToDo>> GetTodo()
        {
            string sql = "select * from ToDos";
            using (var connection = dapper.CreateConnection())
            {
                var result = await connection.QueryAsync<ToDo>(sql);
                return result.ToList();
            }
        }

        public async Task<IEnumerable<ToDo>> GetTodoById(int id)
        {
            string sql = "select * from ToDos where Id=@id";
            using (var connection = dapper.CreateConnection())
            {
                var result = await connection.QueryAsync<ToDo>(sql, new { Id = id });
                return result.ToList();
            }
        }

        public async Task<TodoDto> UpdateTodo(ToDo todoUpdate)
        {
            var sql = "update ToDos set Title=@Title,Content=@Content where Id=@Id";
            using (var connection = dapper.CreateConnection())
            {
                var parameter = new
                {
                    Title = todoUpdate.Title,
                    Content = todoUpdate.Content,
                    Id = todoUpdate.Id,
                };

                await connection.ExecuteAsync(sql, parameter);
                return new TodoDto
                {
                    Title = todoUpdate.Title,
                    Content = todoUpdate.Content
                };

            }
        }


    }
}
