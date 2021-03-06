﻿using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading.Tasks;

namespace Coldairarrow.Util.Wcf
{
    /// <summary>
    /// Wcf服务代码控制类（必须开启管理员权限）
    /// </summary>
    /// <typeparam name="Service">服务处理</typeparam>
    /// <typeparam name="IService">服务接口</typeparam>
    public class WcfHost<Service,IService>
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseUrl">http基地址（服务器真实地址）,默认为:http://127.0.0.1:14725/ </param>
        /// <param name="httpGetUrl">http获取服务引用的地址（服务器真实地址）,默认为:http://127.0.0.1:14725/mex </param>
        public WcfHost(string baseUrl= "http://127.0.0.1:14725/", string httpGetUrl= "http://127.0.0.1:14725/mex")
        {
            _serviceHost = new ServiceHost(typeof(Service), new Uri(baseUrl));
            //ServiceEndPoint 终结点 包含Address地址 Binding绑定 Contracts契约 简称ABC
            _serviceHost.AddServiceEndpoint(typeof(IService), new WSHttpBinding(), typeof(Service).Name);
            //添加服务终结点
            if (_serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
            {
                //判断是否在配置文件中定义了元数据终结点
                ServiceMetadataBehavior metaData = new ServiceMetadataBehavior();
                metaData.HttpGetEnabled = true;
                metaData.HttpGetUrl = new Uri(httpGetUrl);
                _serviceHost.Description.Behaviors.Add(metaData);//添加元数据终结点
            }
        }

        #endregion

        #region 私有成员

        private ServiceHost _serviceHost;

        #endregion

        #region 外部接口

        /// <summary>
        /// 开始Wcf服务
        /// </summary>
        public void StartHost()
        {
            Task task = new Task(() =>
            {
                try
                {
                    if (HandleHostOpened != null)
                        _serviceHost.Opened += new EventHandler(HandleHostOpened);

                    if (_serviceHost.State != CommunicationState.Opened)
                    {
                        _serviceHost.Open();
                    }
                }
                catch (Exception ex)
                {
                    HandleException?.Invoke(ex);
                }
            });
            task.Start();
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 当Wcf服务开启后执行
        /// </summary>
        public Action<object, EventArgs> HandleHostOpened { get; set; }

        /// <summary>
        /// 异常处理
        /// </summary>
        public Action<Exception> HandleException { get; set; }

        #endregion
    }
}
