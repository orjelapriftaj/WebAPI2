using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITodo
    {
        Task<Todo> Get(int id);
        Task<IEnumerable<Todo>> Get();// GET all tasks of employee:List<Todo> GetTodos();
        Task<Todo> Create(Todo todo); //Todo AddTodo(Todo todo);POST 

        Task Update(Todo todo);
        Task Delete(int id);
    }
}
