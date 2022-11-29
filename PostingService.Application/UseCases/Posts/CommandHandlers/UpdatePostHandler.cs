using MediatR;
using PostingService.Application.Abstractions;
using PostingService.Application.UseCases.Posts.Commands;
using PostingService.Domain.Entities;

namespace PostingService.Application.UseCases.Posts.CommandHandlers;
public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, Post>
{
    private readonly IPostRepository _postRepo;
    public UpdatePostHandler(IPostRepository postRepo)
    {
        _postRepo = postRepo;
    }

    public async Task<Post> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        return await _postRepo.UpdatePost(request.Content, request.Id);
    }
}
