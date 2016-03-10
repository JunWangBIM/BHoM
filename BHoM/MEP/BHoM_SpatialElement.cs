﻿using BHoM.Global;
using BHoM.MEP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.MEP
{
    public class SpatialElement : Element
    {
        public SpatialElement(string Name, string Number, SpatialShell SpatialShell, Location Location)
            : base(Location, SpatialShell)
        {
            this.Name = Name;
            this.Number = Number;
        }

        public string Name
        {
            get
            {
                return Parameters.LookUp<string>("Name");
            }
            private set
            {
                Parameters.AddItem("Name", value);
            }
        }

        public string Number
        {
            get
            {
                return Parameters.LookUp<string>("Number");
            }
            private set
            {
                Parameters.AddItem("Number", value);
            }
        }
    }
}