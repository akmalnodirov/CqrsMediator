using CqrsMediator.Entities.Dtos.Responses;
using MediatR;

namespace CqrsMediator.Api.Queries;

public class GetDriverQuery(Guid driverId) : IRequest<GetDriverResponse>
{
    public Guid DriverId { get; } = driverId;
}
