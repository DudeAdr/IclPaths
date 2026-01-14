using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IclPaths.API.Controllers
{
    //https://localhost:portnumber/api/students

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static string[] sNames = new string[] { "John", "Jane", "Doe" };

        [HttpGet]
        public IActionResult GetAllStudents()
        {    
            return Ok(sNames);
        }
    }
}
