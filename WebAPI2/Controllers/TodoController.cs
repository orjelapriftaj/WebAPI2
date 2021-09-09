using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodo _todo;

        public TodoController(ITodo todo)
        {
            _todo = todo;
        }


        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<Todo>> GetTodos()
        {
            return await _todo.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>>GetTodos(int id)
        {
            return await _todo.Get(id);
        }

        [HttpPost]
        [Authorize]
        public async Task <ActionResult<Todo>>PostTodo([FromBody] Todo todo)
        {
            var newTodo = await _todo.Create(todo);
            return CreatedAtAction(nameof(GetTodos), new { id = newTodo.ID }, newTodo);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult>PutTodos(int id, [FromBody] Todo todo)
        {
            if (id != todo.ID)
            {
                return BadRequest();
            }
            await _todo.Create(todo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task <ActionResult> Delete(int id)
        {
            var todoToDelete = await _todo.Get(id);
            if (todoToDelete == null)
                return NotFound();

            await _todo.Delete(todoToDelete.ID);
            return NoContent();
        }
    }
}
