using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esoft
{
    public partial class Supply
    {
        public string AddressCity => (RealEstate.AddressCity == null) ? "" : RealEstate.AddressCity;
        public string AddressStreet => RealEstate.AddressStreet;
        public string AddressHouse => RealEstate.AddressHouse;
        public string AddressNumder => RealEstate.AddressNumder;

        public string NameAgent => $"{Agent.FirstName} {Agent.MiddleName} {Agent.LastName}";
        public string NameClient => $"{Client.FirstName} {Client.MiddleName} {Client.LastName}";
    }
}
