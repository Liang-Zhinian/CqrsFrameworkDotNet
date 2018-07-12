using System;
using CqrsFramework.Commands;

namespace Registration.Contracts.Commands
{
    public class MakeAnAppointmentCommand : BaseCommand, ICommand
    {
        public MakeAnAppointmentCommand()
        {
        }

        public Guid ServiceItemId { get; set; }
        public Guid StaffId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string GenderPreference { get; set; }
        public string Notes { get; set; }
        public bool StaffRequested { get; set; }
        public Guid LocationId { get; set; }
        public Guid SiteId { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
