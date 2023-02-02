using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Detecto.API.Case.DTOs;
using Detecto.API.Case.Services;
using Detecto.API.Case.Services.Interfaces;

namespace Detecto.API.Case.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("tasks")]
        public async Task<IEnumerable<TaskDTO>> GetTasks()
        {
            return await _taskService.GetTasks();
           
        }

        [HttpGet("get-task-by-id/{id}")]
        public async Task<ActionResult<TaskDTO>> GetTaskByID(int id)
        {
            return await _taskService.GetTaskByID(id);
            //if (task == null)
            //    return NotFound();

            //return Ok(task);
        }

        [HttpPost("add-task")]
        public async Task<ActionResult<TaskDTO>> CreateTask(TaskDTO taskDto)
        {
            return await _taskService.CreateTask(taskDto);
           
        }

        [HttpPut("put-task/{id}")]
        public async Task<ActionResult<TaskDTO>> UpdateTask(UpdateTaskDTO taskDto, int id)
        {
            return await _taskService.UpdateTask(taskDto, id);
            //if (task == null)
            //    return NotFound();

            //return Ok(task);
        }

        [HttpDelete("delete-task/{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            return await _taskService.DeleteTask(id);
            //if (task == null)
            //    return NotFound();

            //return Ok();
        }
    }
}