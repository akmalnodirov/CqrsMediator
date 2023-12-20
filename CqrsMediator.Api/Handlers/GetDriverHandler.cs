using AutoMapper;
using CqrsMediator.Api.Queries;
using CqrsMediator.DataService.Repositories.Interfaces;
using CqrsMediator.Entities.Dtos.Responses;
using MediatR;

namespace CqrsMediator.Api.Handlers;

public class GetDriverHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetDriverQuery, GetDriverResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<GetDriverResponse> Handle(GetDriverQuery request, CancellationToken cancellationToken)
    {
        var driver = await _unitOfWork.DriverRepository.GetById(request.DriverId);

        if (driver == null)
            return null;

        return _mapper.Map<GetDriverResponse>(driver);
    }
}
