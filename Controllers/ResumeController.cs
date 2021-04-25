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

        [HttpGet("basics")]
        public IActionResult GetBasics()
        {
            if(resume?.Basics != null){
                HttpContext.Response.Headers.Add("etag",resume.Basics.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Basics?.Etag == etag){
                    return StatusCode(304);
                }
            }
            return Ok(resume?.Basics);
        }

        [HttpGet("basics/profiles")]
        public IActionResult GetBasicsProfiles()
        {
            if(resume?.Basics?.Profiles != null){
                HttpContext.Response.Headers.Add("etag",resume.Basics.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Basics?.Profiles?.Etag == etag){
                    return StatusCode(304);
                }
            }
            return Ok(resume?.Basics?.Profiles);
        }

        [HttpGet("work")]
        public IActionResult GetWork()
        {
            if(resume?.Work != null){
                HttpContext.Response.Headers.Add("etag",resume.Work.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Work?.Etag == etag){
                    return StatusCode(304);
                }
            }
            return Ok(resume?.Work);
        }

        [HttpGet("volunteer")]
        public IActionResult GetVolunteer()
        {
            if(resume?.Volunteer != null){
                HttpContext.Response.Headers.Add("etag",resume.Volunteer.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Volunteer?.Etag == etag){
                    return StatusCode(304);
                }
            }
            return Ok(resume?.Volunteer);
        }

        [HttpGet("education")]
        public IActionResult GetEducation()
        {
            if(resume?.Education != null){
                HttpContext.Response.Headers.Add("etag",resume.Education.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Education?.Etag == etag){
                    return StatusCode(304);
                }
            }
            return Ok(resume?.Education);
        }

        [HttpGet("awards")]
        public IActionResult GetAwards()
        {
            if(resume?.Awards != null){
                HttpContext.Response.Headers.Add("etag",resume.Awards.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Awards?.Etag == etag){
                    return StatusCode(304);
                }
            }
            return Ok(resume?.Awards);
        }

        [HttpGet("publications")]
        public IActionResult GetPublications()
        {
            if(resume?.Publications != null){
                HttpContext.Response.Headers.Add("etag",resume.Publications.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Publications?.Etag == etag){
                    return StatusCode(304);
                }
            }
            return Ok(resume?.Publications);
        }

        [HttpGet("skills")]
        public IActionResult GetSkills()
        {
            if(resume?.Skills != null){
                HttpContext.Response.Headers.Add("etag",resume.Skills.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Skills?.Etag == etag){
                    return StatusCode(304);
                }
            }
            return Ok(resume?.Skills);
        }

        [HttpGet("languages")]
        public IActionResult GetLanguages()
        {
            if(resume?.Languages != null){
                HttpContext.Response.Headers.Add("etag",resume.Languages.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Languages?.Etag == etag){
                    return StatusCode(304);
                }
            }
            return Ok(resume?.Languages);
        }

        [HttpGet("interests")]
        public IActionResult GetInterests()
        {
            if(resume?.Interests != null){
                HttpContext.Response.Headers.Add("etag",resume.Interests.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Interests?.Etag == etag){
                    return StatusCode(304);
                }
            }
            return Ok(resume?.Interests);
        }

        [HttpGet("references")]
        public IActionResult GetReferences()
        {
            if(resume?.References != null){
                HttpContext.Response.Headers.Add("etag",resume.References.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.References?.Etag == etag){
                    return StatusCode(304);
                }
            }
            return Ok(resume?.References);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Resume resume)
        {
            ResumeController.resume = resume;
            return Ok();
        }
    }
}
