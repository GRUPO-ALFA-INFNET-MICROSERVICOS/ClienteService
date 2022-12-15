using ClienteService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClienteService.Service
{
    public class LojaService : ILojaService
    {
        private readonly HttpClient _client;

        public LojaService(HttpClient client)
        {
            _client = client;
        }
        public const string basePath = "Store";
        public async Task<List<LojaValueObject>> GetAllLojas()
        {
            var lojas = await _client.GetAsync(basePath);
            return await lojas.ReadContentAs<List<LojaValueObject>>();
        }

       
    }
}
