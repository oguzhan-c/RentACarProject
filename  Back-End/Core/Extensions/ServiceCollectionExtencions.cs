using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtencions
    {
        //IServiceCollection : Apı nin servis bağımlılıklarının eklendiği
        //veya araya girmesini istediğimiz servisleri eklediğimiz bir collections tur.
        //this neyi genişletmek istefiğimizi belirtir
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection , ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
