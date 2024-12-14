using ServicioCatering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioCatering.Domain.Patient;

public class Patient : Entity
{
    public string FullName { get; private set; }
    public int Age { get; private set; }
    public float Weight { get; private set; }

    public Patient(Guid id, string fullName, int age, float weight)
        : base(id)
    {
        FullName = fullName;
        Age = age;
        Weight = weight;
    }

    public void UpdateData(string fullName, int age, float weight)
    {
        FullName = fullName;
        Age = age;
        Weight = weight;
    }
}

