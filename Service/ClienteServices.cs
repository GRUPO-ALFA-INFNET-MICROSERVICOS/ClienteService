using ClienteService.Model;
using ClienteService.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteService.Service
{
    public class ClienteServices : IClienteService
    {
        private IClienteRepositorio _repositorio;

        public ClienteServices(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ClienteModel> CreateCliente(ClienteModel clienteModel)
        {
            var cliente = _repositorio.CreateCliente(clienteModel);
            return await cliente;
        }

        public async Task<bool> DeleteCliente(Guid id)
        {
            var resultado = _repositorio.DeleteCliente(id);
            return await resultado;
        }

        public async Task<ClienteModel> GetCliente(Guid id)
        {
            var cliente = _repositorio.GetCliente(id);
            return await cliente;
        }

        public async Task<List<ClienteModel>> ListarClientes()
        {
            var listaClientes = _repositorio.ListarClientes();
            return await listaClientes;
        }

        public async Task<ClienteModel> UpdateCliente(Guid id , ClienteModel clienteModel)
        {
            var cliente = _repositorio.UpdateCliente(id,clienteModel);
            return await cliente;
        }
    }
}
