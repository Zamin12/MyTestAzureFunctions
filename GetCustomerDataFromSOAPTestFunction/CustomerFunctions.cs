using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using TestSOAPServiceProxy.CustomerServiceReference;

namespace GetCustomerDataFromSOAPTestFunction
{
    public static class GetCustomerByIdFunction
    {
        [FunctionName("GetCustomerById")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string id = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "id", true) == 0)
                .Value;

            if (id == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                id = data?.name;
            }

            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            var endpoint = new EndpointAddress(Config.WcfServiceEndpoint);

            using (var client = new CustomerServiceClient(binding, endpoint))
            {
                // If necessary, username and password should be provided.
                //client.ClientCredentials.UserName.UserName = "username";
                //client.ClientCredentials.UserName.Password = "password";

                var result = await client.GetCustomerByIdAsync(int.Parse(id)).ConfigureAwait(false);

                log.Info($"{result} received.");

                return req.CreateResponse(HttpStatusCode.OK, result);
            }

        }
    }
}
