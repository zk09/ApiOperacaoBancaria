using MediatR;
using System;

namespace OperationAccount.Business.SuperDigital.Events
{
    public abstract class Message: INotification,IRequest<bool>
    {
        public string Messagetype { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            Messagetype = GetType().Name;

        }
    }
}
