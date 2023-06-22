using BlogWise_project.PostMicroservice.DataAccessLayer.Models;
using UserMicroservice.DataAccessLayer.Models;

namespace BlogWise_project.PostMicroservice.DataAccessLayer.Repository
{
    public interface IJWTManagerRepository
    {
        string Authenticate(User user);
    }
}

