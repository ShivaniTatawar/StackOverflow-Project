using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOverflowProject.Controllers
{
    public class ExampleController : Controller
    {
        // GET: Example
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Pallindrome(int x)
        {
            if(x < 0)
            {
                return View(false);
            }
            int sum = 0, temp, r;
            temp = x;
            while(temp>0)
            {
                r = temp % 10;
                sum = (sum * 10) + r;
                temp = temp / 10;
            }
            if(x==sum)
            {
                return View(true);
            }
            else
            {
                return View(false);
            }
        }
    }
}