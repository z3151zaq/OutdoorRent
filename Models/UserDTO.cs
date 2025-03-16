using System.ComponentModel.DataAnnotations;

namespace WebCoreApi.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class UserCreateDTO
    {
        public int Age { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Code { get; set; }
    }
    public class UserDeleteDTO
    {
        public int Id { get; set; }
    }
}
