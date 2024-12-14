using MediatR;

namespace ServicioCatering.Application.Abstractions.Queries;

public interface IQuery<out TResult> : IRequest<TResult> { }
