using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Images.Queries;

public class UploadImagesQuery : IRequest
{
    public int Id { get; set; }
}

public class UploadImagesQueryHandler : IRequestHandler<UploadImagesQuery>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIMageService _imageservice;

    public UploadImagesQueryHandler(IApplicationDbContext context, IMapper mapper, IIMageService imageservice)
    {
        _context = context;
        _mapper = mapper;
        _imageservice = imageservice;
    }

    public async Task<Unit> Handle(UploadImagesQuery request, CancellationToken cancellationToken)
    {
        //_imageservice.Process();
        //var records = await _context.TodoItems
        //        .Where(t => t.ListId == request.ListId)
        //        .ProjectTo<TodoItemRecord>(_mapper.ConfigurationProvider)
        //        .ToListAsync(cancellationToken);

        //  _imageservice.Process(request.Id.........);

        //var vm = new ExportTodosVm(
        //    "TodoItems.csv",
        //    "text/csv",
        //    _fileBuilder.BuildTodoItemsFile(records));

        return Unit.Value;
    }
}