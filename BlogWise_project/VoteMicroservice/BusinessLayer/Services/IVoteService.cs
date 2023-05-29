using System.Collections.Generic;
using System.Threading.Tasks;
using VoteMicroservice.BusinessLayer.ModelDto;

namespace VoteMicroservice.BusinessLayer.Services
{
    public interface IVoteService
    {
        Task<IEnumerable<VoteDto>> GetAllVotesAsync();
        Task<IEnumerable<VoteDto>> GetVotesByUserIdAsync(int userId);
        Task<IEnumerable<VoteDto>> GetVotesByPostIdAsync(int postId);
        Task<VoteDto> GetVoteByIdAsync(int voteId);
        Task<VoteDto> CreateVoteAsync(VoteDto vote);
        Task<bool> UpdateVoteAsync(VoteDto vote);
        Task<bool> DeleteVoteAsync(int voteId);
    }
}
