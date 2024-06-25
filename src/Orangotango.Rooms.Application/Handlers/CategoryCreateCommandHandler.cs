using FluentValidation;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Services;
using Orangotango.Rooms.Application.Abstractions;
using Orangotango.Rooms.Domain.Categories;
using Orangotango.Rooms.Domain.Categories.Commands;

namespace Orangotango.Rooms.Application.Handlers;

internal sealed class CategoryCreateCommandHandler(IUnitOfWork _unitOfWork,
    IValidator<CategoryCreateCommand> _validator,
    ICategoryMapper _mapper,
    ICategoryRepository _repository,
    ICategoryPublisher _publisher) : CommandHandlerBase<CategoryCreateCommand>(_unitOfWork, _validator)
{
    public override async Task<Result> Handle(CategoryCreateCommand command, CancellationToken cancellationToken)
    {
        if (!await Validate(command))
            return BadResult();

        var category = new Category(command.Name);
        _repository.Add(category);

        if (await Commit())
        {
            await _publisher.Publish(category.GenerateUpsertedEvent());
            return SuccessfulResult(_mapper.MapToCategoryResult(category));
        }

        return BadResult();
    }
}
