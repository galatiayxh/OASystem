using log4net;
using Spring.Web.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApp.Models;

namespace WebApp
{
    public class MvcApplication : SpringMvcApplication//System.Web.Http Application
    {

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //����һ���̣߳�ɨ���쳣��Ϣ����
            String filePath = Server.MapPath("/Log/");
            ThreadPool.QueueUserWorkItem((a)=> {
                while (true) {
                    //�ж�һ�¶������Ƿ�������
                 
                    
                    if (MyExceptionAttribute.ExceptionQueue.Count() > 0) {
                        Exception ex = MyExceptionAttribute.ExceptionQueue.Dequeue();
                        if (ex != null)
                        {
                            //���쳣��Ϣд����־�ļ���
                            //String fileName = DateTime.Now.ToString("yyyy-MM-dd");
                            //File.AppendAllText(filePath + fileName + ".txt", ex.ToString(), System.Text.Encoding.UTF8);

                            ILog logger = LogManager.GetLogger("errorMsg");
                            logger.Error(ex.ToString());
                        }
                        else
                        {
                            //���������û�����ݣ���Ϣ
                            Thread.Sleep(3000);
                        }
                       
                    }
                    else
                    {
                        //���������û�����ݣ���Ϣ
                        Thread.Sleep(3000);
                    }
                }
            }, filePath);
        }
        //�쳣���������

    }
}
