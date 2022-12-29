using ClienteService.Model;
using MongoDB.Driver;
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

            MongoHelper.ConnectMongoService();
            MongoHelper.ClienteCollection = MongoHelper.database.GetCollection<ClienteModel>("clientes");
            await MongoHelper.ClienteCollection.InsertOneAsync(clienteModel);
            listaClientes.Add(clienteModel);
           
            return await Task.FromResult(clienteModel);
        }

        public async Task<bool> DeleteCliente(Guid id)
        {
            if (id != null)
            {
                var collection = MongoHelper.ClienteCollection = MongoHelper.database.GetCollection<ClienteModel>("clientes");
                var result = collection.DeleteOne(client => client.Id == id);
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<ClienteModel> GetCliente(Guid id)
        {
            MongoHelper.ConnectMongoService();
            MongoHelper.ClienteCollection = MongoHelper.database.GetCollection<ClienteModel>("clientes");
            var filter = Builders<ClienteModel>.Filter.Eq("_id", id);
            var result = Task.FromResult(MongoHelper.ClienteCollection.Find(filter).FirstOrDefault());
            return await result;
        }

        public async Task<List<ClienteModel>> ListarClientes()
        {
            MongoHelper.ConnectMongoService();
            MongoHelper.ClienteCollection = MongoHelper.database.GetCollection<ClienteModel>("clientes");
            var filter = Builders<ClienteModel>.Filter.Ne("_id", "");
            var result = MongoHelper.ClienteCollection.FindAsync(filter).Result.ToListAsync();
            return await result;
        }

        public async Task<ClienteModel> UpdateCliente(Guid id,ClienteModel clienteModel)
        {
            var cliente = GetCliente(id).Result;
            var collection = MongoHelper.database.GetCollection<ClienteModel>("clientes");
            collection.ReplaceOne(cliente => cliente.Id == id, clienteModel);
            return await Task.FromResult(clienteModel);
            
        }
    }
}
