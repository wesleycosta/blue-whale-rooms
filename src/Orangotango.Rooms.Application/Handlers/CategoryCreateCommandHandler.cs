using FluentValidation;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Services;
using Orangotango.Events.Rooms.Category;
using Orangotango.Rooms.Application.Abstractions;
using Orangotango.Rooms.Domain.Categories;
using Orangotango.Rooms.Domain.Categories.Commands;

namespace Orangotango.Rooms.Application.Handlers;

internal sealed class CategoryCreateCommandHandler : CommandHandlerBase<CategoryCreateCommand>
{
    private readonly ICategoryMapper _mapper;
    private readonly ICategoryRepository _repository;
    private readonly ICategoryPublisher _publisher;

    public CategoryCreateCommandHandler(IUnitOfWork unitOfWork,
        IValidator<CategoryCreateCommand> validator,
        ICategoryMapper mapper,
        ICategoryRepository repository,
        ICategoryPublisher publisher) : base(unitOfWork, validator)
    {
        _mapper = mapper;
        _repository = repository;
        _publisher = publisher;
    }

    public override async Task<Result> Handle(CategoryCreateCommand command, CancellationToken cancellationToken)
    {
        if (!await Validate(command))
            return BadResult();

        var category = new Category(command.Name);
        _repository.Add(category);

        if (await Commit())
        {
            var @event = new CategoryCreatedUpdatedEvent(category.Id, category.Name);
            await _publisher.PublishCreatedUpdatedEvent(@event);

            return SuccessfulResult(_mapper.MapToCategoryResult(category));
        }

        return BadResult();
    }
}
