using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Domain.Bus
{
    public interface IInterProcessBus
    {
        void SendMessage(string message);
    }
}
