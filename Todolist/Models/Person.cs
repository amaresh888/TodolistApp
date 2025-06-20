using System;
using System.ComponentModel.DataAnnotations;

namespace Todolist.Models
{
    public class Person
    {
        [Key] // This indicates 'id' is the primary key
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Task description is required.")]
        [StringLength(200, ErrorMessage = "Task can't exceed 200 characters.")]
        public string Task { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
    }
}
