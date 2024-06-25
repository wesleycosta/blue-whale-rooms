using FluentValidation;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Services;
using Orangotango.Rooms.Application.Abstractions;
using Orangotango.Rooms.Domain.Categories;
using Orangotango.Rooms.Domain.Categories.Commands;

namespace Orangotango.Rooms.Application.Handlers;

internal sealed class CategoryRemoveCommandHandler(IUnitOfWork unitOfWork,
    IValidator<CategoryRemoveCommand> validator,
    ICategoryMapper _mapper,
    ICategoryRepository _repository,
    ICategoryPublisher _publisher) : CommandHandlerBase<CategoryRemoveCommand>(unitOfWork, validator)
{
    public override async Task<Result> Handle(CategoryRemoveCommand command, CancellationToken cancellationToken)
    {
        if (!await Validate(command))
            return BadResult();

        var category = await _repository.GetById(command.Id);
        _repository.SoftDelete(category);

        if (await Commit())
        {
            await _publisher.Publish(category.GenerateRemovedEvent());
            return SuccessfulResult(_mapper.MapToCategoryResult(category));
        }

        return BadResult();
    }
}
