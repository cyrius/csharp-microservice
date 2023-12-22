using GatewayService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GatewayService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        HttpClient client;
        public TodoController()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:5002/");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetMyTaskAsync()
        {
            var UserId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            if (UserId == null) return Unauthorized();

            HttpResponseMessage response = await client.GetAsync($"api/Todo/list/{UserId}");
            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);

            // Check if the response status code is 2XX
            if (response.IsSuccessStatusCode)
            {
                var tasks = await response.Content.ReadFromJsonAsync<Entities.Todo[]>();
                //var tasks = JsonSerializer.Deserialize<Entities.Task[]>(json);
                return Ok(tasks);
            }
            else
            {
                return BadRequest("GetMyTaskAsync failed");
            }

        }

        [Authorize]
        [HttpPost("create")]
        public async Task<ActionResult> CreateTask(TodoCreate task)
        {
            var UserId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            if (UserId == null) return Unauthorized();

            HttpResponseMessage response = await client.PostAsJsonAsync($"api/Todo/create/{UserId}", task);

            // Check if the response status code is 2XX
            if (response.IsSuccessStatusCode)
            {
                var newTask = await response.Content.ReadFromJsonAsync<Entities.Todo>();
                return Ok(newTask);
            }
            else
            {
                return BadRequest("CreateTask failed");
            }
            // Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJDeXJpdXMiLCJVc2VySWQiOiIxIiwibmFtZSI6IkN5cml1cyIsImV4cCI6MTcwMzIwMDUwMSwiaXNzIjoiWW91cklzc3VlciIsImF1ZCI6IllvdXJBdWRpZW5jZSJ9.xIuvzZ8UhPvClf5gP1GY33N-JrMSBUdrtQ6lvTnRJ0I
        }
        
        [Authorize]
        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateTask(int id, TodoCreate task)
        {
            var UserId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            if (UserId == null) return Unauthorized();

            HttpResponseMessage response = await client.PutAsJsonAsync($"api/Todo/update/{UserId}/{id}", task);

            // Check if the response status code is 2XX
            if (response.IsSuccessStatusCode)
            {
                var newTask = await response.Content.ReadFromJsonAsync<Entities.Todo>();
                return Ok(newTask);
            }
            else
            {
                return BadRequest("UpdateTask failed");
            }

        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var UserId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            if (UserId == null) return Unauthorized();

            HttpResponseMessage response = await client.DeleteAsync($"api/Todo/delete/{UserId}/{id}");

            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);
            // Check if the response status code is 2XX
            if (response.IsSuccessStatusCode)
            {
                string str = await response.Content.ReadAsStringAsync();
                if (str == "true")
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            else
            {
                return BadRequest("UpdateTask failed");
            }
        }
    }
}
