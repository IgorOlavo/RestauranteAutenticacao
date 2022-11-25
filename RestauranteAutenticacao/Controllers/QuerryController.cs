using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json.Linq;
using RestauranteAutenticacao.Models;
using RestauranteAutenticacao.Models.Consultas;
using System.Linq;

namespace RestauranteAutenticacao.Controllers
{
    public class QuerryController : Controller
    {
        private readonly Contexto contexto;

        public QuerryController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult Clientes(String nome)
        {
            List<Cliente> lista = new List<Cliente>();
            if (nome == null)
            {
                lista = contexto.Cliente.OrderBy(o => o.nome).ToList();
            } else
            {
                lista = contexto.Cliente.Where(c => c.nome == nome).ToList();
            }




            return View(lista);
        }


        public IActionResult PesquisaCliente()
        {
            return View();
        }

        public IActionResult Pedido()
        {
            IEnumerable<PedidoQuerry> lstPedido = from item in contexto.Pedido
                                                  .Include(o => o.cliente).Include(o => o.marmitas).Include(o => o.bebida)
                                                  .OrderBy(o => o.id)
                                                  .ToList()
                                                  select new PedidoQuerry
                                                  {
                                                      id = item.id,
                                                      cliente = item.cliente.nome,
                                                      bebida = item.bebida.descricao,
                                                      marmita = item.marmitas.descricao,
                                                      status = (item.status == 0)? "Entregue" : "Preparo",
                                                      preparo = item.tempoPedido,
                                                      endereco = item.cliente.endereco,
                                                      preco = item.marmitas.preco
                                                  };

            return View(lstPedido);
        }


        public IActionResult GroupByStatus()
        {
            IEnumerable<PedidoQuerry> lstPedido = from item in contexto.Pedido
                                                  .Include(o => o.cliente).Include(o => o.marmitas).Include(o => o.bebida)
                                                  .OrderBy(o => o.id)
                                                  .ToList()
                                                  select new PedidoQuerry
                                                  {
                                                      id = item.id,
                                                      cliente = item.cliente.nome,
                                                      bebida = item.bebida.descricao,
                                                      marmita = item.marmitas.descricao,
                                                      status = (item.status == 0) ? "Entregue" : "Preparo",
                                                      preparo = item.tempoPedido,
                                                      endereco = item.cliente.endereco,
                                                      preco = item.marmitas.preco
                                                  };


            IEnumerable<PedidoGroupStatus> lstGrpStatus = from linha in lstPedido.ToList()
                                                        group linha by new { linha.cliente, linha.status, linha.marmita }
                                                        into grupo
                                                        orderby grupo.Key.cliente
                                                        select new PedidoGroupStatus
                                                        {
                                                            cliente = grupo.Key.cliente,
                                                            status = grupo.Key.status,
                                                            marmita = grupo.Key.marmita,
                                                            preco = grupo.Sum(o => o.preco)
                                                        };

          

            return View(lstGrpStatus);
        }
    }
}
