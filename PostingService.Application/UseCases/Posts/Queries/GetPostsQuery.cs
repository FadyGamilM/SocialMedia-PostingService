using MediatR;
using PostingService.Domain.Entities;
namespace PostingService.Application.UseCases.Posts.Queries;
public class GetPostsQuery : IRequest<IEnumerable<Post>>
{
    // we don't need nothing from the API layer to handle this type of operation
}
