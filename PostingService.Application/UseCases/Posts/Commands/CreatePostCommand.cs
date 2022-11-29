using MediatR;
using PostingService.Domain.Entities;

namespace PostingService.Application.UseCases.Posts.Commands;
// specify the type we want to return " <Post> "
public class CreatePostCommand : IRequest<Post>
{
    // required info to pass to the PostRepository to create a new post resource
    public string Content { get; set; }
}
