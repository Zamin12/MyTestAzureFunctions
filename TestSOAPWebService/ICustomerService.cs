using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TestSOAPWebService
{
    [ServiceContract]
    public interface ICustomerService
    {

        [OperationContract]
        Customer GetCustomerById(int id);

        [OperationContract]
        IEnumerable<Customer> GetCustomers();
    }

    [DataContract]
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }
    }
}
