using Orangotango.Rooms.Application.Results;
using Orangotango.Core.Services;

namespace Orangotango.Rooms.Application.Abstractions;

public interface ICategoryService
{
    Task<Result> GetById(Guid id);
    Task<IEnumerable<CategoryResult>> Search(string searchValue);
}
