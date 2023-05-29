using System.Collections.Generic;
using System.Threading.Tasks;
using VoteMicroservice.DataAccessLayer.Models;

namespace VoteMicroservice.DataAccessLayer.Repository
{
    public interface IVoteRepository
    {
        Task<IEnumerable<Vote>> GetAllVotesAsync();
        Task<IEnumerable<Vote>> GetVotesByUserIdAsync(int userId);
        Task<IEnumerable<Vote>> GetVotesByPostIdAsync(int postId);
        Task<Vote> GetVoteByIdAsync(int voteId);
        Task<Vote> CreateVoteAsync(Vote vote);
        Task<Vote> UpdateVoteAsync(Vote vote);
        Task<bool> DeleteVoteAsync(int voteId);
    }
}
