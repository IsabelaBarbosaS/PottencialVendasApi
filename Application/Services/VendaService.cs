using System;
using System.Collections.Generic;
using System.Linq;
using Pottencial.VendasApi.Domain;
using Pottencial.VendasApi.DTOs;
using Pottencial.VendasApi.Repositories;

namespace Pottencial.VendasApi.Application.Services
{
    public class VendaService(IVendaRepository vendaRepository)
    {
        private readonly IVendaRepository _vendaRepository = vendaRepository;

        public Venda CriarVenda(VendaRequestDTO dto)
        {
            if (dto.Vendedor == null)
                throw new ArgumentException("Vendedor é obrigatório.");

            if (dto.Itens == null || !dto.Itens.Any())
                throw new ArgumentException("A venda deve conter pelo menos um item.");

            var vendedor = new Vendedor
            {
                Cpf = dto.Vendedor.Cpf!,
                Nome = dto.Vendedor.Nome!,
                Email = dto.Vendedor.Email!,
                Telefone = dto.Vendedor.Telefone!
            };

            var itens = dto.Itens.Select(i => new Item
            {
                Nome = i.Nome!,
                Preco = i.Preco,
                Quantidade = i.Quantidade
            }).ToList();

            var venda = new Venda
            {
                Vendedor = vendedor,
                Itens = itens
            };

            _vendaRepository.Adicionar(venda);

            return venda;
        }

        public Venda ObterPorId(Guid id)
        {
            var venda = _vendaRepository.ObterPorId(id);
            if (venda == null)
                throw new KeyNotFoundException("Venda não encontrada.");
            return venda;
        }

        public void AtualizarStatus(Guid id, StatusVenda novoStatus)
        {
            var venda = ObterPorId(id);
            venda.AtualizarStatus(novoStatus);
            _vendaRepository.Atualizar(venda);
        }

        public void AdicionarItem(Guid vendaId, ItemDTO itemDto)
        {
            var venda = ObterPorId(vendaId);

            var item = new Item
            {
                Nome = itemDto.Nome!,
                Preco = itemDto.Preco,
                Quantidade = itemDto.Quantidade
            };

            venda.AdicionarItem(item);
            _vendaRepository.Atualizar(venda);
        }

        public void RemoverItem(Guid vendaId, Guid itemId)
        {
            var venda = ObterPorId(vendaId);
            venda.RemoverItem(itemId);
            _vendaRepository.Atualizar(venda);
        }

        public List<VendedorDTO> ObterTodosVendedores()
        {
            var vendas = _vendaRepository.ObterTodas();

            return [.. vendas
                .Where(v => v.Vendedor != null)
                .Select(v => v.Vendedor)
                .DistinctBy(v => v?.Cpf)
                .Select(v => new VendedorDTO
                {
                    Cpf = v?.Cpf,
                    Nome = v?.Nome,
                    Email = v?.Email,
                    Telefone = v?.Telefone
                })];
        }

        public List<ItemDTO> ObterTodosItens()
        {
            var vendas = _vendaRepository.ObterTodas();

            return vendas
                .SelectMany(v => v.Itens ?? new List<Item>())
                .Select(i => new ItemDTO
                {
                    Nome = i.Nome,
                    Preco = i.Preco,
                    Quantidade = i.Quantidade
                })
                .ToList();
        }
    }
}
