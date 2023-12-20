using AutoMapper;
using CqrsMediator.Api.Commands;
using CqrsMediator.DataService.Repositories.Interfaces;
using MediatR;
using CqrsMediator.Entities.DbSet;

namespace CqrsMediator.Api.Handlers;

public class UpdateDriverInfoHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateDriverInfoRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<bool> Handle(UpdateDriverInfoRequest request, CancellationToken cancellationToken)
    {

        var result = _mapper.Map<Driver>(request.UpdateDriverRequest);
        await _unitOfWork.DriverRepository.Update(result);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}
