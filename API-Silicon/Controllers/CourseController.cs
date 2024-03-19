using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Silicon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }

        #region READ
        [HttpGet]
        public IActionResult GetOne()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
        #endregion

        #region UPDATE
        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }
        #endregion

        #region DELETE
        [HttpPut]
        public IActionResult Delete()
        {
            return Ok();

        }
        #endregion

    }
}
