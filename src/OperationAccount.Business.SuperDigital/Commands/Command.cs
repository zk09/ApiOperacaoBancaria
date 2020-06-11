using OperationAccount.Business.SuperDigital.Events;
using System;

namespace OperationAccount.Business.SuperDigital.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
