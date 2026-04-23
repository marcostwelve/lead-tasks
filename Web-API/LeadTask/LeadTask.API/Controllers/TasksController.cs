using LeadTask.Application.Dtos.TaskItem;
using LeadTask.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadTask.API.Controllers
{
    [Route("api/leads/{leadId}/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskItemService _taskService;
        public TasksController(ITaskItemService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks(int leadId)
        {
            try
            {
                var tasks = await _taskService.GetAllTasksAsync(leadId);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GetTaskById(int leadId, int id)
        {
            try
            {
                var task = await _taskService.GetAllTasksAsync(leadId);
                if (task == null)
                {
                    return NotFound("Nenhuma Tarefa Encontrada");
                }
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(int leadId, [FromBody] TaskCreateDto taskDto)
        {
            try
            {
                if (taskDto == null)
                {
                    return BadRequest("Dados da Tarefa inválidos");
                }
                var createdTask = await _taskService.AddTaskAsync(leadId, taskDto);
                return CreatedAtAction(nameof(GetTaskById), new { leadId = leadId, id = createdTask.Id }, createdTask);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int leadId, int id, [FromBody] TaskUpdateDto taskDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest($"Dados da Tarefa inválidos {ModelState}");
                }

                var updatedTask = await _taskService.UpdateTaskAsync(leadId, id, taskDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int leadId, int id)
        {
            try
            {
                await _taskService.DeleteTaskAsync(leadId, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }
    }
}
