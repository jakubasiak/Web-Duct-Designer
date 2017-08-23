using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebDuctDesigner
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ModelBinders.Binders[typeof(float)] = new SingleModelBinder();
            ModelBinders.Binders[typeof(double)] = new DoubleModelBinder();
            ModelBinders.Binders[typeof(decimal)] = new DecimalModelBinder();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        public abstract class FloatingPointModelBinderBase<T> : DefaultModelBinder
        {
            protected abstract Func<string, IFormatProvider, T> ConvertFunc { get; }

            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                if (valueProviderResult == null) return base.BindModel(controllerContext, bindingContext);
                try
                {
                    return ConvertFunc.Invoke(valueProviderResult.AttemptedValue, CultureInfo.CurrentUICulture);
                }
                catch (FormatException)
                {
                    // If format error then fallback to InvariantCulture instead of current UI culture
                    return ConvertFunc.Invoke(valueProviderResult.AttemptedValue, CultureInfo.InvariantCulture);
                }
            }
        }

        public class DecimalModelBinder : FloatingPointModelBinderBase<decimal>
        {
            protected override Func<string, IFormatProvider, decimal> ConvertFunc => Convert.ToDecimal;
        }

        public class DoubleModelBinder : FloatingPointModelBinderBase<double>
        {
            protected override Func<string, IFormatProvider, double> ConvertFunc => Convert.ToDouble;
        }

        public class SingleModelBinder : FloatingPointModelBinderBase<float>
        {
            protected override Func<string, IFormatProvider, float> ConvertFunc => Convert.ToSingle;
        }
    }
}
