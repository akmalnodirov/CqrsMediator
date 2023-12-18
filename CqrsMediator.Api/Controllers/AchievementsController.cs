using AutoMapper;
using CqrsMediator.DataService.Repositories.Interfaces;
using CqrsMediator.Entities.DbSet;
using CqrsMediator.Entities.Dtos.Requests;
using CqrsMediator.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediator.Api.Controllers;

public class AchievementsController(IUnitOfWork unitOfWork, IMapper mapper) : BaseController(unitOfWork, mapper)
{
    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriverAchievements(Guid driverId)
    {
        var driverAchievements = await _unitOfWork.AchievementsRepository.GetDriverAchievementsAsync(driverId);

        if (driverAchievements == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<DriverAchievementResponse>(driverAchievements));
    }

    [HttpPost]
    public async Task<IActionResult> AddAChievement([FromBody] CreateDriverAchievementRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var result = _mapper.Map<Achievements>(request);
        await _unitOfWork.AchievementsRepository.Add(_mapper.Map<Achievements>(request));
        await _unitOfWork.CompleteAsync();
        return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAchievements([FromBody] UpdateDriverAchievementRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var result = _mapper.Map<Achievements>(request);
        await _unitOfWork.AchievementsRepository.Update(result);
        return NoContent();

    }
}
