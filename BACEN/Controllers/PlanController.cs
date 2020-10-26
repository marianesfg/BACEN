using BACENBusiness;
using BACENModel;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.Mvc;

namespace BACEN.Controllers
{
    public class PlanController : Controller
    {    
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Planilha(string arquivo)
        {
            PlanilhaBusiness plan = new PlanilhaBusiness();
            List<Bank> model = new List<Bank>(); 
            model = plan.GetDataFromFile(arquivo); 
           

            return View(model);
        }
    }
}