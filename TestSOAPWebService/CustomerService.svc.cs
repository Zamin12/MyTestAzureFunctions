using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TestSOAPWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {
        public Customer GetCustomerById(int id)
        {
            return new Customer() { Id = 1, Name = "Zamin" + id, Surname = "Ismayilov" };
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer> { new Customer() { Id = 1, Name = "Zamin", Surname = "Ismayilov" }, new Customer() { Id = 2, Name = "Test", Surname = "Testli" } };
        }
    }
}
