using ClienteService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteService.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        static List<ClienteModel> listaClientes = new List<ClienteModel>();
       
        public async Task<ClienteModel> CreateCliente(ClienteModel clienteModel)
        {
            listaClientes.Add(clienteModel);
            return await Task.FromResult(clienteModel);
        }

        public async Task<bool> DeleteCliente(Guid id)
        {
            if (id != null)
            {
                var cliente = GetCliente(id).Result;
                listaClientes.Remove(cliente);
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<ClienteModel> GetCliente(Guid id)
        {
            var cliente = Task.FromResult(listaClientes.Where(x => x.Id == id).FirstOrDefault());
            return await cliente;
        }

        public async Task<List<ClienteModel>> ListarClientes()
        {
            return await Task.FromResult(listaClientes);
        }

        public async Task<ClienteModel> UpdateCliente(Guid id,ClienteModel clienteModel)
        {
            await DeleteCliente(id);
            listaClientes.Add(clienteModel);
            return await Task.FromResult(clienteModel);
        }
    }
}
