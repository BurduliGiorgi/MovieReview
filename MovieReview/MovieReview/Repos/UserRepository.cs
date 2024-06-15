using MovieReview.Models;

namespace MovieReview.Repos
{
    public class UserRepository : IUserRepository
    {
        private List<ApplicationUser> users;

        public UserRepository()
        {
            users = new List<ApplicationUser>();
            
        }

        // get user by id
        public ApplicationUser GetUserById(int userId)
        {
            return users.Find(user => user.Id == userId.ToString());
        }

        // get all users
        public List<ApplicationUser> GetAllUsers()
        {
            return users;
        }

        // add new user
        public void AddUser(ApplicationUser newUser)
        {
            users.Add(newUser);
        }

        // update user
        public ApplicationUser UpdateUser(ApplicationUser updatedUser)
        {
            int index = users.FindIndex(user => user.Id == updatedUser.Id);
            users[index] = updatedUser;
            return updatedUser;
        }

        // delete user by id
        public void DeleteUser(int userId)
        {
            int index = users.FindIndex(user => user.Id == userId.ToString());
            users.RemoveAt(index);
        }
    }
}
