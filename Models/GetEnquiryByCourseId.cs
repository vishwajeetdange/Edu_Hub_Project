using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_EduHub_Project.Models
{
    public class GetEnquiryByCourseId
    {
        [Key]
        public int EnquiryId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime EnquiryDate { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        
    }
}