using VoteMicroservice.BusinessLayer.ModelDto;
using VoteMicroservice.DataAccessLayer.Models;
using VoteMicroservice.DataAccessLayer.Repository;

namespace VoteMicroservice.BusinessLayer.Services
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;

        public VoteService(IVoteRepository voteRepository)
        {
            _voteRepository = voteRepository;
        }

        public async Task<IEnumerable<VoteDto>> GetAllVotesAsync()
        {
            var votes = await _voteRepository.GetAllVotesAsync();
            return MapToVoteDtos(votes);
        }

        public async Task<IEnumerable<VoteDto>> GetVotesByUserIdAsync(int userId)
        {
            var votes = await _voteRepository.GetVotesByUserIdAsync(userId);
            return MapToVoteDtos(votes);
        }

        public async Task<IEnumerable<VoteDto>> GetVotesByPostIdAsync(int postId)
        {
            var votes = await _voteRepository.GetVotesByPostIdAsync(postId);
            return MapToVoteDtos(votes);
        }

        public async Task<VoteDto> GetVoteByIdAsync(int voteId)
        {
            var vote = await _voteRepository.GetVoteByIdAsync(voteId);
            return MapToVoteDto(vote);
        }

        public async Task<VoteDto> CreateVoteAsync(VoteDto vote)
        {
            var newVote = MapToVote(vote);
            newVote.CreatedAt = DateTime.Now;

            var createdVote = await _voteRepository.CreateVoteAsync(newVote);
            return MapToVoteDto(createdVote);
        }

        public async Task<bool> UpdateVoteAsync(VoteDto vote)
        {
            var existingVote = await _voteRepository.GetVoteByIdAsync(vote.VoteId);
            if (existingVote == null)
                return false;

            existingVote.UserId = vote.UserId;
            existingVote.PostId = vote.PostId;
            existingVote.VoteType = vote.VoteType;
            existingVote.ModifiedAt = DateTime.Now;

            await _voteRepository.UpdateVoteAsync(existingVote);
            return true;
        }

        public async Task<bool> DeleteVoteAsync(int voteId)
        {
            var existingVote = await _voteRepository.GetVoteByIdAsync(voteId);
            if (existingVote == null)
                return false;

            await _voteRepository.DeleteVoteAsync(existingVote.VoteId);
            return true;
        }


        private VoteDto MapToVoteDto(Vote vote)
        {
            return new VoteDto
            {
                VoteId = vote.VoteId,
                UserId = vote.UserId,
                PostId = vote.PostId,
                VoteType = vote.VoteType,
                CreatedAt = vote.CreatedAt,
                ModifiedAt = vote.ModifiedAt
            };
        }

        private IEnumerable<VoteDto> MapToVoteDtos(IEnumerable<Vote> votes)
        {
            var voteDtos = new List<VoteDto>();
            foreach (var vote in votes)
            {
                voteDtos.Add(MapToVoteDto(vote));
            }
            return voteDtos;
        }

        private Vote MapToVote(VoteDto voteDto)
        {
            return new Vote
            {
                VoteId = voteDto.VoteId,
                UserId = voteDto.UserId,
                PostId = voteDto.PostId,
                VoteType = voteDto.VoteType,
                CreatedAt = voteDto.CreatedAt,
                ModifiedAt = voteDto.ModifiedAt
            };
        }
    }
}
