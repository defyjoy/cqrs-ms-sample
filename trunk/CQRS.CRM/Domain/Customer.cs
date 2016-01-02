using CQRS.Base.DDD.Domain;
using CQRS.CRM.Interfaces.Domain;
using CQRS.CRM.Interfaces.Domain.Events;

namespace CQRS.CRM.Domain
{
    public class Customer : AggregateRoot
    {
        private CustomerStatus _status;

        public void ChangeStatus(CustomerStatus status)
        {
            if (status == _status)
                return;

            _status = status;

            //Sample Case: give 10% rebate for all draft orders - communication via events with different Bounded Context to achieve decoupling
            EventPublisher.Publish(new CustomerStatusChangedEvent(Id, status));
        }
    }
}
