using Coldairarrow.Util.Wcf;
using System;

namespace _01.WcfServer
{
    class Program
    {
        static void Main(string[] args)
        {
            WcfHost<Service, IService> wcfHost = new WcfHost<Service, IService>("http://localhost:14725", "http://localhost:14725/mex");

            wcfHost.HandleHostOpened = new Action<object, EventArgs>((obj, tar) =>
              {
                  Console.WriteLine("服务已启动！");
              });

            wcfHost.StartHost();

            while(Console.ReadLine()!="quit")
            {

            }
        }
    }
}
