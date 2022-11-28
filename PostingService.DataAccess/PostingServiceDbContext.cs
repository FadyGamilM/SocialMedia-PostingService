using Microsoft.EntityFrameworkCore;
using PostingService.Domain.Entities;

namespace PostingService.DataAccess;
public class PostingServiceDbContext : DbContext 
{
    public PostingServiceDbContext(DbContextOptions<PostingServiceDbContext> options)
        : base(options) { }

    public DbSet<Post> Posts { get; set; }
}
