using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task_management_system.Helpers
{
    public class ProjectTaskQuery
    {
        public string? Priority { get; set; }
        public string? Status { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}