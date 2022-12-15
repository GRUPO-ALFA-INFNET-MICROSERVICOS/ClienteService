using ClienteService.Model;
using ClienteService.Repositorio;
using ClienteService.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClienteService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ClienteController : ControllerBase
    {
        private IClienteService _clienteServices;
        private ILojaService _lojaService;

        public ClienteController(IClienteService clienteServices, ILojaService lojaService)
        {
            _clienteServices = clienteServices;
            _lojaService = lojaService;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<List<ClienteModel>> GetAll()
        {
           var listaClientes = _clienteServices.ListarClientes();
           return await listaClientes;

        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> GetCliente(Guid id)
        {
                
            var cliente = _clienteServices.GetCliente(id);
            if (cliente.Result == null)
            {
                return BadRequest();
            }
            else
            {
                return await cliente;
            }  
           
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult<ClienteModel>> Post([FromBody] ClienteModel clienteModel)
        {
            clienteModel.Id = Guid.NewGuid();
            var cliente = _clienteServices.CreateCliente(clienteModel);

            return await cliente;
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<ClienteModel> Put(Guid id ,[FromBody] ClienteModel clienteModel)
        {
            if (_clienteServices.GetCliente(id) != null)
            {
                clienteModel.Id = id;
                var cliente = _clienteServices.UpdateCliente(id,clienteModel);
                return await cliente;
            }
            else
            {
                return clienteModel;
            }
        }


        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            if (_clienteServices.GetCliente(id) != null)
            {
                await _clienteServices.DeleteCliente(id);
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpGet("loja")]
        public async Task<List<LojaValueObject>> GetAllLojas()
        { 
            var listaLojas = _lojaService.GetAllLojas();
            
            return await listaLojas;
        }

    }
}
