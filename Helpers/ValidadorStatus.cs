using Pottencial.VendasApi.Domain;

namespace Pottencial.VendasApi.Helpers
{
    public static class ValidadorStatus
    {
        public static bool PodeAtualizar(StatusVenda atual, StatusVenda novo)
        {
            return (atual == StatusVenda.AguardandoPagamento && 
                        (novo == StatusVenda.PagamentoAprovado || novo == StatusVenda.Cancelada)) ||
                   (atual == StatusVenda.PagamentoAprovado && 
                        (novo == StatusVenda.EnviadoParaTransportadora || novo == StatusVenda.Cancelada)) ||
                   (atual == StatusVenda.EnviadoParaTransportadora && novo == StatusVenda.Entregue);
        }
    }
}