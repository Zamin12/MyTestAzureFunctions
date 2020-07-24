using System;

namespace GetCustomerDataFromSOAPTestFunction
{
    public static class Config
    {
        public static string WcfServiceEndpoint => Environment.GetEnvironmentVariable("WcfServiceEndpoint");
    }
}
