/*using NUnit.Framework;
using BlogWise_project.PostMicroservice.Services;
using BlogWise_project.PostMicroservice.DataAccessLayer.Repository;
using Moq;
using BlogWise_project.DataAccessLayer.Models;

namespace BlogWise_project.Tests
{
    [TestFixture]
    public class PostServiceTests
    {
        private IPostService _postService;
        private Mock<IPostRepository> _postRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            // Create a mock instance of the post repository
            _postRepositoryMock = new Mock<IPostRepository>();

            // Initialize the post service with the mock repository
            _postService = new PostService(_postRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllPostsAsync_ReturnsPosts()
        {
            // Arrange
            var expectedPosts = new List<Post>
            {
                new Post { Id = 1, Title = "Post 1" },
                new Post { Id = 2, Title = "Post 2" }
            };

            // Set up the mock repository to return the expected posts
            _postRepositoryMock.Setup(repo => repo.GetAllPostsAsync())
                .ReturnsAsync(expectedPosts);

            // Act
            var result = await _postService.GetAllPostsAsync();

            // Assert
            Assert.AreEqual(expectedPosts, result);
        }

        [Test]
        public async Task GetPostByIdAsync_ExistingPostId_ReturnsPost()
        {
            // Arrange
            var postId = 1;
            var expectedPost = new Post { Id = postId, Title = "Test Post" };

            // Set up the mock repository to return the expected post
            _postRepositoryMock.Setup(repo => repo.GetPostByIdAsync(postId))
                .ReturnsAsync(expectedPost);

            // Act
            var result = await _postService.GetPostByIdAsync(postId);

            // Assert
            Assert.AreEqual(expectedPost, result);
        }

        [Test]
        public async Task GetPostByIdAsync_NonExistingPostId_ReturnsNull()
        {
            // Arrange
            var postId = 1;

            // Set up the mock repository to return null for non-existing post
            _postRepositoryMock.Setup(repo => repo.GetPostByIdAsync(postId))
                .ReturnsAsync((Post)null);

            // Act
            var result = await _postService.GetPostByIdAsync(postId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task CreatePostAsync_ValidPost_ReturnsCreatedPost()
        {
            // Arrange
            var postToCreate = new Post { Title = "New Post", Content = "Lorem ipsum" };
            var createdPostId = 1;
            var createdPost = new Post { Id = createdPostId, Title = "New Post", Content = "Lorem ipsum" };

            // Set up the mock repository to return the created post
            _postRepositoryMock.Setup(repo => repo.CreatePostAsync(postToCreate))
                .ReturnsAsync(createdPostId);
            _postRepositoryMock.Setup(repo => repo.GetPostByIdAsync(createdPostId))
                .ReturnsAsync(createdPost);

            // Act
            var result = await _postService.CreatePostAsync(postToCreate);

            // Assert
            Assert.AreEqual(createdPost, result);
        }

        [Test]
        public async Task UpdatePostAsync_ExistingPost_ReturnsUpdatedPost()
        {
            // Arrange
            var postId = 1;
            var postToUpdate = new Post { Id = postId, Title = "Updated Post", Content = "Updated content" };
            var updatedPost = new Post { Id = postId, Title = "Updated Post", Content = "Updated content" };

            // Set up the mock repository to return the updated post
            _postRepositoryMock.Setup(repo => repo.UpdatePostAsync(postToUpdate))
                .ReturnsAsync(updatedPost);

            // Act
            var result = await _postService.UpdatePostAsync(postToUpdate);

            // Assert
            Assert.AreEqual(updatedPost, result);
        }

        [Test]
        public async Task DeletePostAsync_ExistingPostId_ReturnsTrue()
        {
            // Arrange
            var postId = 1;

            // Set up the mock repository to return true for successful deletion
            _postRepositoryMock.Setup(repo => repo.DeletePostAsync(postId))
                .ReturnsAsync(true);

            // Act
            var result = await _postService.DeletePostAsync(postId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeletePostAsync_NonExistingPostId_ReturnsFalse()
        {
            // Arrange
            var postId = 1;

            // Set up the mock repository to return false for non-existing post
            _postRepositoryMock.Setup(repo => repo.DeletePostAsync(postId))
                .ReturnsAsync(false);

            // Act
            var result = await _postService.DeletePostAsync(postId);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
*/