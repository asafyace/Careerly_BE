using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careerly.Models
{
    public class Experience
    {
        public int ID { get; set; }
        public string ?Company { get; set; }
        public string ?JobTitle { get; set; }
        public int YearsOfEmployment { get; set; }

    }
    public class Award
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Prize { get; set; }
        public DateTime Date { get; set; }

    }
    public class Course
    {
        public int ID { get; set; }
        public string? CourseName { get; set; }
        public string? Issuer { get; set; }
        public int Length { get; set; }

    }
    public class Education
    {
        public int ID { get; set; }
        public string? School { get; set; }
        public string? Degree { get; set; }
        public string? FieldOfStudy { get; set; }
        public string? Description { get; set; }
        public int Grade { get; set; }

    }
}
