using MediatR;
using Microsoft.AspNetCore.Mvc;
using Travel.Identity.Helpers;

namespace Travel.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}