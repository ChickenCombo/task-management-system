using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task_management_system.DTOs.ProjectTask;
using task_management_system.Helpers;
using task_management_system.Models;

namespace task_management_system.Interfaces
{
    public interface IProjectTaskRepository
    {
        Task<ProjectTask> CreateProjectTaskAsync(ProjectTask projectTask);
        Task<List<ProjectTask>> GetAllAsync(ProjectTaskQuery query);
        Task<ProjectTask?> GetByIdAsync(Guid id);
        Task<ProjectTask?> UpdateProjectTaskAsync(Guid id, UpdateProjectTaskDto projectTaskDto);
        Task<ProjectTask?> DeleteAsync(Guid id);
        Task<int> GetTotalCountAsync(ProjectTaskQuery query);
    }
}