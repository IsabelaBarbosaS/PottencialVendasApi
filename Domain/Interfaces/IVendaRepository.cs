using System;
using Pottencial.VendasApi.Domain;

namespace Pottencial.VendasApi.Repositories
{
    public interface IVendaRepository
    {
        void Adicionar(Venda venda);
        Venda? ObterPorId(Guid id);
        void Atualizar(Venda venda);
        List<Venda> ObterTodas();

    }
}