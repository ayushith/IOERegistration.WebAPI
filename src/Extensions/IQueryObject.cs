﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOERegistration.WebAPI.Extensions
{
    public interface IQueryObject
    {
        string SortBy { get; set; }
        
        bool IsSortAscending { get; set; }

        int Page { get; set; }

        byte PageSize { get; set; }

    }
}
