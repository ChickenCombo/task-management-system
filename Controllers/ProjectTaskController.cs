using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using task_management_system.DTOs.ProjectTask;
using task_management_system.Helpers;
using task_management_system.Interfaces;
using task_management_system.Mappers;

namespace task_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController(IProjectTaskRepository projectTaskRepository) : ControllerBase
    {
        private readonly IProjectTaskRepository _projectTaskRepo = projectTaskRepository;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectTaskDto createProjectTaskDto)
        {
            var projectTaskModel = createProjectTaskDto.ToProjectTaskModelFromCreate();

            await _projectTaskRepo.CreateProjectTaskAsync(projectTaskModel);

            return CreatedAtAction(nameof(GetById), new { id = projectTaskModel.Id }, projectTaskModel.ToProjectTaskDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ProjectTaskQuery query)
        {
            var (projectTasks, totalCount) = await _projectTaskRepo.GetAllAsync(query);
            var projectTasksDto = projectTasks.Select(pt => pt.ToProjectTaskDto()).ToList();
            var pagination = new
            {
                TotalCount = totalCount,
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };

            Response.Headers["X-Pagination"] = JsonConvert.SerializeObject(pagination);

            return Ok(projectTasksDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var projectTask = await _projectTaskRepo.GetByIdAsync(id);

            if (projectTask == null)
            {
                return NotFound();
            }

            return Ok(projectTask.ToProjectTaskDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProjectTaskDto projectTaskDto)
        {
            var projectTask = await _projectTaskRepo.UpdateProjectTaskAsync(id, projectTaskDto);

            if (projectTask == null)
            {
                return NotFound();
            }

            return Ok(projectTask.ToProjectTaskDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var projectTask = await _projectTaskRepo.DeleteAsync(id);

            if (projectTask == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}