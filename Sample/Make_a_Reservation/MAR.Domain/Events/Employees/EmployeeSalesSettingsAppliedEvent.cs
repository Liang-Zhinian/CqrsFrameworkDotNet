using System;
namespace MAR.Domain.Events.Employees
{
    public class EmployeeSalesSettingsAppliedEvent : BaseEvent
    {
        public bool Rep1 { get; set; }
        public bool CanBeAssignedFollowups { get; set; }
        public bool EarnsTips { get; set; }

        public EmployeeSalesSettingsAppliedEvent(Guid id, bool rep1, bool canBeAssignedFollowups, bool earnsTips)
        {
            Id = id;
            Rep1 = rep1;
            CanBeAssignedFollowups = canBeAssignedFollowups;
            EarnsTips = earnsTips;
        }
    }
}
