using System.Text.Json.Serialization;
using Pottencial.VendasApi.Helpers;

namespace Pottencial.VendasApi.Domain
{
    public class Venda
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Vendedor? Vendedor { get; set; }
        public List<Item> Itens { get; set; } = new List<Item>();
        public DateTime Data { get; set; } = DateTime.UtcNow;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusVenda Status { get; private set; } = StatusVenda.AguardandoPagamento;


        public void AdicionarItem(Item item)
        {
            if (Status != StatusVenda.AguardandoPagamento)
                throw new InvalidOperationException(MensagensErro.ItensApenasEmAguardandoPagamento);

            Itens.Add(item);
        }

        public void RemoverItem(Guid itemId)
        {
            if (Status != StatusVenda.AguardandoPagamento)
                throw new InvalidOperationException(MensagensErro.ItensApenasEmAguardandoPagamento);

            if (Itens.Count <= 1)
                throw new InvalidOperationException(MensagensErro.VendaPrecisaTerAoMenosUmItem);

            Itens.RemoveAll(i => i.Id == itemId);
        }

        public void AtualizarStatus(StatusVenda novoStatus)
        {
            if (!ValidadorStatus.PodeAtualizar(Status, novoStatus))
                throw new InvalidOperationException(MensagensErro.StatusInvalido);

            Status = novoStatus;
        }
    }
}