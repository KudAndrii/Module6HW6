using IdentityModel.Client;

namespace IdentityClientApp.Interfaces
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
