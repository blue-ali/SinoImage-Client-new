﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocScanner.Common
{
    public class PathTypeAttribute : Attribute
    {
        public string RootPath
        {
            get;
            set;
        }
    }

}
