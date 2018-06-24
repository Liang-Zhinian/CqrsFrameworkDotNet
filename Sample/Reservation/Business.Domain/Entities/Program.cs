using System;
namespace Business.Domain.Entities
{
    public class Program
    {
        public Program()
        {
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public ScheduleType ScheduleType { get; private set; }

        public int CancelOffset { get; private set; }
    }
}
