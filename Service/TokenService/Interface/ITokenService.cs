using Core.Entites;

namespace Services.TokenService.Interface
{
    public interface ITokenService
    {
        string CreateToken(Users user);
    }
}
