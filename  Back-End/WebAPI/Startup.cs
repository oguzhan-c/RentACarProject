
using Business.Abstruct;
using Business.Concrete;
using DataAccess.Abstruct.DataAcessLayers;
using DataAccess.Concrete.EntityFremavork.DataAcessLayers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //IoC Container eðer baðýmlýlýk "Dependency" görürsen virgülden sonra gelen yeri arka planda newler
            //Singleton data kullanýlanlarda kullanýlmaz  iyi performans verir
            //Singelton kullanýlarak IoC Containerler eklendi ve bu Containerler Tüm Cleintler için kullanýlabilir
            //Autofac kullanýlarak yapýldý
            //services.AddSingleton</*Dependency*/ICarService,CarManager>();
            //services.AddSingleton<ICarDal, EfCarDal>();
            //services.AddSingleton<ICommunicationService, CommunicationManager>();
            //services.AddSingleton<ICommunicationDal,EfCommunicationDal>();
            //services.AddSingleton<ICustomerService,CustomerManager>();
            //services.AddSingleton<ICustomerDal,EfCustomerDal>();
            //services.AddSingleton<IPurchaseService,PurchaseManager>();
            //services.AddSingleton<IPurchaseDal,EfPurchaseDal>();
            //services.AddSingleton<IRentService,RentManager>();
            //services.AddSingleton<IRentDal, EfRentDal>();
            //services.AddSingleton<ISaleService,SaleManager>();
            //services.AddSingleton<ISaleDal,EfSaleDal>();
            //services.AddSingleton<IUserService, UserManager>();
            //services.AddSingleton<IUserDal, EfUserDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
