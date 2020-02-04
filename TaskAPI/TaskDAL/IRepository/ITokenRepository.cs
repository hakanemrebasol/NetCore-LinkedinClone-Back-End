using System.Threading.Tasks;
using Shared.Entity;
using Shared.Models.ViewModels;
using SharedFiles.Entities;

namespace TaskDAL.IRepository {
    public interface ITokenRepository: IGenericRepository<RefreshToken>
    {
        Task<TokenModel> Authenticate (string username, string password);
        //TokenModel AuthenticateWithRefreshToken (string refreshToken);
        void RemoveAllRefreshToken (string userId);
        void AddRefreshToken (RefreshToken refreshToken);
        void RevokeRefreshToken (string refreshToken);
        void RemoveRefreshToken (string refreshToken);
        ApplicationUser FindUser (string refreshToken);
    }
}