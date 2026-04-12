using Microsoft.AspNetCore.Identity;

namespace IclPaths.API.Domain.Interfaces.AuthInterfaces
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
