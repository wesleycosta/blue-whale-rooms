using FluentValidation;
using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Services;
using PixelHotelRooms.Application.Abstractions;
using PixelHotelRooms.Domain.Aggregates;
using PixelHotelRooms.Domain.Commands;
using PixelHotelRooms.Domain.Repositories;

namespace PixelHotelRooms.Application.Handlers;

internal sealed class CategoryCreateCommandHandler : CommandHandlerBase<CategoryCreateCommand>
{
    private readonly ICategoryMapper _mapper;
    private readonly ICategoryRepository _repository;

    public CategoryCreateCommandHandler(IUnitOfWork unitOfWork,
        IValidator<CategoryCreateCommand> validator,
        ICategoryMapper mapper,
        ICategoryRepository repository) : base(unitOfWork, validator)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public override async Task<Result> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        if (!await Validate(request))
        {
            return BadResult();
        }

        var category = new Category();
        category.UpdateFrom(request);
        var response = _mapper.MapToCategoryResponse(category);
        _repository.Add(category);

        return await SaveChanges(response);
    }
}
