﻿using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class CrudIncome:SummeryIncome
    {
        private string description;

        public string Description
        {
            get { return description; }
            set {this.SetField(p=>p.Description,ref description,value);}
        }
    }
}