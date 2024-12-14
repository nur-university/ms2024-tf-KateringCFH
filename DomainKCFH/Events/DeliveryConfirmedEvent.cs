using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioCatering.Domain.Events;

public class DeliveryConfirmedEvent
{
    public Guid DeliveryId { get; }
    public Guid ContractId { get; }
    public DateTime ConfirmedAt { get; }

    public DeliveryConfirmedEvent(Guid contractId, Guid deliveryId)
    {
        ContractId = contractId;
        DeliveryId = deliveryId;
        ConfirmedAt = DateTime.UtcNow;
    }
}
