using MediatR;
using PostingService.Application.Abstractions;
using PostingService.Application.UseCases.Posts.Commands;

namespace PostingService.Application.UseCases.Posts.CommandHandlers;
public class DeletePostHandler : IRequestHandler<DeletePostCommand>
{
    private readonly IPostRepository _postRepo;
    public DeletePostHandler(IPostRepository postRepo)
    {
        _postRepo = postRepo;
    }

    public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        await _postRepo.DeletePost(request.Id);
        return Unit.Value;
    }
}
