﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudyProject.Shared.Common
{
    public interface IUpdateStrategy
    {
        bool IsAllowed();
    }
}
