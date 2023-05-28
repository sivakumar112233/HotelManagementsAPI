using JWTAuthenticationService.Interfaces;
using JWTAuthenticationService.Models;
using JWTAuthenticationService.Models.DTO;
using JWTAuthenticationServices.Interfaces;

using System.Security.Cryptography;
using System.Text;

namespace JWTAuthenticationService.Services
{
    public class UserService
    {
        private IBaseRepo<string, User> _repo;
        private ITokenGenerate _tokenService;

        public UserService(IBaseRepo<string,User> repo,ITokenGenerate tokenGenerate)
        {
            _repo = repo;
            _tokenService = tokenGenerate;
        }
        //Login(UserDTO userDTO) method Checks the user is login or not if login returns UserDTO
        public UserDTO Login(UserDTO userDTO)
        {
            UserDTO user = null;
            var userData = _repo.Get(userDTO.Username);
            if(userData != null)
            {
                // creating new hmac instance
                var hmac = new HMACSHA512(userData.HashKey);
                // Encoding Password
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.Password[i])
                        return null;
                }
                user = new UserDTO();
                user.Username = userData.Username;
               // generating token
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }
        // The Register(UserRegisterDTO userDTO)  method takes UserDTO and adds the user
        //return the uSerDTO
        public UserDTO Register(UserRegisterDTO userDTO) 
        {
            UserDTO user = null;
            var hmac = new HMACSHA512();
            userDTO.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.PasswordClear));
            userDTO.HashKey = hmac.Key;
            var resultUser = _repo.Add(userDTO);
            if(resultUser != null)
            {
                user = new UserDTO();
                user.Username = resultUser.Username;
             
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }
    }
}
