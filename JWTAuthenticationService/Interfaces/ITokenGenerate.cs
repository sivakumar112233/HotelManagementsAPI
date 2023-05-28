

using JWTAuthenticationService.Models.DTO;

namespace JWTAuthenticationService.Interfaces
{
    
    public interface ITokenGenerate
    {
        // used to generate token by taking USerDTO as parameter
        // UserDTO is used transfer the data only
        public string GenerateToken(UserDTO user);
    }
}
