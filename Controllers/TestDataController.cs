using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestRunnerDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDataController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public ActionResult<List<TestData>> Get()
        {
            var data = new List<TestData>
            {
                new()
                {
                    Id = 4,
                    Name = "TeamCity1"
                },
                new()
                {
                    Id = 5,
                    Name = "TeamCity2"
                },
            };

            return this.Ok(data);
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return new ContentResult
            {
                StatusCode = 400,
                Content = "Delete is not supported"
            };
        }
    }
}