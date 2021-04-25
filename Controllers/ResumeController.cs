using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Microsoft.Extensions.Primitives;
namespace JSON_Resume.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResumeController : ControllerBase
    {
        private static Resume resume;

        [HttpGet]
        public IActionResult Get()
        {
            if(resume != null){
                HttpContext.Response.Headers.Add("etag",resume.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Etag == etag){
                    return StatusCode(304);
                }
            }
            return Ok(resume);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Resume resume)
        {
            ResumeController.resume = resume;
            return Ok();
        }
    }
}
