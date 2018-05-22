﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environmental.Interface;

namespace BH.oM.Environmental.Elements
{
    public class OpaqueMaterial : BHoMObject, IMaterial
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Description { get; set; } = string.Empty;
        public double Thickness { get; set; } = 0.0;
        public double Conductivity { get; set; } = 0.0;
        public double SpecificHeat { get; set; } = 0.0;
        public double Density { get; set; } = 0.0;
        public double VapourDiffusionFactor { get; set; } = 0.0;
        public double SolarReflectanceExternal { get; set; } = 0.0;
        public double SolarReflectanceInternal { get; set; } = 0.0;
        public double LightReflectanceExternal { get; set; } = 0.0;
        public double LightReflectanceInternal { get; set; } = 0.0;
        public double EmissivityInternal { get; set; } = 0.0;
        public double EmissivityExternal { get; set; } = 0.0;

        /***************************************************/
    }
}
