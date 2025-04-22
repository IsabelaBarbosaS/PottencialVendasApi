using System;
using System.Collections.Generic;
using Pottencial.VendasApi.Application.Services;
using Pottencial.VendasApi.Domain;
using Pottencial.VendasApi.DTOs;
using Pottencial.VendasApi.Repositories;
using Xunit;

namespace Pottencial.VendasApi.Tests
{
    public class VendaServiceTests
    {
        private readonly VendaService _service;
        private readonly IVendaRepository _repository;

        public VendaServiceTests()
        {
            _repository = new VendaMemoryRepository();
            _service = new VendaService(_repository);
        }

        [Fact]
        public void CriarVenda_DeveCriarVendaComSucesso()
        {
            // Arrange
            var dto = new VendaRequestDTO
            {
                Vendedor = new VendedorDTO
                {
                    Nome = "Maria",
                    Cpf = "12345678900",
                    Email = "maria@email.com",
                    Telefone = "11999999999"
                },
                Itens = new List<ItemDTO>
                {
                    new ItemDTO { Nome = "Produto A", Preco = 100, Quantidade = 1 }
                }
            };

            // Act
            var venda = _service.CriarVenda(dto);

            // Assert
            Assert.NotNull(venda);
            Assert.Equal(StatusVenda.AguardandoPagamento, venda.Status);
        }

        [Fact]
        public void CriarVenda_SemItens_DeveLancarExcecao()
        {
            var dto = new VendaRequestDTO
            {
                Vendedor = new VendedorDTO
                {
                    Nome = "João",
                    Cpf = "12345678900",
                    Email = "joao@email.com",
                    Telefone = "11999999999"
                },
                Itens = new List<ItemDTO>()
            };

            Assert.Throws<ArgumentException>(() => _service.CriarVenda(dto));
        }

        [Fact]
        public void AtualizarStatus_ParaStatusValido_DeveAtualizar()
        {
            var venda = _service.CriarVenda(new VendaRequestDTO
            {
                Vendedor = new VendedorDTO
                {
                    Nome = "Carlos",
                    Cpf = "12345678900",
                    Email = "carlos@email.com",
                    Telefone = "11999999999"
                },
                Itens = new List<ItemDTO>
                {
                    new ItemDTO { Nome = "Produto X", Preco = 50, Quantidade = 2 }
                }
            });

            _service.AtualizarStatus(venda.Id, StatusVenda.PagamentoAprovado);

            var atualizada = _service.ObterPorId(venda.Id);
            Assert.Equal(StatusVenda.PagamentoAprovado, atualizada.Status);
        }

        [Fact]
        public void AtualizarStatus_ParaStatusInvalido_DeveLancarExcecao()
        {
            var venda = _service.CriarVenda(new VendaRequestDTO
            {
                Vendedor = new VendedorDTO
                {
                    Nome = "Roberta",
                    Cpf = "12345678900",
                    Email = "roberta@email.com",
                    Telefone = "11999999999"
                },
                Itens = new List<ItemDTO>
                {
                    new ItemDTO { Nome = "Produto Y", Preco = 80, Quantidade = 1 }
                }
            });

            Assert.Throws<InvalidOperationException>(() =>
                _service.AtualizarStatus(venda.Id, StatusVenda.Entregue));
        }
    }
}