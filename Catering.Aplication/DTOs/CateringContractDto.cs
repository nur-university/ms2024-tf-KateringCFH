using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioCatering.Aplication.Dtos;

public class CateringContractDto
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid NutritionPlanId { get; set; }
    public string Status { get; set; }
    public DateTime DeliveryDate { get; internal set; }
}
