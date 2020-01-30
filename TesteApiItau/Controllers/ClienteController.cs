using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteApiItau.Models;

namespace TesteApiItau.Controllers
{
    public class ClienteController : ApiController
    {
        private static List<Cliente> ListaClientes = new List<Cliente>();

        public List<Cliente> Get()
        {
            return ListaClientes;
        }

        [Route("api/Cliente/CadastrarCliente")]
        [HttpPost]
        public void CadastrarCliente(string NomeCliente)
        {
            if (!string.IsNullOrEmpty(NomeCliente))
            {
                if (!VerificarCliente(NomeCliente))
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = ListaClientes.Count();
                    cliente.Nome = NomeCliente;

                    ListaClientes.Add(cliente);
                }
            }
        }

        public bool VerificarCliente(string NomeCliente)
        {
            bool res = false;

            for(int i=0;i< ListaClientes.Count();i++)
            {
                if (NomeCliente == ListaClientes[i].Nome)
                    res = true;
            }

            return res;
        }
    }
}
