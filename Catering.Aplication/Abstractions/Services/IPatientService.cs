using ServicioCatering.Application.DTOs;
using System;
using System.Threading.Tasks;

namespace ServicioCatering.Application.Abstractions.Services;

public interface IPatientService
{
    Task<PatientDto> GetPatientDetailsAsync(Guid patientId);
    Task UpdatePatientInfoAsync(Guid patientId, string fullName, int age, float weight);
}
