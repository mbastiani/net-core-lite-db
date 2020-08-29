using System;
using System.Collections.Generic;

namespace NetCoreLiteDB.Models
{
    public class Pessoa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public Endereco Endereco { get; set; }
        public IEnumerable<Telefone> Telefones { get; set; }
    }
}