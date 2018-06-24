using System;
namespace Business.Domain.Entities
{
    public class SessionType
    {
        public SessionType()
        {
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public int DefaultTimeLength { get; private set; }

        public Guid ProgramId { get; private set; }

        public int NumDeducted { get; private set; }

        public ActionCode Action { get; private set; }
    }
}
