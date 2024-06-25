using FluentValidation;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Services;
using Orangotango.Rooms.Application.Abstractions;
using Orangotango.Rooms.Domain.Categories;
using Orangotango.Rooms.Domain.Categories.Commands;

namespace Orangotango.Rooms.Application.Handlers;

internal sealed class CategoryUpdateCommandHandler(IUnitOfWork unitOfWork,
    IValidator<CategoryUpdateCommand> validator,
    ICategoryMapper _mapper,
    ICategoryRepository _repository,
    ICategoryPublisher _publisher) : CommandHandlerBase<CategoryUpdateCommand>(unitOfWork, validator)
{
    public override async Task<Result> Handle(CategoryUpdateCommand command, CancellationToken cancellationToken)
    {
        if (!await Validate(command))
            return BadResult();

        var category = await _repository.GetById(command.Id);
        category.SetName(command.Name);
        _repository.Update(category);

        if (await Commit())
        {
            await _publisher.Publish(category.GenerateUpsertedEvent());
            return SuccessfulResult(_mapper.MapToCategoryResult(category));
        }

        return BadResult();
    }
}
