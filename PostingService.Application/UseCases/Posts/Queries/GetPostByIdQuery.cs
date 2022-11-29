using MediatR;
using PostingService.Domain.Entities;

namespace PostingService.Application.UseCases.Posts.Queries;
public class GetPostByIdQuery : IRequest<Post>
{
    public int Id { get; set; }
}
