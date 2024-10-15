using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_EduHub_Project
{
    public class MyCourses
    {
        [Key]
        public int CourseId { get; set; }
       
        public string Title { get; set; }
        public DateTime courseStartDate { get; set; }
        public DateTime courseEndDate { get; set; }
        public string category { get; set; }
        public string level { get; set; }
       
    }
}