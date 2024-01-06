﻿using AutoMapper;
using CqrsMediator.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CqrsMediator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer localizer) : Controller
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IMapper _mapper = mapper;
    protected readonly IStringLocalizer _localizer = localizer;
}
