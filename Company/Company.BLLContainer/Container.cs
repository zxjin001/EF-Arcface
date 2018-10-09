using Autofac;
using Company.BLL;
using Company.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLLContainer
{
    public class Container
    {
        /// <summary>
        /// IOC 容器
        /// </summary>
        public static IContainer container = null;

        /// <summary>
        /// 获取 IDal 的实例化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IService Resolve<Service, IService>()
        {
            try
            {
                if (container == null)
                {
                    Initialise<Service, IService>();
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("IOC实例化出错!" + ex.Message);
            }

            return container.Resolve<IService>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialise<Service, IService>()
        {
            var builder = new ContainerBuilder();
            //格式：builder.RegisterType<xxxx>().As<Ixxxx>().InstancePerLifetimeScope();
            builder.RegisterType<Service>().As<IService>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}
