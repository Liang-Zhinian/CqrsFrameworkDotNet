using System;
using Business.Domain.Entities.Schedules;

namespace Business.Domain.Entities.ServiceCategories
{
    public class Program
    {
        private Program()
        {
            Id = Guid.NewGuid();
        }

        public Program(string name)
        {

        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public ScheduleType ScheduleType { get; private set; }

        public int CancelOffset { get; private set; }
    }
}
