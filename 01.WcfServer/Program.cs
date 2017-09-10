using Coldairarrow.Util.Wcf;
using System;

namespace _01.WcfServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建Wcf服务对象，泛型参数Service为实现类，IService为服务接口
            //第一个参数baseUrl为服务基地址（必须为真实地址）
            //第二个参数httpGetUrl为服务引用地址（必须为真实地址）,也就是客户端添加服务引用时用的地址
            WcfHost<Service, IService> wcfHost = new WcfHost<Service, IService>("http://localhost:14725", "http://localhost:14725/mex");

            //当Wcf服务开启后执行的事件
            wcfHost.HandleHostOpened = new Action<object, EventArgs>((obj, tar) =>
              {
                  Console.WriteLine("服务已启动！");
              });

            //开始Wcf服务
            wcfHost.StartHost();

            while(Console.ReadLine()!="quit")
            {

            }
        }
    }
}
