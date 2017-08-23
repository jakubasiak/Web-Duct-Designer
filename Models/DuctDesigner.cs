using HVAC.Elements;
using System.Linq;
using WebDuctDesigner.Models;
using System.Collections.Generic;
using HVAC.FluidMechanics;
using System;

namespace WebDuctDesigner.Controllers
{
    internal class DuctDesigner
    {
        private List<RoundDuct> roundDuctList;
        private List<RectangularDuct> rectangularDuctList;

        public DuctSelectionResultViewModel GetDuctSelectionResultViewModel(DuctDesignViewModel ddvm)
        {
            DuctSelectionResultViewModel model = new DuctSelectionResultViewModel();
            model.SelectionType = ddvm.SelectionType;
            model.TargetValue = ddvm.TargetValue;
            model.RoundDucts = (new RoundDuctDesigner()).GetRoundDuctList(ddvm);
            model.RectangularDucts = (new RectangularDuctDesigner()).GetRoundDuctList(ddvm);

            return model;
        }

    }

    internal class RoundDuctDesigner
    {
        private static double[] roundDuctSizes = { 0.08, 0.1, 0.125, 0.16, 0.2, 0.25,
                                                    0.3, 0.315, 0.350, 0.400, 0.450,
                                                    0.500, 0.550, 0.600, 0.650, 0.700,
                                                    0.750, 0.800, 0.850, 0.900, 0.950, 1.0,
                                                    1.05,1.1,1.15,1.2,1.25,1.3,1.35,1.4,
                                                    1.45,1.5,1.55,1.6,1.65,1.7,1.75,1.8,
                                                    1.85,1.9,1.95,2.0,2.05,2.1,2.15,2.2};
        public List<RoundDuct> GetRoundDuctList(DuctDesignViewModel ddvm)
        {
            AirFlow airFlow = new AirFlow(ddvm.Temperature, ddvm.Pressure, ddvm.AirFlow);
            List<RoundDuct> ductList = new List<RoundDuct>();
            foreach (var ductSize in roundDuctSizes)
            {
                ductList.Add(new RoundDuct(ddvm.ApproximationType, ddvm.RelativeRoughness, ductSize, ddvm.DuctLenght, airFlow));
            }
            if(ddvm.SelectionType == SelectionType.Velocity)
            {
                return ductList.OrderBy(x => Math.Abs(x.Velocity - ddvm.TargetValue)).Take(10).OrderByDescending(x=>x.Velocity).ToList();
            }
            else
            {
                return ductList.OrderBy(x => Math.Abs(x.FrictionLoss - ddvm.TargetValue)).Take(10).OrderByDescending(x => x.FrictionLoss).ToList();
            }
        }
    }

    internal class RectangularDuctDesigner
    {
        private static double[] rectangularDuctSizes = { 0.05, 0.1, 0.15, 0.2, 0.25,
                                                        0.3, 0.35, 0.4, 0.45, 0.5,
                                                        0.55, 0.6, 0.65, 0.7, 0.8,
                                                        0.85, 0.9, 0.95, 1.0, 1.05,
                                                        1.1, 1.15, 1.2, 1.25, 1.3,
                                                        1.35, 1.4, 1.45, 1.5,1.55,
                                                        1.6,1.65,1.7,1.75,1.8,1.85,
                                                        1.9,1.95,2.0,2.05,2.1,2.15,2.2};
        public List<RectangularDuct> GetRoundDuctList(DuctDesignViewModel ddvm)
        {
            AirFlow airFlow = new AirFlow(ddvm.Temperature, ddvm.Pressure, ddvm.AirFlow);
            List<RectangularDuct> ductList = new List<RectangularDuct>();
            foreach (var ductSize in rectangularDuctSizes)
            {
                ductList.Add(new RectangularDuct(ddvm.ApproximationType, ddvm.RelativeRoughness, ductSize, ddvm.RectangularDuctHeight, ddvm.DuctLenght, airFlow));
            }
                        if(ddvm.SelectionType == SelectionType.Velocity)
            {
                return ductList.OrderBy(x => Math.Abs(x.Velocity - ddvm.TargetValue)).Take(10).OrderByDescending(x=>x.Velocity).ToList();
            }
            else
            {
                return ductList.OrderBy(x => Math.Abs(x.FrictionLoss - ddvm.TargetValue)).Take(10).OrderByDescending(x => x.FrictionLoss).ToList();
            }
        }

    }
}