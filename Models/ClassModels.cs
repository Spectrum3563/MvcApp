using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMvcApp.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Column("StudentName", TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column("DateOfBirth", TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [ForeignKey("Class")]
        public int ClassId { get; set; }
        
        public Class Class { get; set; }
    }

    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        public string ClassName { get; set; }
    }

    public class Enrollment 
    {
        [Key]
        public int EnrollmentId { get; set;}

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}