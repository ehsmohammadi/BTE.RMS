using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalStrategicManagement.SecondaryObjectivesList
{
    public class FakeSecondaryObjectiveServiceWrapper:ISecondaryObjectiveServiceWrapper
    {
        private List<SummerySecondaryObjective> secondaryObjectiveList = new List<SummerySecondaryObjective>
        {
            new SummerySecondaryObjective
            {
                OveralObjective = "قبولی دانشگاه",
                Periority = "A",
                Title = "اهداف درسی"
            }
        }; 
        public void GetAllSecondaryObjectives(Action<List<SummerySecondaryObjective>, Exception> action)
        {
            action(secondaryObjectiveList, null);
        }
    }
}
