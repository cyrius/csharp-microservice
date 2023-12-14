using Microsoft.AspNetCore.Mvc;
using TaskService.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private List<Entities.Task> _tasks;
        private int _taskIndex = 0;

        public TasksController()
        {
            _tasks = new List<Entities.Task>();
        }

        // GET: api/Tasks
        [HttpGet]
        public IEnumerable<Entities.Task> Get()
        {
            return _tasks;
        }

        // GET api/Tasks/5
        [HttpGet("{id}")]
        public Entities.Task? Get(int id)
        {
            return _tasks.Find(t => t.Id == id);
        }

        // POST api/Tasks
        [HttpPost]
        public void CreateTask(TaskCreate task)
        {
            var index = _taskIndex++;
            _tasks.Add(new Entities.Task
            {
                Id = index,
                IsDone = task.IsDone,
                Text = task.Text
            });
        }

        // PUT api/Tasks/5
        [HttpPut("{id}")]
        public ActionResult<Entities.Task> Put(int id, TaskCreate taskUpdate)
        {
            var task = _tasks.Find(t => t.Id == id);
            if(task == null)
            {
                return NotFound();
            }
            task.Text = taskUpdate.Text;
            task.IsDone = taskUpdate.IsDone;

            return Ok(task);
        }

        // DELETE api/Tasks/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var index = _tasks.FindIndex(t => t.Id == id);
            if(index == -1)
            {
                return NotFound();
            }
            _tasks.RemoveAt(index);
            return Ok(true);
        }
    }
}
