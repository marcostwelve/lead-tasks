using AutoMapper;
using LeadTask.Application.Dtos.Lead;
using LeadTask.Application.Dtos.TaskItem;
using LeadTask.Application.Interfaces;
using LeadTask.Domain.Entities;
using LeadTask.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTask.Application.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRespository _taskItemRepository;
        private readonly IMapper _mapper;
        public TaskItemService(ITaskItemRespository taskItemRepository, IMapper mapper)
        {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
        }
        public async Task<TaskDto> AddTaskAsync(int leadId, TaskCreateDto taskCreateDto)
        {
            var taskItemEntity = _mapper.Map<TaskItem>(taskCreateDto);
            await _taskItemRepository.AddTaskAsync(leadId, taskItemEntity);
            var taskDto = _mapper.Map<TaskDto>(taskItemEntity);
            return taskDto;
        }

        public async Task DeleteTaskAsync(int leadId, int id)
        {
            var taskItem = await _taskItemRepository.GetTaskByIdAsync(leadId, id);
            if (taskItem == null)
            {
                throw new Exception("Task não encontrada");
            }
            await _taskItemRepository.DeleteTaskAsync(leadId, taskItem.Id);
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync(int leadId)
        {
            var tasksItemEntity  = await _taskItemRepository.GetAllTasksAsync(leadId);
            if (tasksItemEntity == null)
            {
                throw new Exception("Task não encontrada");
            }
            var tasksItemDto = _mapper.Map<IEnumerable<TaskDto>>(tasksItemEntity);
            return tasksItemDto;
        }

        public async Task<TaskDto> GetTaskByIdAsync(int leadId, int id)
        {
            var taskItemEntity = await _taskItemRepository.GetTaskByIdAsync(leadId, id);
            if (taskItemEntity == null)
            {
                throw new Exception("Task não encontrada");
            }
            var taskItemDto = _mapper.Map<TaskDto>(taskItemEntity);
            return taskItemDto;
        }

        public async Task<TaskDto> UpdateTaskAsync(int leadId, int id, TaskUpdateDto taskUpdateDto)
        {
            var existingTaskItem = await _taskItemRepository.GetTaskByIdAsync(leadId, id);
           

            if (existingTaskItem == null || existingTaskItem.LeadId != leadId)
            {
                throw new Exception($"Task não encontrada ou não pertence ao Lead especificado.");
            }
            _mapper.Map(taskUpdateDto, existingTaskItem);
            await _taskItemRepository.UpdateTaskAsync(leadId, existingTaskItem);
            var taskItemDto = _mapper.Map<TaskDto>(existingTaskItem);
            return taskItemDto;

        }
    }
}
