using System.Collections.Specialized;
using MovieReview.Models;

namespace MovieReview.Repos
{
    public interface IUserRepository
    {
        public ApplicationUser GetUserById(int userId);
        public List<ApplicationUser> GetAllUsers();
        public void AddUser(ApplicationUser newUser);
        public ApplicationUser UpdateUser(ApplicationUser updatedUser);
        public void DeleteUser(int userId);
    }
}
