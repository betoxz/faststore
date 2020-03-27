using Microsoft.AspNetCore.Mvc;
using Pedidos.Domain.LojaContexto.Queries;
using Pedidos.Domain.LojaContexto.Repositorios;

namespace Pedidos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteController(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("v1/clientes/{cpf}")]
        public GetClienteQueryResult GetByCpf(string cpf)
        {
            return _repositorio.Get(cpf);
        }
    }
}
