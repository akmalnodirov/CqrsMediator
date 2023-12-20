using MediatR;

namespace CqrsMediator.Api.Commands;

public class DeleteDriverInfoRequest(Guid driverId) : IRequest<bool>
{
    public Guid DriverId { get; } = driverId;
}
