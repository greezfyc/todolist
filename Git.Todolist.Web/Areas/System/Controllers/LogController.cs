using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Git.Todolist.Application;
using Git.Todolist.Core;
using Git.Todolist.Core.Aop;

namespace Git.Todolist.Web.Areas.System.Controllers
{
    [AOPAttribute]
    public class LogController : ControllerBase
    {
        private LogApp logApp = new LogApp();

        [HttpGet]
        public ActionResult RemoveLog()
        {
            return View();
        }
        [HttpGet]
        [HandlerAjaxOnly]
        [AOPMethodAttribute(typeof(LogController))]
        public ActionResult GetGridJson(Pagination pagination, string queryJson)
        {
            FileLog.Debug("sdfss");
            try
            {
                var data = new
                {
                    rows = logApp.GetList(pagination, queryJson),
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records
                };
                return Content(data.ToJson());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRemoveLog(string keepTime)
        {
            logApp.RemoveLog(keepTime);
            return Success("清空成功。");
        }
    }
}