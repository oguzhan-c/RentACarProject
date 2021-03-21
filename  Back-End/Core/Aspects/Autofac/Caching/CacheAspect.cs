using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private readonly ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType?.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            // iki tane ? : varsa solundakini yoksa sağındakini ekler burda varsa metot içindeki argümanları virgülle ayırarak ekler
            // yoksa null ekler 
            if (_cacheManager.IsAdd(key))
            {
                //ReturnValue bura invocation'Metot' nın return değeri gelen metotdaki return olmasında
                // invocation.ReturnValue nın karşısına gelen şey olsun.
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            //metot daha önce çağırılmadığı için databaseden getirildi ve cache e eklendi
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
