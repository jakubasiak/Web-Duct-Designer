using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDuctDesigner.Helpers
{
    public static class Helpers
    {
        public static string SetAlpha(this HtmlHelper helper, double targetValue, double value)
        {
            double delta = value - targetValue;
            float alpha;
            if (delta == 0.0)
                alpha = 1.0f;
            else
                alpha = (float)(1.0 / (Math.Abs(delta) + 1));

            return string.Format("style =background-color:rgba(0,200,0,{0})", alpha.ToString().Replace(',','.'));
        }
    }
}