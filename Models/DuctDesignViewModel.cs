using HVAC.Elements;
using HVAC.FluidMechanics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDuctDesigner.Models
{
    public class DuctDesignViewModel
    {
        [Required(ErrorMessage = "Airflow is required")]
        [Range(0.001, double.PositiveInfinity,ErrorMessage = "Value must be greater than zero")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F0}")]
        public double AirFlow { get; set; }
        [Required(ErrorMessage = "Temperature is required")]
        [Range(-273.15, double.PositiveInfinity, ErrorMessage = "Value must be greater than -273.15 C")]
        public double Temperature { get; set; }
        [Required(ErrorMessage = "Pressure is required")]
        [Range(0.0, double.PositiveInfinity, ErrorMessage = "Value must be greater than zero")]
        public double Pressure { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N4}")]
        //public double Density { get; set; }
        [Required(ErrorMessage = "Target value is required")]
        [Range(0.0, double.PositiveInfinity, ErrorMessage = "Value must be greater than zero")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public double TargetValue { get; set; }
        public SelectionType SelectionType { get; set; }
        public DarcyFrictionFactorApproximation ApproximationType { get; set; }
        [Required(ErrorMessage = "Rectangular duct heigt value is required")]
        [Range(0.0, double.PositiveInfinity, ErrorMessage = "Value must be greater than zero")]
        public double RectangularDuctHeight { get; set; }
        [Required(ErrorMessage = "Relative roughness value is required")]
        [Range(0.0, double.PositiveInfinity, ErrorMessage = "Value must be greater than zero")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N3}")]
        public double RelativeRoughness { get; set; }
        [Required(ErrorMessage = "Duct lenght value is required")]
        [Range(0.0, double.PositiveInfinity, ErrorMessage = "Value must be greater than zero")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public double DuctLenght { get; set; }
        //public IEnumerable<LocalLoss> LocalLosses { get; set; }
    }
    public enum SelectionType
    {
        Velocity,
        Pressure
    }
}