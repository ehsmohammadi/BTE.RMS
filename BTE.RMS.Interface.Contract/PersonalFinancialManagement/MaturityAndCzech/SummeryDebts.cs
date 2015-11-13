﻿using System;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract.PersonalFinancialManagement.MaturityAndCzech
{
    public class SummeryDebts:ViewModelBase
    {
        private DateTime maturityDate;

        public DateTime MaturityDate
        {
            get { return maturityDate; }
            set { this.SetField(p => p.MaturityDate, ref maturityDate, value); }
        }

        private string opponent;

        public string Opponent
        {
            get { return opponent; }
            set { this.SetField(p => p.Opponent, ref opponent, value); }
        }

        private long amount;

        public long Amount
        {
            get { return amount; }
            set { this.SetField(p => p.Amount, ref amount, value); }
        }

        private string purpose;

        public string Purpose
        {
            get { return purpose; }
            set { this.SetField(p => p.Purpose, ref purpose, value); }
        }

        private Boolean state;

        public Boolean State
        {
            get { return state; }
            set { this.SetField(p => p.State, ref state, value); }
        }
    }
}
