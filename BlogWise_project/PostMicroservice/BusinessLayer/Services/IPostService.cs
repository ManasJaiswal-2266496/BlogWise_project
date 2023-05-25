using BlogWise_project.ModelDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogWise_project.PostMicroservice.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllPostsAsync();
        Task<PostDto> GetPostByIdAsync(int postId);
        Task<PostDto> CreatePostAsync(PostDto postDto);
        Task<bool> UpdatePostAsync(int postId, PostDto postDto);
        Task<bool> DeletePostAsync(int postId);
    }
}
