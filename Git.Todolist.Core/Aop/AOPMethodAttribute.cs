using System;

namespace Git.Todolist.Core.Aop
{
    /// <summary>
    ///  AOP特性, 标识在进行AOP策略的方法上
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AOPMethodAttribute : Attribute
    {
        Type aopHandlerType = null;

        public AOPMethodAttribute(Type aopHandlerType)
        {
            this.aopHandlerType = aopHandlerType;
        }

        public Type AOPHandlerType
        {
            get
            {
                return this.aopHandlerType;
            }
        }

    }
}
