using System;
using System.Collections.Generic;
using System.Linq;


namespace JSON_Resume.Controllers
{
    public class Resume
    {
        public Basics Basics { get; set; }
        public List<Profile> Profiles { get; set; } 
        public List<Work> Work { get; set; }
        public List<Volunteer> Volunteer { get; set; }
        public List<Education> Education { get; set; }
        public List<Award> Awards { get; set; }
        public List<Publication> Publications { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Languages> Languages { get; set; }
        public List<Interest> Interests { get; set; }
        public List<References> References { get; set; }
    }
    public class Basics{
        public string Name { get; set; }
        public string Label { get; set; }
        public string Picture { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Summary { get; set; }
        public List<Location> Locations { get; set; }
    }
    public class Location {
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string Region { get; set; }
    }
    public class Profile{
        public string Network { get; set; }
        public string Username { get; set; }
        public string Url { get; set; }
    }
    public class Work{
        public string Company { get; set; }
        public string Position { get; set; }
        public string Website { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Summary { get; set; }
        public List<string> Highlights { get; set; }
    }
    public class Volunteer{
        public string Organization { get; set; }
        public string Position { get; set; }
        public string Website { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Summary { get; set; }
        public List<string> Highlights { get; set; }
    }
    public class Education{
        public string Institution { get; set; }
        public string Area { get; set; }
        public string StudyType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Gpa { get; set; }
        public List<string> Courses { get; set; }
    }
    public class Award{
        public string Title { get; set; }
        public string Date { get; set; }
        public string Awarder { get; set; }
        public string Summary { get; set; }
    }
    public class Publication{
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string ReleaseDate { get; set; }
        public string Website { get; set; }
        public string Summary { get; set; }
    }
    public class Skill{
        public string Name { get; set; }
        public string Level { get; set; }
        public List<string> Keywords { get; set; }
    }
    public class Languages{
        public string Language { get; set; }
        public string Fluency { get; set; }
    }
    public class Interest{
        public string Name { get; set; }
        public List<string> Keywords { get; set; }
    }
    public class References{
        public string Name { get; set; }
        public string Reference { get; set; }
    }

}