using FluentValidation;
using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Services;
using PixelHotelRooms.Application.Abstractions;
using PixelHotelRooms.Domain.CategoryAggregate;
using PixelHotelRooms.Domain.CategoryAggregate.Commands;

namespace PixelHotelRooms.Application.Handlers;

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
        {
            return BadResult();
        }

        var category = new Category();
        var events = category.UpdateFrom(command);
        _repository.Add(category);

        if (await Commit())
        {
            await _publisher.PublishCreatedUpdatedEvent(events);
            return SuccessfulResult(_mapper.MapToCategoryResult(category));
        }

        return BadResult();
    }
}
