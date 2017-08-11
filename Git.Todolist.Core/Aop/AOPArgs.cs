using System;
using System.Reflection;

namespace Git.Todolist.Core.Aop
{
    /// <summary>
    /// AOP截获的参数
    /// </summary>
    public class AOPArgs
    {
        public MethodBase CallMethod { get; set; }

        public object[] Args { get; set; }

        public object ReturnValue { get; set; }

        public Exception Exception { get; set; }

        public Guid ExecuteID { get; set; }
    }
}
