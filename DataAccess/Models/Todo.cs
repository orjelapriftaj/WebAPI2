using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Models
{
    public class Todo
    {
        public int ID { get; set; }
        public virtual Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public bool IsDone { get; set; }
    }
}
