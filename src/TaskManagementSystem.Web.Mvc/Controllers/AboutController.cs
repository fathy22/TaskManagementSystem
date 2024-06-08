using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using TaskManagementSystem.Controllers;

namespace TaskManagementSystem.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : TaskManagementSystemControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
