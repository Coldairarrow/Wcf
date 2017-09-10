using System.ServiceModel;

namespace _01.WcfServer
{
    /// <summary>
    /// 对外提供的接口规范，必须要ServiceContract特性
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        /// <summary>
        /// 对外提供的接口方法，必须OperationContract特性，方法不能重载
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string Hello();
    }
}
