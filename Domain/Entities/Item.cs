using System;

namespace Pottencial.VendasApi.Domain
{
    public class Item
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}