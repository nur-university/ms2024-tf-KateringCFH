using MediatR;

namespace ServicioCatering.Application.Abstractions.Commands;

public interface ICommand<out TResult> : IRequest<TResult> { }
