﻿using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface ISecondaryObjectiveServiceWrapper:IServiceWrapper
    {
        void GetAllSecondaryObjectives(Action<List<SummerySecondaryObjective>, Exception> action);
        void CreateSecondaryObjectives(Action<List<SummerySecondaryObjective>, Exception> action);
    }
}
