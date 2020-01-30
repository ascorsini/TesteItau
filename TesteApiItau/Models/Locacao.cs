using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteApiItau.Models
{
    public class Locacao
    {
        public int id { get; set; }
        public int idFilme { get; set; }
        public int idCliente { get; set; }
        public bool Status { get; set; }
        public DateTime InicioLocacao { get; set; }
        public int Diarias { get; set; }
    }
}