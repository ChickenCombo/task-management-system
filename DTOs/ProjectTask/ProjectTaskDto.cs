using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task_management_system.DTOs.ProjectTask
{
    public class ProjectTaskDto
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime DueDate { get; set; }
        public required string Priority { get; set; }
        public required string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}