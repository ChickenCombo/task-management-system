using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace task_management_system.Models
{
    [Table("ProjectTasks")]
    public class ProjectTask : TimestampEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public required string Priority { get; set; }

        [Required]
        public required string Status { get; set; }
    }
}