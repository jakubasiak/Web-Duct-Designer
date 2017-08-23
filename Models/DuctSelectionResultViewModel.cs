using HVAC.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDuctDesigner.Models
{
    public class DuctSelectionResultViewModel
    {
        public IEnumerable<RoundDuct> RoundDucts { get; set; }
        public IEnumerable<RectangularDuct> RectangularDucts { get; set; }
        public double TargetValue { get; set; }
        public SelectionType SelectionType { get; set; }
    }
}