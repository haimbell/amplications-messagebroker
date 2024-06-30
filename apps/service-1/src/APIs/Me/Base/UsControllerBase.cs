using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service1.APIs;
using Service1.APIs.Common;
using Service1.APIs.Dtos;
using Service1.APIs.Errors;

namespace Service1.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class UsControllerBase : ControllerBase
{
    protected readonly IUsService _service;

    public UsControllerBase(IUsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one us
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<MeDto>> CreateMe(MeCreateInput input)
    {
        var me = await _service.CreateMe(input);

        return CreatedAtAction(nameof(Me), new { id = me.Id }, me);
    }

    /// <summary>
    /// Delete one us
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteMe([FromRoute()] MeIdDto idDto)
    {
        try
        {
            await _service.DeleteMe(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many us
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<MeDto>>> Us([FromQuery()] MeFindMany filter)
    {
        return Ok(await _service.Us(filter));
    }

    /// <summary>
    /// Get one us
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<MeDto>> Me([FromRoute()] MeIdDto idDto)
    {
        try
        {
            return await _service.Me(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one us
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateMe(
        [FromRoute()] MeIdDto idDto,
        [FromQuery()] MeUpdateInput meUpdateDto
    )
    {
        try
        {
            await _service.UpdateMe(idDto, meUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Meta data about us records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> UsMeta([FromQuery()] MeFindMany filter)
    {
        return Ok(await _service.UsMeta(filter));
    }
}
