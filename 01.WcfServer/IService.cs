using System.ServiceModel;

namespace _01.WcfServer
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string Hello();
    }
}
