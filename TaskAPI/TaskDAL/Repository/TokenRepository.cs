using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TaskDAL.IRepository;
using TaskDAL.Context;
using Shared.Models.ViewModels;
using Shared.Entity;
using SharedFiles.Entities;
using Microsoft.IdentityModel.Tokens;

namespace TaskDAL.Repository {
    public class TokenRepository : GenericRepository<RefreshToken>, ITokenRepository {
        private readonly DatabaseContext _db;
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _configuration;
        private string jwtKey;
        public TokenRepository (DatabaseContext db,IUserRepository userRepo,
            IConfiguration configuration):base(db) {
            _userRepo = userRepo;
            _configuration = configuration;
            _db = db;
            jwtKey = "1CzrVyaB3k2i3KvS1b7M7wyIOvCFHVkUySi3pjt1VZbAlBiNI6pdTUuV_oNv1fqUBA";
        }
        public async Task<TokenModel> Authenticate (string username, string password) {
            ApplicationUser validateUser = await _userRepo.FindByEmailAsync (username);

            if (validateUser == null || !await _userRepo.CheckPassword (validateUser, password)) {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler ();
            var key = Encoding.ASCII.GetBytes (jwtKey);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity (new Claim[] {
                new Claim (ClaimTypes.NameIdentifier, validateUser.Id),
                new Claim (ClaimTypes.Role, Roles.User),
                }),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays (7),
                SigningCredentials = new SigningCredentials (new SymmetricSecurityKey (key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken (tokenDescriptor);
            TokenModel _user = new TokenModel();
            string refreshToken = Guid.NewGuid ().ToString ();
            _user.accessToken = tokenHandler.WriteToken (token);
            _user.refreshToken = refreshToken;
            _user.userId = validateUser.Id.ToString ();

            AddRefreshToken (new RefreshToken {
                userId = validateUser.Id.ToString (),
                    refreshToken = refreshToken,
                    revoked = false,
            });
            return _user;
        }

        public void AddRefreshToken (RefreshToken refreshToken) {
            _db.RefreshTokens.Add (refreshToken);
            _db.SaveChanges ();
        }

        public void RevokeRefreshToken (string refreshToken) {
            var refreshTokenModel = _db.RefreshTokens.Where (a => a.refreshToken.Equals (refreshToken)).FirstOrDefault ();
            refreshTokenModel.revoked = true;
            _db.SaveChanges ();
        }
        public void RemoveRefreshToken (string refreshToken) {
            var refreshTokenModel = _db.RefreshTokens.Where (a => a.refreshToken.Equals (refreshToken)).FirstOrDefault ();
            _db.Remove (refreshTokenModel);
            _db.SaveChanges ();
        }
        public void RemoveAllRefreshToken (string userId) {
            var all = _db.RefreshTokens.Where (x => x.userId.Equals (userId));
            _db.RefreshTokens.RemoveRange (all);
            _db.SaveChanges ();
        }

        public ApplicationUser FindUser (string refreshToken) {
            var refreshTokenModel = _db.RefreshTokens.
            Select (a => new {

                a.ApplicationUser,
                    a.userId,
                    a.revoked,
                    a.id,
                    a.refreshToken,

            }).
            Where (a => a.refreshToken.Equals (refreshToken)).FirstOrDefault ();
            if (refreshTokenModel == null || refreshTokenModel.revoked) {
                return null;
            }
            return refreshTokenModel.ApplicationUser;
        }


    }
}