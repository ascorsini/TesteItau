using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteApiItau.Models;

namespace TesteApiItau.Controllers
{
    public class LocacaoController : ApiController
    {
        private static List<Locacao> ListaLocacao = new List<Locacao>();

        public List<Locacao> Get()
        {
            return ListaLocacao;
        }

        [Route("api/Locacao/AlugarFilme")]
        [HttpPost]
        public void AlugarFilme(int idFilme, int idCliente)
        {
            FilmeController fc = new FilmeController();

            if (!fc.VerificarFilme(idFilme))
            {
                fc.BloquearFilme(idFilme);
                CadastrarLocacao(idFilme, idCliente);
            }
        }

        [Route("api/Locacao/DevolverFilme")]
        [HttpPost]
        public string DevolverFilme(int idFilme)
        {
            FilmeController fc = new FilmeController();
            fc.LiberarFilme(idFilme);
            Locacao locacao = ListaLocacao.First(x => x.idFilme.Equals(idFilme));

            ListaLocacao[locacao.id].Status = false;

            if (locacao.InicioLocacao.AddDays(locacao.Diarias) >= DateTime.Now)
                return "Entrega dentro do prazo";
            else
                return "Entrega com atraso";
        }

        public void CadastrarLocacao(int idFilme, int idCliente)
        {
            Locacao locacao = new Locacao();
            locacao.id = ListaLocacao.Count() + 1;
            locacao.idCliente = idCliente;
            locacao.idFilme = idFilme;
            locacao.InicioLocacao = DateTime.Now;
            locacao.Status = true;
            locacao.Diarias = 1;

            ListaLocacao.Add(locacao);
        }
    }
}
