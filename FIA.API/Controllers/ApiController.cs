using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace FIA.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ApiController : ControllerBase
    {
        private IMediator mediator;
        private IFIADbContext context;

        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected IFIADbContext DbContext => context ??= HttpContext.RequestServices.GetService<IFIADbContext>();
    }
}
