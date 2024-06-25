using Orangotango.Core.Results;
using Orangotango.Core.Services;
using Orangotango.Rooms.Application.Results;

namespace Orangotango.Rooms.Application.Abstractions;

public interface IQueryServiceBase<TResult> where TResult : ResultBase
{
    Task<Result> GetById(Guid id);
    Task<IEnumerable<TResult>> GetAll();
    Task<IEnumerable<TResult>> Search(string searchValue);
}
