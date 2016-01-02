using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRS.Base.DDD.Infrastructure.Events;
using CQRS.Base.Infrastructure.NHibernate;
using CQRS.Sales.Interfaces.Application.Events;
using CQRS.Sales.Presentation.Model;

namespace CQRS.Sales.Presentation.Listeners
{
    [EventListeners]
    public class ProductEventsListener : IEventListener<ProductAddedToOrderEvent>
    {
        public IEntityManager EntityManager { get; set; }

        [EventListener(IsAsync = true)]
        public void Handle(ProductAddedToOrderEvent eventData)
        {
            EntityManager.CurrentSession.Persist(
                new OrderedProductProjection(eventData.Productid, eventData.ClientId,
                                   eventData.Quantity, DateTime.Now));
        }
    }
}
