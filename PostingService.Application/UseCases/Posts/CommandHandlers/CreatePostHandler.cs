using MediatR;
using PostingService.Application.Abstractions;
using PostingService.Application.UseCases.Posts.Commands;
using PostingService.Domain.Entities;


namespace PostingService.Application.UseCases.Posts.CommandHandlers;
public class CreatePostHandler : IRequestHandler<CreatePostCommand, Post>
{
    // inject the repo module using DI
    private readonly IPostRepository _postRepo;
    public CreatePostHandler(IPostRepository postRepo)
    {
        _postRepo = postRepo;
    }

    public async Task<Post> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var newPost = new Post
        {
            Content = request.Content,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };

        return await _postRepo.CreatePost(newPost);
    }
}
