using PostingService.Domain.Entities;

namespace PostingService.Application.Abstractions;
public interface IPostRepository
{
    Task<IEnumerable<Post>> GetPosts();

    Task<Post> GetPostById(int postId);

    Task<Post> CreatePost(Post post);

    Task<Post> UpdatePost(string updatedContent, int postId);

    Task DeletePost(int postId);
}
