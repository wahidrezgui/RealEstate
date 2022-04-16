using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.Notaires.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers;

public class NotaireController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<NotaireDto>>> GetNotaires()
    {
        return await Mediator.Send(new GetNotairesQuery());
    }
}