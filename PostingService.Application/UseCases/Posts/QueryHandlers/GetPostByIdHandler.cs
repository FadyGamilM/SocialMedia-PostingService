using MediatR;
using PostingService.Application.Abstractions;
using PostingService.Application.UseCases.Posts.Queries;
using PostingService.Domain.Entities;

namespace PostingService.Application.UseCases.Posts.QueryHandlers;
internal class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, Post>
{
    private readonly IPostRepository _postRepo;
    public GetPostByIdHandler(IPostRepository postRepo)
    {
        _postRepo = postRepo;
    }
    public async Task<Post> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        return await _postRepo.GetPostById(request.Id); 
    }
}
