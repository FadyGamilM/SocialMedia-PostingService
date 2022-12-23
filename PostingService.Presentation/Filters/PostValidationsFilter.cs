using Microsoft.IdentityModel.Tokens;
using PostingService.Domain.Entities;

namespace PostingService.Presentation.Filters;

public class PostValidationsFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        // access the argument we need to filter ==> in our cas its the post argument "the 2nd always in the route handler"
        var postToBeFiltered = context.GetArgument<Post>(1);

        if(postToBeFiltered.Content.IsNullOrEmpty())
        {
            return await Task.FromResult(Results.BadRequest("Post Can't Be Created With Empty Content"));
        }

        return await next(context);
    }
}
