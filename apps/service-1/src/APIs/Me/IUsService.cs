using Service1.APIs.Common;
using Service1.APIs.Dtos;

namespace Service1.APIs;

public interface IUsService
{
    /// <summary>
    /// Create one us
    /// </summary>
    public Task<MeDto> CreateMe(MeCreateInput meDto);

    /// <summary>
    /// Delete one us
    /// </summary>
    public Task DeleteMe(MeIdDto idDto);

    /// <summary>
    /// Find many us
    /// </summary>
    public Task<List<MeDto>> Us(MeFindMany findManyArgs);

    /// <summary>
    /// Get one us
    /// </summary>
    public Task<MeDto> Me(MeIdDto idDto);

    /// <summary>
    /// Update one us
    /// </summary>
    public Task UpdateMe(MeIdDto idDto, MeUpdateInput updateDto);

    /// <summary>
    /// Meta data about us records
    /// </summary>
    public Task<MetadataDto> UsMeta(MeFindMany findManyArgs);
}
