using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Proprietes.Commands.Create;
using CleanArchitecture.Application.Proprietes.Commands.Delete;
using CleanArchitecture.Application.Proprietes.Commands.Update;
using CleanArchitecture.Application.Proprietes.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

public class ProprietesController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<ProprieteBriefDto>>> GetProprietesWithPagination([FromQuery] GetProprietesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateProprieteCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPatch("[action]")]
    public async Task<ActionResult> UpdateProprieteDetails(int id, UpdateProprieteDetailCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteProprieteCommand { Id = id });

        return NoContent();
    }
}