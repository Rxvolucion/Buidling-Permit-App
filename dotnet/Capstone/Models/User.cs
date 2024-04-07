namespace Capstone.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
<<<<<<< HEAD
=======
        public bool IsEmployee { get; set; } = false;
        public string Email { get; set; }
        public bool Active { get; set; }
>>>>>>> 47df3f27a349438ca20fb646c8225d682bbe1d32
        public string Role { get; set; }
    }

    /// <summary>
    /// Model of user data to return upon successful login
    /// </summary>
    public class ReturnUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }

    /// <summary>
    /// Model to return upon successful login (user data + token)
    /// </summary>
    public class LoginResponse
    {
        public ReturnUser User { get; set; }
        public string Token { get; set; }
    }

    /// <summary>
    /// Model to accept login parameters
    /// </summary>
    public class LoginUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// Model to accept registration parameters
    /// </summary>
    public class RegisterUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
<<<<<<< HEAD
=======
        public bool IsEmployee { get; set; } = false;
        public string Email { get; set; }
        public bool Active { get; set; }
>>>>>>> 47df3f27a349438ca20fb646c8225d682bbe1d32
    }

}
