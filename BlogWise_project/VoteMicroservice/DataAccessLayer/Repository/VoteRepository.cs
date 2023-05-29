using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VoteMicroservice.DataAccessLayer.Data;
using VoteMicroservice.DataAccessLayer.Models;

namespace VoteMicroservice.DataAccessLayer.Repository
{
    public class VoteRepository : IVoteRepository
    {
        private readonly VoteMicroserviceDBContext _dbContext;

        public VoteRepository(VoteMicroserviceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Vote>> GetAllVotesAsync()
        {
            return await _dbContext.Votes.ToListAsync();
        }

        public async Task<IEnumerable<Vote>> GetVotesByUserIdAsync(int userId)
        {
            return await _dbContext.Votes.Where(v => v.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Vote>> GetVotesByPostIdAsync(int postId)
        {
            return await _dbContext.Votes.Where(v => v.PostId == postId).ToListAsync();
        }

        public async Task<Vote> GetVoteByIdAsync(int voteId)
        {
            return await _dbContext.Votes.FindAsync(voteId);
        }

        public async Task<Vote> CreateVoteAsync(Vote vote)
        {
            _dbContext.Votes.Add(vote);
            await _dbContext.SaveChangesAsync();
            return vote;
        }

        public async Task<Vote> UpdateVoteAsync(Vote vote)
        {
            _dbContext.Entry(vote).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return vote;
        }

        public async Task<bool> DeleteVoteAsync(int voteId)
        {
            var vote = await _dbContext.Votes.FindAsync(voteId);
            if (vote == null)
                return false;

            _dbContext.Votes.Remove(vote);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
