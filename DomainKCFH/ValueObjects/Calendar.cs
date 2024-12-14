using ServicioCatering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ServicioCatering.Domain.ValueObjects;

public class Calendar
{
    //public IReadOnlyList<DateTime> DeliveryDates { get; private set; }

    private readonly List<DateTime> _deliveryDates = new();


    public IReadOnlyList<DateTime> DeliveryDates => _deliveryDates.AsReadOnly();

    // Agregar fecha al calendario
    public void AddDate(DateTime date)
    {
        if (!_deliveryDates.Contains(date))
            _deliveryDates.Add(date);

        _deliveryDates.Sort();
    }

    // Cancelar un día específico del calendario
    public void RemoveDate(DateTime dateToCancel)
    {
        if (_deliveryDates.Contains(dateToCancel))
            _deliveryDates.Remove(dateToCancel);
    }

    // Reorganizar el calendario después de cancelar fechas
    public void RecalculateOrder()
    {
        _deliveryDates.Sort();
    }
}
    /*
    // Private constructor to ensure immutability
    private Calendar(List<DateTime> deliveryDates)
    {
        DeliveryDates = deliveryDates.OrderBy(d => d).ToList().AsReadOnly();
    }

    // Factory method to create a Calendar instance
    public static Calendar Create(List<DateTime> deliveryDates)
    {
        if (deliveryDates == null || !deliveryDates.Any())
        {
            throw new ArgumentException("Delivery dates cannot be null or empty.");
        }

        return new Calendar(deliveryDates);
    }

    
    public Calendar AddDate(DateTime date)
    {
        if (DeliveryDates.Contains(date))
            throw new InvalidOperationException($"The date {date.ToShortDateString()} already exists in the calendar.");

        var newDates = DeliveryDates.Append(date).ToList();
        return new Calendar(newDates);
    }

    public Calendar RemoveDate(DateTime date)
    {
        if (!DeliveryDates.Contains(date))
            throw new InvalidOperationException($"The date {date.ToShortDateString()} does not exist in the calendar.");

        var newDates = DeliveryDates.Where(d => d != date).ToList();
        return new Calendar(newDates);
    }
    */

