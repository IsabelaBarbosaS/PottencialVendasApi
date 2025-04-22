namespace Pottencial.VendasApi.Helpers
{
    public static class MensagensErro
    {
        public const string VendaNaoEncontrada = "Venda não encontrada.";
        public const string SemItens = "A venda deve conter pelo menos um item.";
        public const string StatusInvalido = "Transição de status inválida.";
        public const string ItensApenasEmAguardandoPagamento = "Itens só podem ser alterados enquanto a venda estiver 'Aguardando Pagamento'.";
        public const string VendaPrecisaTerAoMenosUmItem = "A venda deve conter pelo menos 1 item.";
    }
}