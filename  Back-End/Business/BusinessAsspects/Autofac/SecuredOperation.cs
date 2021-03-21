using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstruct;
using Business.Constat;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using DataAccess.Concrete.EntityFremavork.DataAcessLayers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAsspects.Autofac
{
    //JWT için
    public class SecuredOperation : MethodInterception
    {
        private readonly string[] _roles;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split('/');//metni senin belirttiğin karaktere göre ayırıp arry e atıyor
            //IUserService = ServiceTool.ServiceProvider.GetService<IUserService>();
            //form uygulamalarında injections ları bu şekilde yap
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(AspectMessages.AuthorizationDenied);
        }
    }
}
