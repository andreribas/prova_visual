using System;
using System.Collections.Generic;

namespace API.Models
{
    public class FormaPagamento
    {
        public int FormaPagamentoId { get; set; }
        public string Tipo { get; set; }
        public string Bandeira { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}