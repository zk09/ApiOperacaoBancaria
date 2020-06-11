using System;

namespace OperationAccount.Business.SuperDigital.Events
{
    public abstract class Event : Message
    {
        public DateTime Timestamp { get; set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
