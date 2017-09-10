using System;

namespace _02.WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //ServiceReference1为引用时自定义的命名空间
            //ServiceClient为具体实现类，Service为类名，Client为后缀
            //可以在很多地方使用，比如控制台，Winform,ASP.NET网站等，把它当做一个类库就很好理解了66666
            ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();

            //调用Service提供的Hello方法,Wcf服务端必须运行
            var data = client.Hello();
            Console.WriteLine(data);

            Console.ReadKey();
        }
    }
}
