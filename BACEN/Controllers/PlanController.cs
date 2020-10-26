using BACENBusiness;
using BACENModel;
using System.Collections.Generic;
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
            List<Bank> model; 
            model = plan.GetDataFromFile(arquivo); 
           

            return View(model);
        }
    }
}