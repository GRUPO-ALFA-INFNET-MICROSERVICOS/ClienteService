using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClienteService.Model;

namespace ClienteService.Repositorio
{
    public interface IClienteRepositorio
    {
        Task<List<ClienteModel>> ListarClientes();
        Task<ClienteModel> GetCliente(Guid id);
        Task<ClienteModel> CreateCliente(ClienteModel clienteModel);
        Task<ClienteModel> UpdateCliente(Guid id, ClienteModel clienteModel);
        Task<bool> DeleteCliente(Guid id);
    }
}
