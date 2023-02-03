using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Detecto.API.Case.Models;
using Detecto.API.Case.DTOs;
using Detecto.API.Configurations;
using Microsoft.EntityFrameworkCore;
using Detecto.API.Case.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Case.Services
{
    public class TaskService : ITaskService
    {
        private readonly DetectoDbContext _context;
        public TaskService(DetectoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskDTO>> GetTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return tasks.Select(task => new TaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                Details = task.Details,
                Statusi = task.Statusi,
                DateCreated = task.DateCreated,
                DueDate = task.DueDate
            });
        }

        public async Task<ActionResult<TaskDTO>> GetTaskByID(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                throw new ArgumentException("Task not found");
            }

            return new TaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                Details = task.Details,
                Statusi = task.Statusi,
                DateCreated = task.DateCreated,
                DueDate = task.DueDate
            };
        }

        public async Task<ActionResult<TaskDTO>> UpdateTask(UpdateTaskDTO task, int id)
        {
            var originalTask = await _context.Tasks.FindAsync(id);

            if (originalTask == null)
            {
                throw new ArgumentException("Task not found");
            }

            originalTask.Title = task.Title;
            originalTask.Details = task.Details;
            originalTask.Statusi = task.Statusi;
            originalTask.DueDate = task.DueDate;

            _context.Tasks.Update(originalTask);
            await _context.SaveChangesAsync();
            return new OkObjectResult("task updated succesfully!");

        }

        public async Task<ActionResult> DeleteTask(int id)
        {
            var originalTask = await _context.Tasks.FindAsync(id);

            if (originalTask == null)
            {
                throw new ArgumentException("Task not found");

            }

            _context.Tasks.Remove(originalTask);
            await _context.SaveChangesAsync();
            return new OkObjectResult("task deleted succesfully!");
        }

        public async Task<ActionResult<TaskDTO>>  CreateTask(TaskDTO task)
        {
            var newTask = new DTask
            {
                Title = task.Title,
                Details = task.Details,
                Statusi = task.Statusi,
                DateCreated = DateTime.Now,
                DueDate = task.DueDate
            };

            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();
            return new OkObjectResult("task created succesfully!");

        }
    }
}
