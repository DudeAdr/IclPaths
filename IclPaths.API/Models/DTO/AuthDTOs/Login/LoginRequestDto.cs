using System.ComponentModel.DataAnnotations;

namespace IclPaths.API.Models.DTO.AuthDTOs.Login
{
    public class LoginRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
