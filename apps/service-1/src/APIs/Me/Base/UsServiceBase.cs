using Microsoft.EntityFrameworkCore;
using Service1.APIs;
using Service1.APIs.Common;
using Service1.APIs.Dtos;
using Service1.APIs.Errors;
using Service1.APIs.Extensions;
using Service1.Infrastructure;
using Service1.Infrastructure.Models;

namespace Service1.APIs;

public abstract class UsServiceBase : IUsService
{
    protected readonly Service1DbContext _context;

    public UsServiceBase(Service1DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one us
    /// </summary>
    public async Task<MeDto> CreateMe(MeCreateInput createDto)
    {
        var me = new Me { CreatedAt = createDto.CreatedAt, UpdatedAt = createDto.UpdatedAt };

        if (createDto.Id != null)
        {
            me.Id = createDto.Id;
        }

        _context.Us.Add(me);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Me>(me.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one us
    /// </summary>
    public async Task DeleteMe(MeIdDto idDto)
    {
        var me = await _context.Us.FindAsync(idDto.Id);
        if (me == null)
        {
            throw new NotFoundException();
        }

        _context.Us.Remove(me);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many us
    /// </summary>
    public async Task<List<MeDto>> Us(MeFindMany findManyArgs)
    {
        var us = await _context
            .Us.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return us.ConvertAll(me => me.ToDto());
    }

    /// <summary>
    /// Get one us
    /// </summary>
    public async Task<MeDto> Me(MeIdDto idDto)
    {
        var us = await this.us(new MeFindMany { Where = new MeWhereInput { Id = idDto.Id } });
        var me = us.FirstOrDefault();
        if (me == null)
        {
            throw new NotFoundException();
        }

        return me;
    }

    /// <summary>
    /// Update one us
    /// </summary>
    public async Task UpdateMe(MeIdDto idDto, MeUpdateInput updateDto)
    {
        var me = updateDto.ToModel(idDto);

        _context.Entry(me).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Us.Any(e => e.Id == me.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Meta data about us records
    /// </summary>
    public async Task<MetadataDto> UsMeta(MeFindMany findManyArgs)
    {
        var count = await _context.Us.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }
}
