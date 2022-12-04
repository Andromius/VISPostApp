using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Factory
{
    public class MapperFactory
    {
        public AddressDataMapper GetMapper()
        {
            return new AddressDataMapper();
        }
    }
}
