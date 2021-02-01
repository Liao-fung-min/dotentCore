using System;
using System.ComponentModel.DataAnnotations;

namespace DemoApi.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="名字只能在50個英文字內")]
        public string Name { get; set; }
    }
}
