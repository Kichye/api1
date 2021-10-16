using System.Collections;
using Microsoft.AspNetCore.Mvc;
using QueryApi.Repositories;
using QueryApi.Domain;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var repository = new PRepository();
            var per = repository.GetAll();
            return Ok(per);
        } 
    }
}