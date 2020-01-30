using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteApiItau.Models;

namespace TesteApiItau.Controllers
{
    public class FilmeController : ApiController
    {
        private static List<Filme> ListaFilmes = new List<Filme>();

        public List<Filme> Get()
        {
            return ListaFilmes;
        }

        [Route("api/Filme/CadastrarFilme")]
        [HttpPost]
        public void CadastrarFilme(string NomeFilme)
        {
            Filme filme = new Filme();
            filme.Id = ListaFilmes.Count();
            filme.Nome = NomeFilme;
            filme.Status = false;

            ListaFilmes.Add(filme);
        }

        public bool VerificarFilme(int idFilme)
        {
            Filme filme = ListaFilmes[idFilme];

            if (filme.Status)
                return true;
            else
                return false;
        }

        public void BloquearFilme(int idFilme)
        {
            ListaFilmes[idFilme].Status = true;
        }

        public void LiberarFilme(int idFilme)
        {
            ListaFilmes[idFilme].Status = false;
        }
    }
}
