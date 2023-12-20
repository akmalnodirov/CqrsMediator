using AutoMapper;
using CqrsMediator.Api.Commands;
using CqrsMediator.DataService.Repositories.Interfaces;
using CqrsMediator.Entities.DbSet;
using MediatR;

namespace CqrsMediator.Api.Handlers;

public class DeleteDriverHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteDriverInfoRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<bool> Handle(DeleteDriverInfoRequest request, CancellationToken cancellationToken)
    {
        var driver = await _unitOfWork.DriverRepository.GetById(request.DriverId);

        if (driver == null)
            return false;

        await _unitOfWork.DriverRepository.Delete(request.DriverId);
        await _unitOfWork.CompleteAsync();

        return true;
    }
}
