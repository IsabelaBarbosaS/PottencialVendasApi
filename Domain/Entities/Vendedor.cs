using System;

namespace Pottencial.VendasApi.Domain
{
    public class Vendedor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
    }
}