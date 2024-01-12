using Front.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Claims;

namespace Front.Services
{
    public class TodoService
    {
        private readonly HttpClient _httpClient;
        private ProtectedLocalStorage _sessionStorage;

        public TodoService(HttpClient httpClient, ProtectedLocalStorage sessionStorage)
        {
            _httpClient = httpClient;
            _sessionStorage = sessionStorage;
        }

        public async Task<Todo[]> GetAllTasks()
        {
            var jwt = await _sessionStorage.GetAsync<string>("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.Value);
            HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:5000/api/Todo");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Todo[]>();

                return result || [];
            }
            else
            {
                return [];
            }
        }

        public async Task<Todo> CreateNewTask()
        {
            var task = new TodoCreate() { IsDone = false, Text = "Empty" };

            var jwt = await _sessionStorage.GetAsync<string>("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.Value);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("http://localhost:5000/api/Todo/create", task);

            Console.WriteLine(response.Content.ToString());
            Console.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Todo>();

                return result;
            }
            else
            {
                return null;
            }
        }
        public async Task<Todo> UpdateTodo(Todo todo)
        {
            var task = new TodoCreate() { IsDone = todo.IsDone, Text = todo.Text };

            Console.WriteLine($"update todo {todo.Id} {todo.IsDone} {todo.Text}");
            var jwt = await _sessionStorage.GetAsync<string>("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.Value);
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"http://localhost:5000/api/Todo/update/{todo.Id}", task);

            Console.WriteLine(response.Content.ToString());
            Console.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Todo>();

                return result;
            }
            else
            {
                return null;
            }
        }
        
        public async Task Delete(int id)
        {
            var jwt = await _sessionStorage.GetAsync<string>("jwt");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.Value);
            HttpResponseMessage response = await _httpClient.DeleteAsync($"http://localhost:5000/api/Todo/delete/{id}");

            Console.WriteLine(response.Content.ToString());
            Console.WriteLine(response.StatusCode);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error deleting");
            }
        }

    }
}

