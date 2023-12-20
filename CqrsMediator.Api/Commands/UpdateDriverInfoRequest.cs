using CqrsMediator.Entities.Dtos.Requests;
using MediatR;

namespace CqrsMediator.Api.Commands;

public class UpdateDriverInfoRequest(UpdateDriverRequest request) : IRequest<bool>
{
    public UpdateDriverRequest UpdateDriverRequest { get; } = request;
}
