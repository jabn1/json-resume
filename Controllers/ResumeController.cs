using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Microsoft.Extensions.Primitives;
using System.Text;

namespace JSON_Resume.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResumeController : ControllerBase
    {
        private static Resume resume;
        private static string username = "myusername";
        private static string password = "mypassword";

        [HttpGet,HttpHead]
        public IActionResult Get()
        {
            if(resume != null){
                HttpContext.Response.Headers.Add("etag",resume.Etag);
            }
            else{
                return NotFound();
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(resume);
        }

        [HttpGet("basics"),HttpHead("basics")]
        public IActionResult GetBasics()
        {
            if(resume == null) return NotFound();
            if(resume?.Basics != null){
                HttpContext.Response.Headers.Add("etag",resume.Basics.Etag);
            }
            
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Basics?.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(resume?.Basics);
        }

        [HttpGet("basics/profiles"),HttpHead("basics/profiles")]
        public IActionResult GetBasicsProfiles()
        {
            if(resume == null) return NotFound();
            if(resume?.Basics?.Profiles != null){
                HttpContext.Response.Headers.Add("etag",resume.Basics.Profiles.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Basics?.Profiles?.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(resume?.Basics?.Profiles);
        }

        [HttpGet("basics/location"),HttpHead("basics/profiles")]
        public IActionResult GetBasicsLocation()
        {
            if(resume == null) return NotFound();
            if(resume?.Basics?.Location != null){
                HttpContext.Response.Headers.Add("etag",resume.Basics.Location.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Basics?.Location?.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(resume?.Basics?.Location);
        }

        [HttpGet("work"),HttpHead("work")]
        public IActionResult GetWork()
        {
            if(resume == null) return NotFound();
            if(resume?.Work != null){
                HttpContext.Response.Headers.Add("etag",resume.Work.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Work?.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(resume?.Work);
        }

        [HttpGet("volunteer"),HttpHead("volunteer")]
        public IActionResult GetVolunteer()
        {
            if(resume == null) return NotFound();
            if(resume?.Volunteer != null){
                HttpContext.Response.Headers.Add("etag",resume.Volunteer.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Volunteer?.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(resume?.Volunteer);
        }

        [HttpGet("education"),HttpHead("education")]
        public IActionResult GetEducation()
        {
            if(resume == null) return NotFound();
            if(resume?.Education != null){
                HttpContext.Response.Headers.Add("etag",resume.Education.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Education?.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(resume?.Education);
        }

        [HttpGet("awards"),HttpHead("awards")]
        public IActionResult GetAwards()
        {
            if(resume == null) return NotFound();
            if(resume?.Awards != null){
                HttpContext.Response.Headers.Add("etag",resume.Awards.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Awards?.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(resume?.Awards);
        }

        [HttpGet("publications"),HttpHead("publications")]
        public IActionResult GetPublications()
        {
            if(resume == null) return NotFound();
            if(resume?.Publications != null){
                HttpContext.Response.Headers.Add("etag",resume.Publications.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Publications?.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(resume?.Publications);
        }

        [HttpGet("skills"),HttpHead("skills")]
        public IActionResult GetSkills()
        {
            if(resume == null) return NotFound();
            if(resume?.Skills != null){
                HttpContext.Response.Headers.Add("etag",resume.Skills.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Skills?.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(resume?.Skills);
        }

        [HttpGet("languages"),HttpHead("languages")]
        public IActionResult GetLanguages()
        {
            if(resume == null) return NotFound();
            if(resume?.Languages != null){
                HttpContext.Response.Headers.Add("etag",resume.Languages.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Languages?.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(resume?.Languages);
        }

        [HttpGet("interests"),HttpHead("interests")]
        public IActionResult GetInterests()
        {
            if(resume == null) return NotFound();
            if(resume?.Interests != null){
                HttpContext.Response.Headers.Add("etag",resume.Interests.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.Interests?.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(resume?.Interests);
        }

        [HttpGet("references"),HttpHead("references")]
        public IActionResult GetReferences()
        {
            if(resume == null) return NotFound();
            if(resume?.References != null){
                HttpContext.Response.Headers.Add("etag",resume.References.Etag);
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(resume?.References?.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(resume?.References);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Resume resume)
        {
            if(HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorization))
            {
                if(!Authenticate(authorization,username,password)){
                    return Unauthorized();
                }
            }
            else
            {
                HttpContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"Restricted http methods\"");
                return Unauthorized();
            }

            if(ResumeController.resume != null ) return Conflict();

            ResumeController.resume = resume;
            return Created("/resume",null);
        }

        [HttpPost("work")]
        public IActionResult PostWork([FromBody] Work work)
        {
            if(HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorization))
            {
                if(!Authenticate(authorization,username,password)){
                    return Unauthorized();
                }
            }
            else
            {
                HttpContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"Restricted http methods\"");
                return Unauthorized();
            }
            if(resume == null){
                return NotFound();
            }
            if(resume.Work.Any(w => w.Company == work.Company)){
                return Conflict();
            }

            resume.Work.Add(work);
            return Created($"/resume/work/{work.Company}",null);
        }

    

        [HttpPost("volunteer")]
        public IActionResult PostVolunteer([FromBody] Volunteer volunteer)
        {
            if(HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorization))
            {
                if(!Authenticate(authorization,username,password)){
                    return Unauthorized();
                }
            }
            else
            {
                HttpContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"Restricted http methods\"");
                return Unauthorized();
            }
            if(resume == null){
                return NotFound();
            }
            if(resume.Volunteer.Any(v => v.Organization == volunteer.Organization)){
                return Conflict();
            }

            resume.Volunteer.Add(volunteer);
            return Created($"/resume/work/{volunteer.Organization}",null);
        }
        
        [HttpPost("education")]
        public IActionResult PostEducation([FromBody] Education education)
        {
            if(HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorization))
            {
                if(!Authenticate(authorization,username,password)){
                    return Unauthorized();
                }
            }
            else
            {
                HttpContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"Restricted http methods\"");
                return Unauthorized();
            }
            if(resume == null){
                return NotFound();
            }
            if(resume.Education.Any(x => x.Institution == education.Institution)){
                return Conflict();
            }

            resume.Education.Add(education);
            return Created($"/resume/education/{education.Institution}",null);
        }

        [HttpPost("education")]
        public IActionResult PostAward([FromBody] Award award)
        {
            if(HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorization))
            {
                if(!Authenticate(authorization,username,password)){
                    return Unauthorized();
                }
            }
            else
            {
                HttpContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"Restricted http methods\"");
                return Unauthorized();
            }
            if(resume == null){
                return NotFound();
            }
            if(resume.Awards.Any(x => x.Title == award.Title)){
                return Conflict();
            }

            resume.Awards.Add(award);
            return Created($"/resume/education/{award.Title}",null);
        }
        [HttpPost("publications")]
        public IActionResult PostPublication([FromBody] Publication item)
        {
            if(HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorization))
            {
                if(!Authenticate(authorization,username,password)){
                    return Unauthorized();
                }
            }
            else
            {
                HttpContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"Restricted http methods\"");
                return Unauthorized();
            }
            if(resume == null){
                return NotFound();
            }
            if(resume.Publications.Any(x => x.Name == item.Name)){
                return Conflict();
            }

            resume.Publications.Add(item);
            return Created($"/resume/publications/{item.Name}",null);
        }
        [HttpPost("skills")]
        public IActionResult PostSkill([FromBody] Skill item)
        {
            if(HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorization))
            {
                if(!Authenticate(authorization,username,password)){
                    return Unauthorized();
                }
            }
            else
            {
                HttpContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"Restricted http methods\"");
                return Unauthorized();
            }
            if(resume == null){
                return NotFound();
            }
            if(resume.Skills.Any(x => x.Name == item.Name)){
                return Conflict();
            }

            resume.Skills.Add(item);
            return Created($"/resume/skills/{item.Name}",null);
        }

        [HttpPost("languages")]
        public IActionResult PostLanguage([FromBody] Languages item)
        {
            if(HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorization))
            {
                if(!Authenticate(authorization,username,password)){
                    return Unauthorized();
                }
            }
            else
            {
                HttpContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"Restricted http methods\"");
                return Unauthorized();
            }
            if(resume == null){
                return NotFound();
            }
            if(resume.Languages.Any(x => x.Language == item.Language)){
                return Conflict();
            }

            resume.Languages.Add(item);
            return Created($"/resume/languages/{item.Language}",null);
        }
        [HttpPost("interests")]
        public IActionResult PostInterest([FromBody] Interest item)
        {
            if(HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorization))
            {
                if(!Authenticate(authorization,username,password)){
                    return Unauthorized();
                }
            }
            else
            {
                HttpContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"Restricted http methods\"");
                return Unauthorized();
            }
            if(resume == null){
                return NotFound();
            }
            if(resume.Interests.Any(x => x.Name == item.Name)){
                return Conflict();
            }

            resume.Interests.Add(item);
            return Created($"/resume/interests/{item.Name}",null);
        }
        [HttpPost("references")]
        public IActionResult PostReference([FromBody] References item)
        {
            if(HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorization))
            {
                if(!Authenticate(authorization,username,password)){
                    return Unauthorized();
                }
            }
            else
            {
                HttpContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"Restricted http methods\"");
                return Unauthorized();
            }
            if(resume == null){
                return NotFound();
            }
            if(resume.References.Any(x => x.Name == item.Name)){
                return Conflict();
            }

            resume.References.Add(item);
            return Created($"/resume/references/{item.Name}",null);
        }
        private bool Authenticate(string authorization, string username, string password)
        {
            var content = authorization.Split(" ");
            if(content[0] != "Basic") return false;
            try{
                var data = Convert.FromBase64String(content[1]);
                var decodedData = Encoding.UTF8.GetString(data).Split(":"); 
                if(decodedData[0] == username && decodedData[1] == password) return true;
            }
            catch{
                return false;
            }
            return false;
        }
    }
}

// if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
//                 if(resume.Etag != etag){
//                     return Conflict();
//                 }
//             }
//             else{
//                 return Conflict();
//             }
