using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers {
    public class CalcController : Controller {

        [HttpGet]
        public ActionResult CompareSquare() {
            return View();
        }

        [HttpPost]
        public ActionResult CompareSquare(string firstname, string secondname) {
            int firstNum;
            int secondNum;
            bool isNumericFirst;
            bool isNumericSecond;

            isNumericFirst = int.TryParse(firstname, out firstNum);
            isNumericSecond = int.TryParse(secondname, out secondNum);

            if(firstNum > 1 || secondNum > 1) {
                double firstNumRoot = Math.Sqrt(firstNum);
                double secondNumRoot = Math.Sqrt(secondNum);

                int highNum;
                double highRoot;
                int lowNum;
                double lowRoot;

                if(firstNumRoot > secondNumRoot) {
                    highNum = firstNum;
                    highRoot = firstNumRoot;
                    lowNum = secondNum;
                    lowRoot = secondNumRoot;

                } else if (firstNumRoot < secondNumRoot) {
                    highNum = secondNum;
                    highRoot = secondNumRoot;
                    lowNum = firstNum;
                    lowRoot = firstNumRoot;
                } else {
                    highNum = 0;
                    highRoot = 0;
                    lowRoot = 0;
                    lowNum = 0;
                }

                ViewBag.HighNum = highNum;
                ViewBag.HighRoot = highRoot;
                ViewBag.LowNum = lowNum;
                ViewBag.LowRoot = lowRoot;
            } else {
                ViewBag.HighNum = "negative";
            }

            return View();
        }
    }
}