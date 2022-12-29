using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteService.Model
{
    public class MongoHelper
    {
        public static IMongoClient client { get; set; }

        public static IMongoDatabase database { get; set; }

        public static string ConnectionString = "mongodb+srv://admin:guigui-123@cliente-service.lgmrsda.mongodb.net/?retryWrites=true&w=majority";

        public static string MongoDatabase = "cliente-service";

        public static IMongoCollection<ClienteModel> ClienteCollection { get; set; }
        internal static void ConnectMongoService()
        {
            try
            {
                client = new MongoClient(ConnectionString);
                database = client.GetDatabase(MongoDatabase);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
