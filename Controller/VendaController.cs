using Microsoft.AspNetCore.Mvc;
using Pottencial.VendasApi.Application.Services;
using Pottencial.VendasApi.DTOs;
using System;
using System.Collections.Generic;

namespace Pottencial.VendasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly VendaService _vendaService;

        public VendaController(VendaService vendaService)
        {
            _vendaService = vendaService;
        }

        /// <summary>
        /// Cria uma nova venda.
        /// </summary>
        /// <param name="dto">Dados da venda.</param>
        /// <returns>Venda criada.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(VendaResponseDTO), 201)]
        [ProducesResponseType(400)]
        public IActionResult CriarVenda([FromBody] VendaRequestDTO dto)
        {
            try
            {
                var venda = _vendaService.CriarVenda(dto);
                return CreatedAtAction(nameof(ObterPorId), new { id = venda.Id }, venda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma venda por ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VendaResponseDTO), 200)]
        [ProducesResponseType(404)]
        public IActionResult ObterPorId(Guid id)
        {
            try
            {
                var venda = _vendaService.ObterPorId(id);
                return Ok(venda);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Atualiza o status da venda.
        /// </summary>
        [HttpPut("{id}/status")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AtualizarStatus(Guid id, [FromBody] AtualizarStatusDTO dto)
        {
            try
            {
                _vendaService.AtualizarStatus(id, dto.NovoStatus);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um item à venda.
        /// </summary>
        [HttpPost("{id}/itens")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AdicionarItem(Guid id, [FromBody] ItemDTO itemDto)
        {
            try
            {
                _vendaService.AdicionarItem(id, itemDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remove um item da venda.
        /// </summary>
        [HttpDelete("{id}/itens/{itemId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult RemoverItem(Guid id, Guid itemId)
        {
            try
            {
                _vendaService.RemoverItem(id, itemId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos os vendedores.
        /// </summary>
        [HttpGet("vendedores")]
        [ProducesResponseType(typeof(List<VendedorDTO>), 200)]
        public IActionResult ObterTodosVendedores()
        {
            var vendedores = _vendaService.ObterTodosVendedores();
            return Ok(vendedores);
        }

        /// <summary>
        /// Retorna todos os itens vendidos.
        /// </summary>
        [HttpGet("itens")]
        [ProducesResponseType(typeof(List<ItemDTO>), 200)]
        public IActionResult ObterTodosItens()
        {
            var itens = _vendaService.ObterTodosItens();
            return Ok(itens);
        }

    }
}
