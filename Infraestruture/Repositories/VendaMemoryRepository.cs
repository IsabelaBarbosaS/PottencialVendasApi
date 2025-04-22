using System;
using System.Collections.Generic;
using Pottencial.VendasApi.Domain;

namespace Pottencial.VendasApi.Repositories
{
    public class VendaMemoryRepository : IVendaRepository
    {
        private static readonly Dictionary<Guid, Venda> _vendas = new();

        public void Adicionar(Venda venda)
        {
            _vendas.Add(venda.Id, venda);
        }

        public Venda? ObterPorId(Guid id)
        {
            _vendas.TryGetValue(id, out var venda);
            return venda;
        }

        public void Atualizar(Venda venda)
        {
            if (_vendas.ContainsKey(venda.Id))
                _vendas[venda.Id] = venda;
        }

        public List<Venda> ObterTodas()
        {
            return _vendas.Values.ToList();
        }

    }
}