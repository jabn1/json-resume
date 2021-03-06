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
using Microsoft.AspNetCore.JsonPatch;

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
        [HttpGet("basics/profiles/{key}"),HttpHead("basics/profiles/{key}")]
        public IActionResult GetBasicsProfilesByKey(string key)
        {
            if(resume == null) return NotFound();
            var profile = resume.Basics.Profiles.FirstOrDefault(x => x.Network == key);
            if(profile != null){
                HttpContext.Response.Headers.Add("etag",profile.Etag);
            }
            else{
                return NotFound();
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(profile.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(profile);
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

        [HttpGet("work/{key}"),HttpHead("work/{key}")]
        public IActionResult GetWorkByKey(string key)
        {
            if(resume == null) return NotFound();
            var item = resume.Work.FirstOrDefault(x => x.Company == key);
            if(item != null){
                HttpContext.Response.Headers.Add("etag",item.Etag);
            }
            else{
                return NotFound();
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(item.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(item);
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

        [HttpGet("volunteer/{key}"),HttpHead("volunteer/{key}")]
        public IActionResult GetVolunteerByKey(string key)
        {
            if(resume == null) return NotFound();
            var item = resume.Volunteer.FirstOrDefault(x => x.Organization == key);
            if(item != null){
                HttpContext.Response.Headers.Add("etag",item.Etag);
            }
            else{
                return NotFound();
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(item.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(item);
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

        [HttpGet("education/{key}"),HttpHead("education/{key}")]
        public IActionResult GetEducationByKey(string key)
        {
            if(resume == null) return NotFound();
            var item = resume.Education.FirstOrDefault(x => x.StudyType == key);
            if(item != null){
                HttpContext.Response.Headers.Add("etag",item.Etag);
            }
            else{
                return NotFound();
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(item.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(item);
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

        [HttpGet("awards/{key}"),HttpHead("awards/{key}")]
        public IActionResult GetAwardsByKey(string key)
        {
            if(resume == null) return NotFound();
            var item = resume.Awards.FirstOrDefault(x => x.Title == key);
            if(item != null){
                HttpContext.Response.Headers.Add("etag",item.Etag);
            }
            else{
                return NotFound();
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(item.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(item);
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

        [HttpGet("publications/{key}"),HttpHead("publications/{key}")]
        public IActionResult GetPublicationsByKey(string key)
        {
            if(resume == null) return NotFound();
            var item = resume.Publications.FirstOrDefault(x => x.Name == key);
            if(item != null){
                HttpContext.Response.Headers.Add("etag",item.Etag);
            }
            else{
                return NotFound();
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(item.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(item);
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
        [HttpGet("skills/{key}"),HttpHead("skills/{key}")]
        public IActionResult GetSkillsByKey(string key)
        {
            if(resume == null) return NotFound();
            var item = resume.Skills.FirstOrDefault(x => x.Name == key);
            if(item != null){
                HttpContext.Response.Headers.Add("etag",item.Etag);
            }
            else{
                return NotFound();
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(item.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(item);
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

        [HttpGet("languages/{key}"),HttpHead("languages/{key}")]
        public IActionResult GetLanguagesByKey(string key)
        {
            if(resume == null) return NotFound();
            var item = resume.Languages.FirstOrDefault(x => x.Language == key);
            if(item != null){
                HttpContext.Response.Headers.Add("etag",item.Etag);
            }
            else{
                return NotFound();
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(item.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(item);
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

        [HttpGet("interests/{key}"),HttpHead("interests/{key}")]
        public IActionResult GetInterestsByKey(string key)
        {
            if(resume == null) return NotFound();
            var item = resume.Interests.FirstOrDefault(x => x.Name == key);
            if(item != null){
                HttpContext.Response.Headers.Add("etag",item.Etag);
            }
            else{
                return NotFound();
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(item.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(item);
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

        [HttpGet("references/{key}"),HttpHead("references/{key}")]
        public IActionResult GetReferencesByKey(string key)
        {
            if(resume == null) return NotFound();
            var item = resume.References.FirstOrDefault(x => x.Name == key);
            if(item != null){
                HttpContext.Response.Headers.Add("etag",item.Etag);
            }
            else{
                return NotFound();
            }
            if(HttpContext.Request.Headers.TryGetValue("if-none-match",out StringValues etag)){
                if(item.Etag == etag){
                    return StatusCode(304);
                }
            }
            HttpContext.Response.Headers.Add("Cache-Control","no-cache");
            return Ok(item);
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
            HttpContext.Response.Headers.Add("etag",resume.Etag);
            ResumeController.resume = resume;
            return Created("/resume",null);
        }
        [HttpPost("basics/profiles")]
        public IActionResult PostBasicsProfile([FromBody] Profile profile)
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
            if(resume.Basics.Profiles.Any(w => w.Network == profile.Network)){
                return Conflict();
            }
            HttpContext.Response.Headers.Add("etag",profile.Etag);
            resume.Basics.Profiles.Add(profile);
            return Created($"/resume/basics/profiles/{profile.Network}",null);
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
            HttpContext.Response.Headers.Add("etag",work.Etag);
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
            HttpContext.Response.Headers.Add("etag",volunteer.Etag);
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
            HttpContext.Response.Headers.Add("etag",education.Etag);
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
            HttpContext.Response.Headers.Add("etag",award.Etag);
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
            HttpContext.Response.Headers.Add("etag",item.Etag);
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
            HttpContext.Response.Headers.Add("etag",item.Etag);
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
            HttpContext.Response.Headers.Add("etag",item.Etag);
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
            HttpContext.Response.Headers.Add("etag",item.Etag);
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
            HttpContext.Response.Headers.Add("etag",item.Etag);
            resume.References.Add(item);
            return Created($"/resume/references/{item.Name}",null);
        }
        [HttpPut]
        public IActionResult Put([FromBody] Resume resume)
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

            if(ResumeController.resume == null ) return NotFound();

            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(ResumeController.resume.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            HttpContext.Response.Headers.Add("etag",resume.Etag);
            ResumeController.resume = resume;
            return Ok();
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] JsonPatchDocument<Resume> patchDoc)
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

            if(ResumeController.resume == null ) return NotFound();

            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(ResumeController.resume.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }
            patchDoc.ApplyTo(resume);
            HttpContext.Response.Headers.Add("etag",resume.Etag);
            
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
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

            if(ResumeController.resume == null ) return NotFound();

            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(ResumeController.resume.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            resume = null;
            return Ok();
        }

        [HttpPut("basics")]
        public IActionResult PutBasic([FromBody] Basics item)
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

            if(resume == null ) return NotFound();

            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(resume.Basics.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            HttpContext.Response.Headers.Add("etag",item.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Basics = item;
            return Ok();
        }
        [HttpPut("basics/location")]
        public IActionResult PutBasicsLocation([FromBody] Location item)
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

            if(resume == null ) return NotFound();

            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(resume.Basics.Location.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            HttpContext.Response.Headers.Add("etag",item.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Basics.Etag = Guid.NewGuid().ToString();
            resume.Basics.Location = item;
            return Ok();
        }
        [HttpPut("basics/profiles")]
        public IActionResult PutBasicsProfiles([FromBody] ResumeList<Profile> items)
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

            if(resume == null ) return NotFound();

            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(resume.Basics.Profiles.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            HttpContext.Response.Headers.Add("etag",items.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Basics.Etag = Guid.NewGuid().ToString();
            resume.Basics.Profiles = items;
            return Ok();
        }
        [HttpPut("basics/profiles/{key}")]
        public IActionResult PutBasicsProfiles([FromBody] Profile item, string key)
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

            if(resume == null ) return NotFound();
            var profile = resume.Basics.Profiles.FirstOrDefault(x => x.Network == key);
            
            if(profile == null) return NotFound();
            var position = resume.Basics.Profiles.IndexOf(profile);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(profile.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }
            item.Network = key;
            HttpContext.Response.Headers.Add("etag",item.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Basics.Etag = Guid.NewGuid().ToString();
            resume.Basics.Profiles.Etag = Guid.NewGuid().ToString();
            resume.Basics.Profiles[position] = item;
            return Ok();
        }

        [HttpDelete("basics/profiles/{key}")]
        public IActionResult DeleteBasicsProfiles(string key)
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

            if(resume == null ) return NotFound();
            var profile = resume.Basics.Profiles.FirstOrDefault(x => x.Network == key);
            
            if(profile == null) return NotFound();
            var position = resume.Basics.Profiles.IndexOf(profile);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(profile.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            resume.Etag = Guid.NewGuid().ToString();
            resume.Basics.Etag = Guid.NewGuid().ToString();
            resume.Basics.Profiles.Etag = Guid.NewGuid().ToString();
            resume.Basics.Profiles.Remove(profile);
            return Ok();
        }

        [HttpPut("work")]
        public IActionResult PutWork([FromBody] ResumeList<Work> items)
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

            if(resume == null ) return NotFound();

            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(resume.Work.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            HttpContext.Response.Headers.Add("etag",items.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Work = items;
            return Ok();
        }

        [HttpPut("work/{key}")]
        public IActionResult PutWorkByKey([FromBody] Work item, string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.Work.FirstOrDefault(x => x.Company == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.Work.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }
            item.Company = key;
            HttpContext.Response.Headers.Add("etag",item.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Work.Etag = Guid.NewGuid().ToString();

            resume.Work[position] = item;
            return Ok();
        }

        [HttpDelete("work/{key}")]
        public IActionResult DeleteWorkByKey(string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.Work.FirstOrDefault(x => x.Company == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.Work.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }
            resume.Etag = Guid.NewGuid().ToString();
            resume.Work.Etag = Guid.NewGuid().ToString();
            resume.Work.Remove(oldItem);
            return Ok();
        }
        

        [HttpPut("volunteer")]
        public IActionResult PutVolunteer([FromBody] ResumeList<Volunteer> items)
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

            if(resume == null ) return NotFound();

            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(resume.Volunteer.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            HttpContext.Response.Headers.Add("etag",items.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Volunteer = items;
            return Ok();
        }

        [HttpPut("volunteer/{key}")]
        public IActionResult PutVolunteerByKey([FromBody] Volunteer item, string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.Volunteer.FirstOrDefault(x => x.Organization == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.Volunteer.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }
            item.Organization = key;
            HttpContext.Response.Headers.Add("etag",item.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Volunteer.Etag = Guid.NewGuid().ToString();

            resume.Volunteer[position] = item;
            return Ok();
        }

        [HttpDelete("volunteer/{key}")]
        public IActionResult DeleteVolunteerByKey( string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.Volunteer.FirstOrDefault(x => x.Organization == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.Volunteer.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            resume.Etag = Guid.NewGuid().ToString();
            resume.Volunteer.Etag = Guid.NewGuid().ToString();
            resume.Volunteer.Remove(oldItem);

            return Ok();
        }
        
        [HttpPut("education")]
        public IActionResult PutEducation([FromBody] ResumeList<Education> items)
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

            if(resume == null ) return NotFound();

            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(resume.Education.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            HttpContext.Response.Headers.Add("etag",items.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Education = items;
            return Ok();
        }

        [HttpPut("education/{key}")]
        public IActionResult PutEducationByKey([FromBody] Education item, string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.Education.FirstOrDefault(x => x.StudyType == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.Education.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }
            item.StudyType = key;
            HttpContext.Response.Headers.Add("etag",item.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Education.Etag = Guid.NewGuid().ToString();

            resume.Education[position] = item;
            return Ok();
        }

        [HttpDelete("education/{key}")]
        public IActionResult DeleteEducationByKey(string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.Education.FirstOrDefault(x => x.StudyType == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.Education.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            resume.Etag = Guid.NewGuid().ToString();
            resume.Education.Etag = Guid.NewGuid().ToString();

            resume.Education.Remove(oldItem);
            return Ok();
        }

        [HttpPut("awards")]
        public IActionResult PutAwards([FromBody] ResumeList<Award> items)
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

            if(resume == null ) return NotFound();

            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(resume.Awards.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            HttpContext.Response.Headers.Add("etag",items.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Awards = items;
            return Ok();
        }

        [HttpPut("awards/{key}")]
        public IActionResult PutAwardsByKey([FromBody] Award item, string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.Awards.FirstOrDefault(x => x.Title == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.Awards.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }
            item.Title = key;
            HttpContext.Response.Headers.Add("etag",item.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Awards.Etag = Guid.NewGuid().ToString();

            resume.Awards[position] = item;
            return Ok();
        }

        [HttpDelete("awards/{key}")]
        public IActionResult DeleteAwardsByKey( string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.Awards.FirstOrDefault(x => x.Title == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.Awards.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            resume.Etag = Guid.NewGuid().ToString();
            resume.Awards.Etag = Guid.NewGuid().ToString();

            resume.Awards.Remove(oldItem);
            return Ok();
        }

        [HttpPut("publication")]
        public IActionResult PutPublications([FromBody] ResumeList<Publication> items)
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

            if(resume == null ) return NotFound();

            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(resume.Publications.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            HttpContext.Response.Headers.Add("etag",items.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Publications = items;
            return Ok();
        }

        [HttpPut("publications/{key}")]
        public IActionResult PutPublicationsByKey([FromBody] Publication item, string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.Publications.FirstOrDefault(x => x.Name == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.Publications.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }
            item.Name = key;
            HttpContext.Response.Headers.Add("etag",item.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Publications.Etag = Guid.NewGuid().ToString();

            resume.Publications[position] = item;
            return Ok();
        }

        [HttpDelete("publications/{key}")]
        public IActionResult DeletePublicationsByKey( string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.Publications.FirstOrDefault(x => x.Name == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.Publications.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            resume.Etag = Guid.NewGuid().ToString();
            resume.Publications.Etag = Guid.NewGuid().ToString();

            resume.Publications.Remove(oldItem);
            return Ok();
        }

        [HttpPut("skills")]
        public IActionResult PutSkills([FromBody] ResumeList<Skill> items)
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

            if(resume == null ) return NotFound();

            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(resume.Skills.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            HttpContext.Response.Headers.Add("etag",items.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Skills = items;
            return Ok();
        }

        [HttpPut("skills/{key}")]
        public IActionResult PutSkillsByKey([FromBody] Skill item, string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.Skills.FirstOrDefault(x => x.Name == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.Skills.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }
            item.Name = key;
            HttpContext.Response.Headers.Add("etag",item.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Skills.Etag = Guid.NewGuid().ToString();

            resume.Skills[position] = item;
            return Ok();
        }

        [HttpDelete("skills/{key}")]
        public IActionResult DeleteSkillsByKey(string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.Skills.FirstOrDefault(x => x.Name == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.Skills.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            resume.Etag = Guid.NewGuid().ToString();
            resume.Skills.Etag = Guid.NewGuid().ToString();

            resume.Skills.Remove(oldItem);
            return Ok();
        }

        [HttpPut("languages")]
        public IActionResult PutLanguages([FromBody] ResumeList<Languages> items)
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

            if(resume == null ) return NotFound();

            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(resume.Languages.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            HttpContext.Response.Headers.Add("etag",items.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Languages = items;
            return Ok();
        }

        [HttpPut("languages/{key}")]
        public IActionResult PutLanguagesByKey([FromBody] Languages item, string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.Languages.FirstOrDefault(x => x.Language == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.Languages.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }
            item.Language = key;
            HttpContext.Response.Headers.Add("etag",item.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Languages.Etag = Guid.NewGuid().ToString();

            resume.Languages[position] = item;
            return Ok();
        }

        [HttpDelete("languages/{key}")]
        public IActionResult DeleteLanguagesByKey( string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.Languages.FirstOrDefault(x => x.Language == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.Languages.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            resume.Etag = Guid.NewGuid().ToString();
            resume.Languages.Etag = Guid.NewGuid().ToString();

            resume.Languages.Remove(oldItem);
            return Ok();
        }

        [HttpPut("interests")]
        public IActionResult PutInterests([FromBody] ResumeList<Interest> items)
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

            if(resume == null ) return NotFound();

            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(resume.Interests.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            HttpContext.Response.Headers.Add("etag",items.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Interests = items;
            return Ok();
        }

        [HttpPut("interests/{key}")]
        public IActionResult PutInterestsByKey([FromBody] Interest item, string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.Interests.FirstOrDefault(x => x.Name == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.Interests.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }
            item.Name = key;
            HttpContext.Response.Headers.Add("etag",item.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.Interests.Etag = Guid.NewGuid().ToString();

            resume.Interests[position] = item;
            return Ok();
        }

        [HttpDelete("interests/{key}")]
        public IActionResult DeleteInterestsByKey(string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.Interests.FirstOrDefault(x => x.Name == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.Interests.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            resume.Etag = Guid.NewGuid().ToString();
            resume.Interests.Etag = Guid.NewGuid().ToString();

            resume.Interests.Remove(oldItem);
            return Ok();
        }

        [HttpPut("references")]
        public IActionResult PutReferences([FromBody] ResumeList<References> items)
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

            if(resume == null ) return NotFound();

            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(resume.References.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            HttpContext.Response.Headers.Add("etag",items.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.References = items;
            return Ok();
        }

        [HttpPut("references/{key}")]
        public IActionResult PutReferencesByKey([FromBody] References item, string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.References.FirstOrDefault(x => x.Name == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.References.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }
            item.Name = key;
            HttpContext.Response.Headers.Add("etag",item.Etag);
            resume.Etag = Guid.NewGuid().ToString();
            resume.References.Etag = Guid.NewGuid().ToString();

            resume.References[position] = item;
            return Ok();
        }

        [HttpDelete("references/{key}")]
        public IActionResult DeleteReferencesByKey( string key)
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

            if(resume == null ) return NotFound();
            var oldItem = resume.References.FirstOrDefault(x => x.Name == key);
            
            if(oldItem == null) return NotFound();
            var position = resume.References.IndexOf(oldItem);
            if(HttpContext.Request.Headers.TryGetValue("if-match", out StringValues etag)){
                if(oldItem.Etag != etag){
                    return Conflict();
                }
            }
            else{
                return Conflict();
            }

            resume.Etag = Guid.NewGuid().ToString();
            resume.References.Etag = Guid.NewGuid().ToString();

            resume.References.Remove(oldItem);
            return Ok();
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
