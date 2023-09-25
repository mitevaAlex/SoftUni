using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    [Table("Students")]
    public class Student
    {
        public Student()
        {
            CourseEnrollments = new HashSet<StudentCourse>();
            HomeworkSubmissions = new HashSet<Homework>();
        }

        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(100)]
        [DataType("nvarchar")]
        public string Name{ get; set; }

        [StringLength(10, MinimumLength = 10)]
        [DataType("char")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType("datetime2")]
        public DateTime RegisteredOn { get; set; }

        [DataType("datetime2")]
        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> CourseEnrollments { get; set; }
        public ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}
