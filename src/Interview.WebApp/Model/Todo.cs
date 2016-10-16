using System;
using System.ComponentModel.DataAnnotations;

namespace Interview.WebApp.Model
{
    public class Todo
    {
        public int TodoId { get; set; }

        public bool Completed { get; set; }

        public DateTime? CompletedOn { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
