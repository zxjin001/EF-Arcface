using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DAL;
using Company.IDAL;

namespace Company.DALContainer
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
        /// <typeparam name="IDal"></typeparam>
        /// <returns></returns>
        public static IDal Resolve<Dal, IDal>()
        {
            try
            {
                if (container == null)
                {
                    Initialise<Dal, IDal>();
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("IOC实例化出错!" + ex.Message);
            }

            return container.Resolve<IDal>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialise<Dal, IDal>()
        {
            var builder = new ContainerBuilder();
            //格式：builder.RegisterType<xxxx>().As<Ixxxx>().InstancePerLifetimeScope();
            builder.RegisterType<Dal>().As<IDal>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}
