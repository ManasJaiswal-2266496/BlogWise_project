using BlogWise_project.PostMicroservice.DataAccessLayer.Repository;
using BlogWise_project.ModelDto;
using BlogWise_project.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWise_project.PostMicroservice.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<PostDto>> GetAllPostsAsync()
        {
            try
            {
                var posts = await _postRepository.GetAllPostsAsync();
                return posts.Select(p => MapPostToDto(p));
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error message
                throw new Exception("Error occurred while getting all posts.", ex);
            }
        }

        public async Task<PostDto> GetPostByIdAsync(int postId)
        {
            try
            {
                var post = await _postRepository.GetPostByIdAsync(postId);
                return MapPostToDto(post);
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error message
                throw new Exception($"Error occurred while getting post with ID: {postId}.", ex);
            }
        }

        public async Task<PostDto> CreatePostAsync(PostDto postDto)
        {
            try
            {
                var post = MapDtoToPost(postDto);
                post.CreatedAt = DateTime.Now;

                await _postRepository.CreatePostAsync(post);
                return MapPostToDto(post);
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error message
                throw new Exception("Error occurred while creating a new post.", ex);
            }
        }

        public async Task<bool> UpdatePostAsync(int postId, PostDto postDto)
        {
            try
            {
                var existingPost = await _postRepository.GetPostByIdAsync(postId);
                if (existingPost == null)
                    return false;

                existingPost.Title = postDto.Title;
                existingPost.Content = postDto.Content;
                existingPost.Author = postDto.Author;
                // Update other properties as needed

                await _postRepository.UpdatePostAsync(existingPost);
                return true;
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error message
                throw new Exception($"Error occurred while updating post with ID: {postId}.", ex);
            }
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            try
            {
                var existingPost = await _postRepository.GetPostByIdAsync(postId);
                if (existingPost == null)
                    return false;

                await _postRepository.DeletePostAsync(postId);
                return true;
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error message
                throw new Exception($"Error occurred while deleting post with ID: {postId}.", ex);
            }
        }

        private PostDto MapPostToDto(Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Author = post.Author
            };
        }

        private Post MapDtoToPost(PostDto postDto)
        {
            return new Post
            {
                Id = postDto.Id,
                Title = postDto.Title,
                Content = postDto.Content,
                Author = postDto.Author
            };
        }
    }
}

/*using BlogWise_project.PostMicroservice.DataAccessLayer.Repository;
using BlogWise_project.ModelDto;
using BlogWise_project.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWise_project.PostMicroservice.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<PostDto>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllPostsAsync();
            return posts.Select(p => MapPostToDto(p));
        }

        public async Task<PostDto> GetPostByIdAsync(int postId)
        {
            var post = await _postRepository.GetPostByIdAsync(postId);
            return MapPostToDto(post);
        }

        public async Task<PostDto> CreatePostAsync(PostDto postDto)
        {
            var post = MapDtoToPost(postDto);
            post.CreatedAt = DateTime.Now;

            await _postRepository.CreatePostAsync(post);
            return MapPostToDto(post);
        }

        public async Task<bool> UpdatePostAsync(int postId, PostDto postDto)
        {
            var existingPost = await _postRepository.GetPostByIdAsync(postId);
            if (existingPost == null)
                return false;

            existingPost.Title = postDto.Title;
            existingPost.Content = postDto.Content;
            existingPost.Author = postDto.Author;
            // Update other properties as needed

            await _postRepository.UpdatePostAsync(existingPost);
            return true;
        }



        public async Task<bool> DeletePostAsync(int postId)
        {
            var existingPost = await _postRepository.GetPostByIdAsync(postId);
            if (existingPost == null)
                return false;

            await _postRepository.DeletePostAsync(postId); 
            return true;
        }


        private PostDto MapPostToDto(Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Author = post.Author
                
            };
        }

        private Post MapDtoToPost(PostDto postDto)
        {
            return new Post
            {
                Id = postDto.Id,
                Title = postDto.Title,
                Content = postDto.Content,
                Author = postDto.Author
                
            };
        }
    }
}
*/