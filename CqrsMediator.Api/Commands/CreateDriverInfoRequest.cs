using CqrsMediator.Entities.Dtos.Requests;
using CqrsMediator.Entities.Dtos.Responses;
using MediatR;

namespace CqrsMediator.Api.Commands;

public class CreateDriverInfoRequest(CreateDriverRequest request) : IRequest<GetDriverResponse>
{
    public CreateDriverRequest DriverRequest { get; } = request;
}
