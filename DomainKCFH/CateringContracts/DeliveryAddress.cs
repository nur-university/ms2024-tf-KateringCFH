using ServicioCatering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioCatering.Domain.ContractsCatering;

public class DeliveryAddress : Entity
{
    public Guid DeliveryAddressid { get; set; }
    public string Street {  get; set; }
    public string City { get; set; }    
    public bool IsActive { get; set; }
    public DeliveryAddress(Guid deliveryAddressId) : base(deliveryAddressId)
    {
        DeliveryAddressid = deliveryAddressId;
        IsActive = true;
    }

    public DeliveryAddress (Guid deliveryAddressId, string street, string city, bool isActive): this(deliveryAddressId)
    {
        Street = street;
        City = city;
        IsActive = isActive;
    }
    public void UpdateAddress(string street, string city, bool isActive) 
    {
        if (isActive)
        {
            Street = street;
            City = city;
        }
    }
}
