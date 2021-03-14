using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstruct;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstruct.DataAcessLayers;
using DataAccess.Concrete.EntityFremavork.DataAcessLayers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IoCConfigration.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<CommunicationManager>().As<ICommunicationService>().SingleInstance();
            builder.RegisterType<EfCommunicationDal>().As<ICommunicationDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<PurchaseManager>().As<IPurchaseService>().SingleInstance();
            builder.RegisterType<EfPurchaseDal>().As<IPurchaseDal>().SingleInstance();

            builder.RegisterType<RentManager>().As<IRentService>().SingleInstance();
            builder.RegisterType<EfRentDal>().As<IRentDal>().SingleInstance();

            builder.RegisterType<SaleManager>().As<ISaleService>().SingleInstance();
            builder.RegisterType<EfSaleDal>().As<ISaleDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
