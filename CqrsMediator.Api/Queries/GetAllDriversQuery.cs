using CqrsMediator.Entities.Dtos.Responses;
using MediatR;

namespace CqrsMediator.Api.Queries;

public class GetAllDriversQuery : IRequest<IEnumerable<GetDriverResponse>>
{

}
