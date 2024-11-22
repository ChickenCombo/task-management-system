using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task_management_system.DTOs.ProjectTask;
using task_management_system.Models;

namespace task_management_system.Mappers
{
    public static class ProjectTaskMappers
    {
        public static ProjectTask ToProjectTaskModelFromCreate(this CreateProjectTaskDto projectTaskDto)
        {
            return new ProjectTask
            {
                Title = projectTaskDto.Title,
                Description = projectTaskDto.Description,
                DueDate = projectTaskDto.DueDate,
                Priority = projectTaskDto.Priority,
                Status = projectTaskDto.Status
            };
        }

        public static ProjectTaskDto ToProjectTaskDto(this ProjectTask projectTaskModel)
        {
            return new ProjectTaskDto
            {
                Id = projectTaskModel.Id,
                Title = projectTaskModel.Title,
                Description = projectTaskModel.Description,
                DueDate = projectTaskModel.DueDate,
                Priority = projectTaskModel.Priority,
                Status = projectTaskModel.Status
            };
        }
    }
}