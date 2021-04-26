using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


namespace JSON_Resume.Controllers
{
    public class Resume
    {
        public Basics Basics { get; set; }
        public ResumeList<Work> Work { get; set; } = new ResumeList<Work>();
        public ResumeList<Volunteer> Volunteer { get; set; } = new ResumeList<Volunteer>();
        public ResumeList<Education> Education { get; set; } = new ResumeList<Education>();
        public ResumeList<Award> Awards { get; set; } = new ResumeList<Award>();
        public ResumeList<Publication> Publications { get; set; } = new ResumeList<Publication>();
        public ResumeList<Skill> Skills { get; set; } = new ResumeList<Skill>();
        public ResumeList<Languages> Languages { get; set; } = new ResumeList<Languages>();
        public ResumeList<Interest> Interests { get; set; } = new ResumeList<Interest>();
        public ResumeList<References> References { get; set; } = new ResumeList<References>();
        [JsonIgnore]
        public string Etag { get; set; } = Guid.NewGuid().ToString();
    }
    public class Basics{
        public string Name { get; set; }
        public string Label { get; set; }
        public string Picture { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Summary { get; set; }
        public Location Location { get; set; }
        public ResumeList<Profile> Profiles { get; set; } = new ResumeList<Profile>();
        [JsonIgnore]
        public string Etag { get; set; } = Guid.NewGuid().ToString();
    }
    public class Location {
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string Region { get; set; }
        [JsonIgnore]
        public string Etag { get; set; } = Guid.NewGuid().ToString();
    }
    public class Profile{
        public string Network { get; set; }
        public string Username { get; set; }
        public string Url { get; set; }
        [JsonIgnore]
        public string Etag { get; set; } = Guid.NewGuid().ToString();
    }
    public class Work{
        public string Company { get; set; }
        public string Position { get; set; }
        public string Website { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Summary { get; set; }
        public List<string> Highlights { get; set; } = new List<string>();
        [JsonIgnore]
        public string Etag { get; set; } = Guid.NewGuid().ToString();
    }
    public class Volunteer{
        public string Organization { get; set; }
        public string Position { get; set; }
        public string Website { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Summary { get; set; }
        public List<string> Highlights { get; set; } = new List<string>();
        [JsonIgnore]
        public string Etag { get; set; } = Guid.NewGuid().ToString();
    }
    public class Education{
        public string Institution { get; set; }
        public string Area { get; set; }
        public string StudyType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Gpa { get; set; }
        public List<string> Courses { get; set; } = new List<string>();
        [JsonIgnore]
        public string Etag { get; set; } = Guid.NewGuid().ToString();
    }
    public class Award{
        public string Title { get; set; }
        public string Date { get; set; }
        public string Awarder { get; set; }
        public string Summary { get; set; }
        [JsonIgnore]
        public string Etag { get; set; } = Guid.NewGuid().ToString();
    }
    public class Publication{
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string ReleaseDate { get; set; }
        public string Website { get; set; }
        public string Summary { get; set; }
        [JsonIgnore]
        public string Etag { get; set; } = Guid.NewGuid().ToString();
    }
    public class Skill{
        public string Name { get; set; }
        public string Level { get; set; }
        public List<string> Keywords { get; set; } = new List<string>();
        [JsonIgnore]
        public string Etag { get; set; } = Guid.NewGuid().ToString();
    }
    public class Languages{
        public string Language { get; set; }
        public string Fluency { get; set; }
        [JsonIgnore]
        public string Etag { get; set; } = Guid.NewGuid().ToString();
    }
    public class Interest{
        public string Name { get; set; }
        public List<string> Keywords { get; set; } = new List<string>();
        [JsonIgnore]
        public string Etag { get; set; } = Guid.NewGuid().ToString();
    }
    public class References{
        public string Name { get; set; }
        public string Reference { get; set; }
        [JsonIgnore]
        public string Etag { get; set; } = Guid.NewGuid().ToString();
    }
    public class ResumeList<T> : List<T> {
        [JsonIgnore]
        public string Etag { get; set; } = Guid.NewGuid().ToString();
    }
}