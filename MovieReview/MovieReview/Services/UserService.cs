using System;
using System.Linq;
using System.Text.RegularExpressions;
using MovieReview.Models;
using MovieReview.Repos;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public bool RegisterUser(string email, string username, string password, string firstName, string lastName, string address)
    {
        if (!IsValidEmail(email))
            throw new ArgumentException("Invalid email format.");

        if (_userRepository.GetAllUsers().Any(user => user.Email == email))
            throw new ArgumentException("Email is already in use.");

        if (_userRepository.GetAllUsers().Any(user => user.UserName == username))
            throw new ArgumentException("Username is already in use.");

        if (!IsValidPassword(password))
            throw new ArgumentException("Password does not meet strength requirements.");

        var user = new ApplicationUser
        {
            Email = email,
            UserName = username,
            PasswordHash = password, // Assume hashing is done elsewhere
            FirstName = firstName,
            LastName = lastName,
            Address = address,
            CreatedAt = DateTime.UtcNow
        };

        _userRepository.AddUser(user);
        return true;
    }

    public ApplicationUser AuthenticateUser(string email, string password)
    {
        var user = _userRepository.GetAllUsers().SingleOrDefault(user => user.Email == email);
        if (user == null || user.PasswordHash != password) // Password hashing should be handled properly
            throw new ArgumentException("Invalid credentials.");

        return user;
    }

    public ApplicationUser GetUserProfile(int userId)
    {
        return _userRepository.GetUserById(userId);
    }

    private bool IsValidEmail(string email)
    {
        var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailPattern);
    }

    private bool IsValidPassword(string password)
    {
        return password.Length >= 8 &&
               password.Any(char.IsUpper) &&
               password.Any(char.IsLower) &&
               password.Any(char.IsDigit);
    }
}
