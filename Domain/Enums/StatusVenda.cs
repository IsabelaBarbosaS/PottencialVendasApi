namespace Pottencial.VendasApi.Domain
{
    public enum StatusVenda
    {
        AguardandoPagamento,
        PagamentoAprovado,
        EnviadoParaTransportadora,
        Entregue,
        Cancelada
    }
}