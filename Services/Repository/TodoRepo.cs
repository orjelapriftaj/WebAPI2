using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class TodoRepo:ITodo
    {
        private readonly ApplicationContext _context;

        public TodoRepo(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Todo> Create(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task Delete(int id)
        {
            var todoToDelete = await _context.Todos.FindAsync(id);
            _context.Todos.Remove(todoToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Todo> Get(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<IEnumerable<Todo>> Get()
        {
           return await _context.Todos.ToListAsync();
        }

        public async Task Update(Todo todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }










        //public Todo AddTodo(Todo todo)
        //{
        //    _context.Todos.Add(todo);
        //    _context.SaveChanges();
        //    return todo;
        //}

        //public List<Todo> GetTodos()
        //{
        //    return _context.Todos.ToList();
        //}




    }
}
