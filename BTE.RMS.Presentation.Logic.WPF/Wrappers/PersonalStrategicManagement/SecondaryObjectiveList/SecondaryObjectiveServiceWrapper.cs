using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeSecondaryObjectiveServiceWrapper:ISecondaryObjectiveServiceWrapper
    {
        private List<SummerySecondaryObjective> secondaryObjectiveList = new List<SummerySecondaryObjective>
        {
            new SummerySecondaryObjective
            {
                Id = 1000,
                Title = "سلامتی خوبه",
                OveralObjective = new SummeryOveralObjective
                {
                    Id = 1004,
                    Title = "عنوان هدف کلی"
                }
            }
        }; 
        public void GetAllSecondaryObjectives(Action<List<SummerySecondaryObjective>, Exception> action)
        {
            action(secondaryObjectiveList, null);
        }

    }
}
