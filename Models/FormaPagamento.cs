using System;

namespace API.Models
{
    public class FormaPagamento
    {
        public FormaPagamento() => CriadoEm = DateTime.Now;
        public int FormaPagamentoId { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}