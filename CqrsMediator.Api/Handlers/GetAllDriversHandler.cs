using AutoMapper;
using CqrsMediator.Api.Queries;
using CqrsMediator.DataService.Repositories.Interfaces;
using CqrsMediator.Entities.Dtos.Responses;
using MediatR;

namespace CqrsMediator.Api.Handlers;

public class GetAllDriversHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllDriversQuery, IEnumerable<GetDriverResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<GetDriverResponse>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
    {
        var drivers = await _unitOfWork.DriverRepository.All();
        return _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);
    }
}
