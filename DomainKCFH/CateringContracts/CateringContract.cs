using ServicioCatering.Domain.Abstractions;
using ServicioCatering.Domain.ContractsCatering;
using ServicioCatering.Domain.Events;
using ServicioCatering.Domain.ValueObjects;
namespace ServicioCatering.Domain.CateringContracts;

public class CateringContract : AggregateRoot
{
    private DateTime deliveryDate;

    public Guid PatientId { get; private set; }
    public Guid NutritionPlanId { get; private set; }
    public string Status { get; private set; } = "Active";
    public Calendar DeliveryCalendar { get; private set; }
    public List<Delivery> Deliveries { get; private set; } = new();

    public CateringContract(Guid id, Guid patientId, Guid nutritionPlanId, Calendar deliveryCalendar)
        : base(id)
    {
        PatientId = patientId;
        NutritionPlanId = nutritionPlanId;
        DeliveryCalendar = deliveryCalendar;
    }

    public CateringContract(Guid id, Guid patientId, Guid nutritionPlanId, DateTime deliveryDate) : base(id)
    {
        PatientId = patientId;
        NutritionPlanId = nutritionPlanId;
        this.deliveryDate = deliveryDate;
    }

    public void AddDelivery(Delivery delivery)
    {
        Deliveries.Add(delivery);
        AddDomainEvent(new DeliveryConfirmedEvent(Id, delivery.Id));
    }

    public void UpdateCalendar(Calendar newCalendar)
    {
        DeliveryCalendar = newCalendar;
    }

    public void CancelDate(DateTime dateToCancel)
    {
        DeliveryCalendar.RemoveDate(dateToCancel);
        ReorganizeDeliveries();
    }

    private void ReorganizeDeliveries() => DeliveryCalendar.RecalculateOrder();

    private void AddDomainEvent(object domainEvent)
    {
        // Lógica para agregar y manejar eventos de dominio
        Console.WriteLine($"Domain Event Added: {domainEvent}");
    }

    public void Cancel(DateTime cancellationDate)
    {
        throw new NotImplementedException();
    }
}