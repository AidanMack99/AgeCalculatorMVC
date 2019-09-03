using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgeCalculator2.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Age(String Dob)
        {
            String Result;
            string format = "dd/MM/yyyy";
            //DateTime dob = Convert.ToDateTime(Dob);
            DateTime dob;
            var isValidFormat = DateTime.TryParseExact(Dob, format, new CultureInfo("en-US"), DateTimeStyles.None, out dob);
            DateTime today = DateTime.Today;
            if (isValidFormat)
            {
                DateTime current = DateTime.Now;

                int years = current.Year - dob.Year;

                int Months = DateTime.Now.Month - dob.Month;

                if (today.Day < dob.Day)
                {
                    Months--;
                }

                if (Months < 0)
                {
                    years--;
                    Months += 12;
                }

                int Days = (today - dob.AddMonths((years * 12) + Months)).Days;


                int Hours = DateTime.Now.Hour - dob.Hour;

                int Minutes = DateTime.Now.Minute - dob.Minute;

                int Seconds = DateTime.Now.Second - dob.Second;

                Result = years + " Years" + " " + Months + " Months" + " " + Days + " Days" + " " + Hours + " Hours" + " " + Minutes + " Minutes" + " " + Seconds + " Seconds";
                return Content("Result " + Result);
            }
            else
            {
                return Content("Invalid Format");
            }
        }
        
    }
}