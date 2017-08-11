using System;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Services;
using System.Runtime.Remoting;


namespace Git.Todolist.Core.Aop
{
    /// <summary>
    /// AOP代理
    /// </summary>
    public class AOPProxy : RealProxy
    {
        MarshalByRefObject target = null;
        public AOPProxy(Type type, MarshalByRefObject target)
            : base(type)
        {
            this.target = target;
        }

        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage call = (IMethodCallMessage)msg;
            IConstructionCallMessage ctor = call as IConstructionCallMessage;
            IMethodReturnMessage returnMsg = null;
            if (ctor != null)
            {
                //获取最底层的默认真实代理  
                RealProxy defaultRealProxy = RemotingServices.GetRealProxy(target);

                defaultRealProxy.InitializeServerObject(ctor);
                MarshalByRefObject tp = (MarshalByRefObject)this.GetTransparentProxy();

                returnMsg = EnterpriseServicesHelper.CreateConstructionReturnMessage(ctor, tp);
            }
            else
            {
                IMethodMessage method = (IMethodMessage)msg;
                Type aopHandlerType = null;
                foreach (Attribute attr in call.MethodBase.GetCustomAttributes(false))
                {
                    AOPMethodAttribute methodAopAttr = attr as AOPMethodAttribute;
                    if (methodAopAttr != null)
                    {
                        aopHandlerType = methodAopAttr.AOPHandlerType;
                        break;
                    }
                }

                if (aopHandlerType != null)
                {
                    IAOPHandler proxyHandler = (IAOPHandler)Activator.CreateInstance(aopHandlerType);
                    AOPArgs args = new AOPArgs();
                    args.Args = method.Args;
                    args.CallMethod = method.MethodBase;
                    args.ExecuteID = Guid.NewGuid();
                    if (!proxyHandler.OnEntry(args))
                    {
                        return returnMsg;
                    }
                    returnMsg = RemotingServices.ExecuteMessage(target, call);
                    if (returnMsg.Exception != null)
                    {
                        args.Exception = returnMsg.Exception;
                        proxyHandler.OnException(args);
                    }
                    else
                    {
                        args.ReturnValue = returnMsg.ReturnValue;
                        proxyHandler.OnExit(args);
                    }
                }
                else
                {
                    returnMsg = RemotingServices.ExecuteMessage(target, call);
                }
            }

            return returnMsg;

        }
    }
}
