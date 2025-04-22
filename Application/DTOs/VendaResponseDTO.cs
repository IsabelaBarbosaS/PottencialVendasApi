using System.Text.Json.Serialization;
using Pottencial.VendasApi.Domain;

namespace Pottencial.VendasApi.DTOs
{
    public class VendaResponseDTO
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public VendedorDTO? Vendedor { get; set; }
        public List<ItemDTO>? Itens { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusVenda Status { get; set; }

    }
}