﻿/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Programming
{
    [Description("A syntax node representing a call to a constructor.")]
    public class ConstructorNode : BHoMObject, INode
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ConstructorInfo Constructor { get; set; } = null;

        public string Description { get; set; } = "";

        public List<ReceiverParam> Inputs { get; set; } = new List<ReceiverParam>();

        public List<DataParam> Outputs { get; set; } = new List<DataParam>();

        public bool IsInline { get; set; } = false;

        public bool IsDeclaration { get; set; } = true;

        /***************************************************/
    }
}
