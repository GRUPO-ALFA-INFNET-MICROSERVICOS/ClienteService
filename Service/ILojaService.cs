using ClienteService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteService.Service
{
    public interface ILojaService
    {
        Task<List<LojaValueObject>> GetAllLojas();

       //Task<List<LojaValueObject>> GetLojaPorCEP(string cep);
    }
}
