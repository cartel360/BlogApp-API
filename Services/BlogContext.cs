using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BlogAPI.Models;

namespace BlogAPI.Services
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}