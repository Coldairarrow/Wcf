using System;

namespace _02.WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();
            var data = client.Hello();
            Console.WriteLine(data);

            Console.ReadKey();
        }
    }
}
