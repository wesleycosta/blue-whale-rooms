using FluentValidation;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Services;
using Orangotango.Events.Rooms.Category;
using Orangotango.Rooms.Application.Abstractions;
using Orangotango.Rooms.Domain.Categories;
using Orangotango.Rooms.Domain.Categories.Commands;

namespace Orangotango.Rooms.Application.Handlers;

internal sealed class CategoryRemoveCommandHandler(IUnitOfWork unitOfWork,
    IValidator<CategoryRemoveCommand> validator,
    ICategoryMapper mapper,
    ICategoryRepository repository,
    ICategoryPublisher publisher) : CommandHandlerBase<CategoryRemoveCommand>(unitOfWork, validator)
{
    public override async Task<Result> Handle(CategoryRemoveCommand command, CancellationToken cancellationToken)
    {
        if (!await Validate(command))
            return BadResult();

        var category = await repository.GetById(command.Id);
        repository.SoftDelete(category);

        if (await Commit())
        {
            var @event = new CategoryRemovedEvent(category.Id);
            await publisher.PublishEvent(@event);

            return SuccessfulResult(mapper.MapToCategoryResult(category));
        }

        return BadResult();
    }
}
