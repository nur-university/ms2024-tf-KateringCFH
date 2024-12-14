using System;

namespace ServicioCatering.Application.DTOs;

public class PatientDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public float Weight { get; set; }
}
