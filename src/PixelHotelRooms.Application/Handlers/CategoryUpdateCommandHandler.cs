﻿using FluentValidation;
using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Services;
using PixelHotel.Events.Rooms.Category;
using PixelHotelRooms.Application.Abstractions;
using PixelHotelRooms.Domain.CategoryAggregate;
using PixelHotelRooms.Domain.CategoryAggregate.Commands;

namespace PixelHotelRooms.Application.Handlers;

internal sealed class CategoryUpdateCommandHandler : CommandHandlerBase<CategoryUpdateCommand>
{
    private readonly ICategoryMapper _mapper;
    private readonly ICategoryRepository _repository;
    private readonly ICategoryPublisher _publisher;

    public CategoryUpdateCommandHandler(IUnitOfWork unitOfWork,
        IValidator<CategoryUpdateCommand> validator,
        ICategoryMapper mapper,
        ICategoryRepository repository,
        ICategoryPublisher publisher) : base(unitOfWork, validator)
    {
        _mapper = mapper;
        _repository = repository;
        _publisher = publisher;
    }

    public override async Task<Result> Handle(CategoryUpdateCommand command, CancellationToken cancellationToken)
    {
        if (!await Validate(command))
        {
            return BadResult();
        }

        var category = await _repository.GetById(command.Id);
        category.SetName(command.Name);
        _repository.Update(category);

        if (await Commit())
        {
            var @event = new CategoryCreatedUpdatedEvent(category.Id, category.Name);
            await _publisher.PublishCreatedUpdatedEvent(@event);

            return SuccessfulResult(_mapper.MapToCategoryResult(category));
        }

        return BadResult();
    }
}
