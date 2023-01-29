﻿using Detecto.API.Case.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Case.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<IEnumerable<TaskDTO>> GetTasks();
        public Task<ActionResult<TaskDTO>> GetTaskByID(int id);
        public Task<ActionResult<TaskDTO>> CreateTask(TaskDTO task);
        public Task<ActionResult<TaskDTO>> UpdateTask(UpdateTaskDTO task,int id);
        public Task<ActionResult> DeleteTask(int id);
    }
}
