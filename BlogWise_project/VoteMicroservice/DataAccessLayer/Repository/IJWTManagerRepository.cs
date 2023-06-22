using UserMicroservice.DataAccessLayer.Models;
using VoteMicroservice.DataAccessLayer.Models;

namespace VoteMicroservice.DataAccessLayer.Repository
{
    public interface IJWTManagerRepository
    {
        string Authenticate(User user);
    }
}
