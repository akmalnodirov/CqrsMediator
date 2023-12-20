

using AutoMapper;
using CqrsMediator.Api.Commands;
using CqrsMediator.Api.Queries;
using CqrsMediator.DataService.Repositories.Interfaces;
using CqrsMediator.Entities.Dtos.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediator.Api.Controllers;

public class DriversController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : BaseController(unitOfWork, mapper)
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [Route("{driverId:Guid}")]
    public async Task<IActionResult> GetDriver(Guid driverId)
    {
        /*        var driver = await _unitOfWork.DriverRepository.GetById(driverId);

                if (driver == null)
                    return NotFound();

                var result = _mapper.Map<GetDriverResponse>(driver);*/

        var query = new GetDriverQuery(driverId);
        var result = await _mediator.Send(query);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDrivers()
    {
        /*        var drivers = await _unitOfWork.DriverRepository.All();
                var result = _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);*/

        var query = new GetAllDriversQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest request)
    {
        /*  if (!ModelState.IsValid)
              return BadRequest(ModelState);

          var result = _mapper.Map<Driver>(request);

          await _unitOfWork.DriverRepository.Add(result);
          await _unitOfWork.CompleteAsync();
          return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id }, result);*/

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = new CreateDriverInfoRequest(request);
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetDriver), new { driverId = result.DriverId }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        /*   var result = _mapper.Map<Driver>(request);

           await _unitOfWork.DriverRepository.Update(result);
           await _unitOfWork.CompleteAsync();
           return NoContent();*/

        var command = new UpdateDriverInfoRequest(request);
        var result = await _mediator.Send(command);
        return result ? NoContent() : BadRequest();

    }

    [HttpDelete]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var command = new DeleteDriverInfoRequest(driverId);
        var result = await _mediator.Send(command);

        return result ? NoContent() : BadRequest();
    }

}
