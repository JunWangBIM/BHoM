﻿using BH.oM.Geometry;
using BH.oM.Base;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BHoM.Architectural.Elements
{
    /// <summary>
    /// Building grids for setting out - curve (list of) based objects with name and text parameters
    /// </summary>
    public class Grid : BHoMObject 
    {
        public Grid()
        {

        }
        /// <summary>
        /// Construct grid by passing list of curves and name
        /// </summary>
        public Grid(BHoM.Geometry.Line line)
        {
            Line = line;
        }
        
        /// <summary>
        /// Grid curves
        /// </summary>
        public ICurve Line
        {
            get;set;
         }
    }
}
