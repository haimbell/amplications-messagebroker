using Service1.APIs.Dtos;
using Service1.Infrastructure.Models;

namespace Service1.APIs.Extensions;

public static class UsExtensions
{
    public static MeDto ToDto(this Me model)
    {
        return new MeDto
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static Me ToModel(this MeUpdateInput updateDto, MeIdDto idDto)
    {
        var me = new Me { Id = idDto.Id };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            me.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            me.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return me;
    }
}
