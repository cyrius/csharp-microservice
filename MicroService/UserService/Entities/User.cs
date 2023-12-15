
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;

namespace UserService.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set;}
        public string? Email { get; set;}
        public string? PasswordHash { get; set; }

        public override string ToString()
        {
            return $"Id: ${Id} Name: ${Name} Email : ${Email} Pass: ${PasswordHash}";
        }
    }

    public class UserDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }

    public class UserCreateModel
    {
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }

    public class UserUpdateModel
    {
        public int Id { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
    public class UserLogin
    {
        public required string Name { get; set; }
        public required string Pass { get; set; }
    }
}
