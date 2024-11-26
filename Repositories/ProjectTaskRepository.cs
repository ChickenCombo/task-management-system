using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using task_management_system.Data;
using task_management_system.DTOs.ProjectTask;
using task_management_system.Helpers;
using task_management_system.Interfaces;
using task_management_system.Models;

namespace task_management_system.Repositories
{
    public class ProjectTaskRepository(ApplicationDBContext context) : IProjectTaskRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<ProjectTask> CreateProjectTaskAsync(ProjectTask projectTaskModel)
        {
            await _context.ProjectTask.AddAsync(projectTaskModel);
            await _context.SaveChangesAsync();

            return projectTaskModel;
        }

        public async Task<(List<ProjectTask>, int)> GetAllAsync(ProjectTaskQuery query)
        {
            var projectTasks = _context.ProjectTask.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Status))
            {
                projectTasks = projectTasks.Where(pt => pt.Status == query.Status);
            }

            if (!string.IsNullOrWhiteSpace(query.Priority))
            {
                projectTasks = projectTasks.Where(pt => pt.Priority == query.Priority);
            }

            var totalCount = await projectTasks.CountAsync();
            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            var queriedItems = await projectTasks.Skip(skipNumber).Take(query.PageSize).ToListAsync();

            return (queriedItems, totalCount);
        }

        public async Task<ProjectTask?> GetByIdAsync(Guid id)
        {
            var projectTaskModel = await _context.ProjectTask.FirstOrDefaultAsync(pt => pt.Id == id);

            if (projectTaskModel == null)
            {
                return null;
            }

            return projectTaskModel;
        }

        public async Task<ProjectTask?> UpdateProjectTaskAsync(Guid id, UpdateProjectTaskDto projectTaskDto)
        {
            var projectTaskModel = await _context.ProjectTask.FirstOrDefaultAsync(pt => pt.Id == id);

            if (projectTaskModel == null)
            {
                return null;
            }

            projectTaskModel.Title = projectTaskDto.Title;
            projectTaskModel.Description = projectTaskDto.Description;
            projectTaskModel.DueDate = projectTaskDto.DueDate;
            projectTaskModel.Priority = projectTaskDto.Priority;
            projectTaskModel.Status = projectTaskDto.Status;

            await _context.SaveChangesAsync();

            return projectTaskModel;
        }

        public async Task<ProjectTask?> DeleteAsync(Guid id)
        {
            var projectTaskModel = await _context.ProjectTask.FirstOrDefaultAsync(pt => pt.Id == id);

            if (projectTaskModel == null)
            {
                return null;
            }

            _context.Remove(projectTaskModel);
            await _context.SaveChangesAsync();

            return projectTaskModel;
        }

        public async Task<int> GetTotalCountAsync(ProjectTaskQuery query)
        {
            var projectTasks = _context.ProjectTask.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Status))
            {
                projectTasks = projectTasks.Where(pt => pt.Status == query.Status);
            }

            if (!string.IsNullOrWhiteSpace(query.Priority))
            {
                projectTasks = projectTasks.Where(pt => pt.Priority == query.Priority);
            }

            return await projectTasks.CountAsync();
        }
    }
}