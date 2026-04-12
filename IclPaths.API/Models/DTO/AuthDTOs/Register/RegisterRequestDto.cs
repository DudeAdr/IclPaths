using System.ComponentModel.DataAnnotations;

namespace IclPaths.API.Models.DTO.AuthDTOs.Register
{
    public class RegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}
