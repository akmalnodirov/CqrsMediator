

using AutoMapper;
using CqrsMediator.DataService.Repositories.Interfaces;
using CqrsMediator.Entities.DbSet;
using CqrsMediator.Entities.Dtos.Requests;
using CqrsMediator.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediator.Api.Controllers;

public class DriversController(IUnitOfWork unitOfWork, IMapper mapper) : BaseController(unitOfWork, mapper)
{
    [HttpGet]
    [Route("{driverId:Guid}")]
    public async Task<IActionResult> GetDriver(Guid driverId)
    {
        var driver = await _unitOfWork.DriverRepository.GetById(driverId);

        if (driver == null)
            return NotFound();

        var result = _mapper.Map<GetDriverResponse>(driver);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = _mapper.Map<Driver>(request);

        await _unitOfWork.DriverRepository.Add(result);
        await _unitOfWork.CompleteAsync();
        return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = _mapper.Map<Driver>(request);

        await _unitOfWork.DriverRepository.Update(result);
        await _unitOfWork.CompleteAsync();
        return NoContent();

    }

    [HttpGet]
    public async Task<IActionResult> GetAllDrivers()
    {
        var drivers = await _unitOfWork.DriverRepository.All();

        var result = _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);

        return Ok(result);
    }

    [HttpDelete]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var driver = await _unitOfWork.DriverRepository.GetById(driverId);

        if(driver == null)
            return NotFound();

        await _unitOfWork.DriverRepository.Delete(driverId);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

}
