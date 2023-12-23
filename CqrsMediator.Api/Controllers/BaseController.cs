using AutoMapper;
using CqrsMediator.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController(IUnitOfWork unitOfWork, IMapper mapper) : Controller
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IMapper _mapper = mapper;
}
