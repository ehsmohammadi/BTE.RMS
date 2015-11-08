﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.Presentation.UI.WPF
{
    public interface IWindowView
    {
        string Title { get; set; }
        Object WindowContent { get; set; }
    }
}
