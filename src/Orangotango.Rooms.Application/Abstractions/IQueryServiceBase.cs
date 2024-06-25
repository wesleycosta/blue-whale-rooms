using Orangotango.Core.Results;
using Orangotango.Core.Services;

namespace Orangotango.Rooms.Application.Abstractions;

public interface IQueryServiceBase<TResult> where TResult : ResultBase
{
    Task<Result> GetById(Guid id);
    Task<IEnumerable<TResult>> Search(string searchValue);
}
