using Orangotango.Rooms.Application.Results;

namespace Orangotango.Rooms.Application.Abstractions;

public interface ICategoryQueryService : IQueryServiceBase<CategoryResult>
{
    Task<IEnumerable<CategoryResult>> Search(string searchValue);
}
