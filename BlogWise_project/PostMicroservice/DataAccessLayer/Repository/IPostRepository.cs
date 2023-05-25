using BlogWise_project.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogWise_project.PostMicroservice.DataAccessLayer.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(int id);
        Task<Post> CreatePostAsync(Post post);
        Task<bool> UpdatePostAsync(Post post);
        Task<bool> DeletePostAsync(int id);
    }
}
