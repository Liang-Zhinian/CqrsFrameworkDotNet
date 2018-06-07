using System;
namespace MAR.Domain.Models.Employees
{
    public class SalesSettings
    {
        public bool Rep1 { get; set; }
        public bool CanBeAssignedFollowups { get; set; }
        public bool EarnsTips { get; set; }

        public SalesSettings(bool rep1, bool canBeAssignedFollowups, bool earnsTips)
        {
            Rep1 = rep1;
            CanBeAssignedFollowups = canBeAssignedFollowups;
            EarnsTips = earnsTips;
        }
    }

}
