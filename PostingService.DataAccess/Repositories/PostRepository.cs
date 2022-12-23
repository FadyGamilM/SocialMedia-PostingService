using Microsoft.EntityFrameworkCore;
using PostingService.Application.Abstractions;
using PostingService.Domain.Entities;

namespace PostingService.DataAccess.Repositories;
public class PostRepository : IPostRepository
{
    private readonly PostingServiceDbContext _context;
    public PostRepository(PostingServiceDbContext context)
    {
        _context = context;
    }

    public async Task<Post> CreatePost(Post post)
    {
        // update the created and updated dates of this post
        post.CreatedAt = DateTime.Now;
        post.UpdatedAt = DateTime.Now;

        // add the post to the model 
        await _context.Posts.AddAsync(post);

        // save the changes 
        await _context.SaveChangesAsync();

        // return the created post with its id
        return post;
    }

    public async Task DeletePost(int postId)
    {
        var existedPost = await _context.Posts.FindAsync(postId);
        if (existedPost != null)
        {
            // remove this post
            _context.Posts.Remove(existedPost);
           await _context.SaveChangesAsync();
        }
    }

    public async Task<Post> GetPostById(int postId)
    {
        var post = await _context.Posts.FindAsync(postId);
        return post;
    }

    public async Task<IEnumerable<Post>> GetPosts()
    {
        var posts = await _context.Posts.ToListAsync();
        return posts;
    }

    public async Task<Post> UpdatePost(string updatedContent, int postId)
    {
        var existedPost = await _context.Posts.FindAsync(postId);
        if (existedPost != null)
        {
            existedPost.UpdatedAt = DateTime.Now;
            existedPost.Content = updatedContent;
            await _context.SaveChangesAsync();
        }
        return existedPost;
    }
}
