using System.Diagnostics;
using Git.Todolist.Core;
using Git.Todolist.Core.Aop;

namespace Git.Todolist.Core.Aop
{
    /// <summary>
    /// AOP日志策略
    /// </summary>
    public class AOPLogHandler : IAOPHandler
    {
        private Stopwatch sw = new Stopwatch();

        public bool OnEntry(AOPArgs arg)
        {
            sw.Start();
            return true;
        }

        public void OnExit(AOPArgs arg)
        {
            sw.Stop();
            string id = arg.ExecuteID.ToString();
            string type = arg.CallMethod.DeclaringType.ToString();
            string method = arg.CallMethod.ToString();
            string args = JsonSerializer(arg.Args);
            string returnValue = GetReturnValue(arg.ReturnValue);
            long elapsedMilliseconds = sw.ElapsedMilliseconds;
            AOPLogger.LogInfo(id, type, method, args, returnValue, elapsedMilliseconds);
        }

        public void OnException(AOPArgs arg)
        {
            sw.Stop();
            string id = arg.ExecuteID.ToString();
            string type = arg.CallMethod.DeclaringType.ToString();
            string method = arg.CallMethod.ToString();
            string args = JsonSerializer(arg.Args);
            AOPLogger.LogError(id, type, method, args, arg.Exception);
        }

        private string GetReturnValue(object returnValue)
        {
            return returnValue == null ?
                string.Empty :
                returnValue.GetType() == typeof(void) ? returnValue.ToString() : JsonSerializer(new object[] { returnValue });
        }

        private string JsonSerializer(object[] objArray)
        {
            string returnValue = string.Empty;
            try
            {
                foreach (var obj in objArray)
                {
                    returnValue += "{" + JsonHelper.ToJson(obj) + "}";
                }
            }
            catch { }

            return returnValue;
        }
    }
}
