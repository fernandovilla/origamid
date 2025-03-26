using System.Text.Json.Serialization;

namespace Sample_jwt_balta.Models
{
    public enum RoleEnum
    {
        Admin,
        Employee,        
        Comum
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public RoleEnum Role { get; set; }

    }
}
