using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskService.Entities;
using TaskService.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        private TodoDb TodoDb { get; set; }

        public TodoController(TodoDb taskDb)
        {
            TodoDb = taskDb;
        }

        // GET: api/Tasks/list/:UserId
        [HttpGet("list/{UserId}")]
        public ActionResult<IEnumerable<Entities.Todo>> Get(int UserId)
        {
            List<Entities.Todo>? tasks;
            if (TodoDb.Todos.TryGetValue(UserId, out tasks) && tasks != null)
            { 
                return tasks; 
            } else {
                TodoDb.Todos[UserId] = new List<Entities.Todo>();
                return Ok(TodoDb.Todos[UserId]);
            }
        }

        // POST api/Tasks/create
        [HttpPost("create/{UserId}")]
        public ActionResult<Entities.Todo> CreateTask(int UserId, TodoCreate task)
        {
            List<Entities.Todo>? tasks;
            if (!TodoDb.Todos.TryGetValue(UserId, out tasks) || tasks == null)
            {
                tasks = new List<Entities.Todo>();
                TodoDb.Todos[UserId] = tasks;
            }
            var index = 0;
            if (tasks.Count > 0)
            {
                index = tasks.Max(t => t.Id) + 1;
            }

            var NewTask = new Entities.Todo
            {
                Id = index,
                IsDone = task.IsDone,
                Text = task.Text
            };

            TodoDb.Todos[UserId].Add(NewTask);
            return Ok(NewTask);
        }

        // PUT api/Tasks/5
        [HttpPut("update/{UserId}/{id}")]
        public ActionResult<Entities.Todo> Put(int UserId, int id, TodoCreate taskUpdate)
        {
            List<Entities.Todo>? tasks;
            if (!TodoDb.Todos.TryGetValue(UserId, out tasks) || tasks == null)
            {
                tasks = new List<Todo>();
                TodoDb.Todos[UserId] = tasks;
            }
            var task = tasks.Find(t => t.Id == id);
            if(task == null)
            {
                return NotFound();
            }
            task.Text = taskUpdate.Text;
            task.IsDone = taskUpdate.IsDone;

            return Ok(task);
        }

        // DELETE api/Tasks/5
        [HttpDelete("delete/{UserId}/{id}")]
        public ActionResult<bool> Delete(int UserId, int id)
        {
            List<Entities.Todo>? tasks;
            if (!TodoDb.Todos.TryGetValue(UserId, out tasks) || tasks == null)
            {
                tasks = new List<Todo>();
                TodoDb.Todos[UserId] = tasks;
            }
            var index = tasks.FindIndex(t => t.Id == id);
            if(index == -1)
            {
                return NotFound();
            }
            tasks.RemoveAt(index);
            return Ok(true);
        }
    }
}
