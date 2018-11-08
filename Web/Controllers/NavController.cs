using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        public PartialViewResult Index()
        {
            return PartialView();
        }
    }
}