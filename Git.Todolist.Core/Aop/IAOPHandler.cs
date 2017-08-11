using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Todolist.Core.Aop
{
    /// <summary>
    /// AOP策略接口, 所有AOP策略都要实现此接口
    /// </summary>
    public interface IAOPHandler
    {
        /// <summary>
        /// 当进入方法时运行
        /// </summary>
        /// <param name="arg"></param>
        bool OnEntry(AOPArgs arg);

        /// <summary>
        /// 当退出方法时运行
        /// </summary>
        /// <param name="arg"></param>
        void OnExit(AOPArgs arg);

        /// <summary>
        /// 当发生异常时运行
        /// </summary>
        /// <param name="arg"></param>
        void OnException(AOPArgs arg);
    }
}
