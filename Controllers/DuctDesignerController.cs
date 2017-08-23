using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDuctDesigner.Models;
using HVAC.FluidMechanics;
using HVAC.Elements;
using System.Threading.Tasks;

namespace WebDuctDesigner.Controllers
{
    public class DuctDesignerController : Controller
    {
        // GET: DuctDesigner
        [HttpGet]
        public ActionResult Index()
        {
            DuctDesignViewModel ddvm = new DuctDesignViewModel()
            {
                AirFlow = 100.0,
                ApproximationType = HVAC.FluidMechanics.DarcyFrictionFactorApproximation.GoudarSonnad,
                Temperature = 20.0,
                Pressure = 101325,
                DuctLenght = 1.0,
                RectangularDuctHeight = 200.0,
                RelativeRoughness = 0.01,
                SelectionType = SelectionType.Velocity,
                TargetValue = 3.5

            };
            return View(ddvm);
        }
        [HttpPost]
        public ActionResult Index(DuctDesignViewModel ddvm)
        {
            if (ModelState.IsValid)
            {
                return View(ddvm);
            }
            else
                return View(ddvm);
        }
        public async Task<ActionResult> GetDuctResultList(DuctDesignViewModel ddvm)
        {
            ddvm.RelativeRoughness = ddvm.RelativeRoughness / 1000.0;
            ddvm.Temperature = Calculations.ToKelvin(ddvm.Temperature);
            ddvm.RectangularDuctHeight = ddvm.RectangularDuctHeight / 1000.0;
            DuctDesigner ductDesigner = new DuctDesigner();
            DuctSelectionResultViewModel model = ductDesigner.GetDuctSelectionResultViewModel(ddvm);
            return PartialView("_DructSeletionResultView", model);
        }

    }
}