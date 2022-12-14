using ClienteService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteService.Service
{
    public interface IClienteService
    {
        Task<List<ClienteModel>> ListarClientes();
        Task<ClienteModel> GetCliente(Guid id);
        Task<ClienteModel> CreateCliente(ClienteModel clienteModel);
        Task<ClienteModel> UpdateCliente(Guid id, ClienteModel clienteModel);
        Task<bool> DeleteCliente(Guid id);
    }
}
