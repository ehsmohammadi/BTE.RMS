﻿using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class CrudFinancialCommitments : SummeryFinancialCommitments
    {
        private string description;

        public string Description
        {
            get { return description; }
            set { this.SetField(p => p.Description, ref description, value); }
        }
    }
}