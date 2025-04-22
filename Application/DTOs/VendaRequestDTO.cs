using System.Collections.Generic;

namespace Pottencial.VendasApi.DTOs
{
    public class VendaRequestDTO
    {
        public VendedorDTO? Vendedor { get; set; }
        public List<ItemDTO>? Itens { get; set; }
    }
}