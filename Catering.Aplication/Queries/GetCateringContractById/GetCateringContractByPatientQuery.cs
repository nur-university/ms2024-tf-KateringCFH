using ServicioCatering.Aplication.Dtos;
using ServicioCatering.Application.Abstractions.Queries;
using System;
using System.Collections.Generic;

namespace ServicioCatering.Application.Queries.GetCateringContractsByPatient;

public record GetCateringContractsByPatientQuery(Guid PatientId) : IQuery<IEnumerable<CateringContractDto>>;
