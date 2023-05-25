using BlogWise_project.DataAccessLayer.Data;
using BlogWise_project.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogWise_project.PostMicroservice.DataAccessLayer.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogWiseDBContext _dbContext;

        public PostRepository(BlogWiseDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _dbContext.Posts.FindAsync(id);
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            _dbContext.Posts.Add(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            _dbContext.Entry(post).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var post = await _dbContext.Posts.FindAsync(id);
            if (post == null)
                return false;

            _dbContext.Posts.Remove(post);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
