using MediatR;
using PostingService.Application.Abstractions;
using PostingService.Application.UseCases.Posts.Queries;
using PostingService.Domain.Entities;

namespace PostingService.Application.UseCases.Posts.QueryHandlers;
public class GetPostsHandler : IRequestHandler<GetPostsQuery, IEnumerable<Post>>
{
    private readonly IPostRepository _postRepo;
    public GetPostsHandler(IPostRepository postRepo)
    {
        _postRepo = postRepo;
    }

    public async Task<IEnumerable<Post>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        return await _postRepo.GetPosts();
    }
}
