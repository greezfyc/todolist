using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Git.Todolist.Application;
using Git.Todolist.Core;

namespace Git.Todolist.Web.Areas.System.Controllers
{
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
        public ActionResult GetGridJson(Pagination pagination, string queryJson)
        {
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
            catch(Exception ex)
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