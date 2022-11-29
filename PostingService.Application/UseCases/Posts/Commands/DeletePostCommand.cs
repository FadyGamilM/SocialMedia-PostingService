using MediatR;

namespace PostingService.Application.UseCases.Posts.Commands;
public class DeletePostCommand : IRequest
{
    // what we need from user (API Request Body) to fullfill this request is the id of the post
    public int Id { get; set; }
}
