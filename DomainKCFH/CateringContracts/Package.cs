using ServicioCatering.Domain.Abstractions;
using ServicioCatering.Domain.NutritionalPlans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioCatering.Domain.ContractsCatering;

internal class Package : Entity
{
    public Guid PackageId { get; set; }
    public List<Recipe> Contents { get; set; } = new();
    public float Weight { get; private set; }

    public Package(Guid packageId) : base(packageId)
    {
        PackageId = packageId;
    }

    public Package(Guid packageId, List<Recipe> contents) : this(packageId) 
    {
        Contents = contents;
        CalculateWeight();
    }

    public void CalculateWeight()
    {
        //Weight = Contents.Sum(r => r.Calories / 100); 
    }
}
