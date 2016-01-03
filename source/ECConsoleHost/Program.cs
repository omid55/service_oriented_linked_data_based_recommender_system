using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using ECommerceServiceLibrary;

namespace ECConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ECommerceService)))
            {
                host.Open();

                Console.WriteLine("Service is started and now listening on address(es) :");
                foreach (var endpoint in host.Description.Endpoints)
                {
                    Console.WriteLine(" {0}   ({1})  ({2})", endpoint.Address, endpoint.Binding.Name, endpoint.Name);
                }

                Console.WriteLine("\n\nPress Any Key To Terminate The Service(s) ...");
                Console.ReadKey();
            }
        }
    }
}
