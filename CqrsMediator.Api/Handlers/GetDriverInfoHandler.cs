using AutoMapper;
using CqrsMediator.Api.Commands;
using CqrsMediator.DataService.Repositories.Interfaces;
using CqrsMediator.DataService.Repositories;
using CqrsMediator.Entities.Dtos.Responses;
using MediatR;
using CqrsMediator.Entities.DbSet;

namespace CqrsMediator.Api.Handlers;

public class GetDriverInfoHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateDriverInfoRequest, GetDriverResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<GetDriverResponse> Handle(CreateDriverInfoRequest request, CancellationToken cancellationToken)
    {
        var driver = _mapper.Map<Driver>(request.DriverRequest);

        await _unitOfWork.DriverRepository.Add(driver);
        await _unitOfWork.CompleteAsync();

        return _mapper.Map<GetDriverResponse>(driver);
    }
}
