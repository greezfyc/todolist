using System;
using System.Runtime.Remoting.Proxies;

namespace Git.Todolist.Core.Aop
{
    /// <summary>
    /// AOP特性, 标识在进行AOP策略的类上
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AOPAttribute : ProxyAttribute
    {
        public override MarshalByRefObject CreateInstance(Type type)
        {
            MarshalByRefObject obj = base.CreateInstance(type);

            AOPProxy realProxy = new AOPProxy(type, obj);
            return realProxy.GetTransparentProxy() as MarshalByRefObject;
        }
    }
}
