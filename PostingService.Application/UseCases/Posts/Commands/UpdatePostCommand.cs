using MediatR;
using PostingService.Domain.Entities;

namespace PostingService.Application.UseCases.Posts.Commands;
public class UpdatePostCommand : IRequest<Post>
{
    // what we need to update the post is the id of the post and the content of it 
    public int Id { get; set; }
    public string Content { get; set; }
}
