using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteService.Model
{
    public class LojaValueObject
    {
        public Guid Id { get; set; }
        public string StoreName { get; set; }
        public string Telephone { get; set; }
        public StoreAddressVO StoreAdress { get; set; }
        public List<ProductVO> Products { get; set; }
    }
}
