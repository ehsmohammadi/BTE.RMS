using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract.PersonalStrategicManagement.SecondaryObjectives;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalStrategicManagement.SecondaryObjectivesList
{
    public class SecondaryObjectivesServiceWrapper:ISecondaryObjectivesServiceWrapper
    {
        private List<SummerySecondaryObjectives> secondaryObjectiveList = new List<SummerySecondaryObjectives>
        {
            new SummerySecondaryObjectives
            {
                OveralObjective = "قبولی دانشگاه",
                Periority = "A",
                Title = "اهداف درسی"
            }
        }; 
        public void GetAllSecondaryObjectives(Action<List<SummerySecondaryObjectives>, Exception> action)
        {
            action(secondaryObjectiveList, null);
        }
    }
}
