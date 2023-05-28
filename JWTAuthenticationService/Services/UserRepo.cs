using System.Diagnostics;
using JWTAuthenticationService.Models;
using JWTAuthenticationServices.Interfaces;

namespace JWTAuthenticationService.Services
{
    public class UserRepo : IBaseRepo<string, User>
    {
        private readonly JWTContext _context;

        public UserRepo(JWTContext context)
        {
            _context = context;
        }
        // The Add(User item) method adds user
        public User Add(User item)
        {
            try
            {
                _context.Users.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(item);
            }
            return null;
        }
        // The Get(string key) returns the user that matches the key
        public User Get(string key)
        {
            // fetching user data
            var user = _context.Users.FirstOrDefault(u=>u.Username == key);
            return user;
        }

        
    }
}
