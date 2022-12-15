using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteService.Model
{
    public class StoreAddressVO
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string CEP { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
    }
}
