using MovieReview.Models;
using MovieReview.Repos;
using System.Collections.Generic;

namespace MovieReview.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ApplicationUser GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public List<ApplicationUser> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public void AddUser(ApplicationUser newUser)
        {
            _userRepository.AddUser(newUser);
        }

        public ApplicationUser UpdateUser(ApplicationUser updatedUser)
        {
            return _userRepository.UpdateUser(updatedUser);
        }

        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
        }
    }
}
