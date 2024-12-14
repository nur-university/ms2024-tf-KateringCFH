using ServicioCatering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioCatering.Domain.ContractsCatering;

public class Delivery : Entity
{
    public Guid DeliveryId { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string Status { get; set; } = "Pending";
    public Guid PackageId { get; set; }
    public Guid DeliveryAddressId { get; set; }
    public Delivery(Guid deliveryId) : base(deliveryId)
    {
        DeliveryId = deliveryId;
        Status = "Pending";
    }
    public Delivery(Guid deliveryId, DateTime deliveryDate, Guid packageId, Guid deliveryAddressId) : this(deliveryId)
    {
        DeliveryDate = deliveryDate;
        PackageId = packageId;
        DeliveryAddressId = deliveryAddressId;
    }

    public void ConfirmDelivery() => Status = "Delivered";

    public void ReassignDeliveryAddress(Guid newAddressId) => DeliveryAddressId = newAddressId;
}