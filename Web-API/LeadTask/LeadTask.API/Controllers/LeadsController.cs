using AutoMapper;
using LeadTask.Application.Dtos.Lead;
using LeadTask.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly ILeadService _leadService;
        public LeadsController(ILeadService service)
        {
            _leadService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLeads([FromQuery] string? search, [FromQuery] string? status)
        {
            try
            {
                var leads = await _leadService.GetAllLeadsAsync(search, status);
                return Ok(leads);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeadById(int id)
        {
            try
            {
                var lead = await _leadService.GetLeadByIdAsync(id);
                if (lead == null)
                {
                    return NotFound("Nenhum Lead Encontrado");
                }
                return Ok(lead);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateLead([FromBody] LeadCreateDto leadDto)
        {
            try
            {
                if (leadDto == null)
                {
                    return BadRequest("Dados do Lead inválidos");
                }

                var createdLead = await _leadService.AddLeadAsync(leadDto);
                return CreatedAtAction(nameof(GetLeadById), new { id = createdLead.Id }, createdLead);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLead(int id, [FromBody] LeadUpdateDto leadDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest($"Dados do Lead inválidos{ModelState}");
                }
               
                var updatedLead = await _leadService.UpdateLeadAsync(id, leadDto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLead(int id)
        {
            try
            {
                await _leadService.DeleteLeadAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }

        }
    }
}
