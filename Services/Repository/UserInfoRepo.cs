using DataAccess.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Helpers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Services.Repository
{
    public class UserInfoRepo:IUserInfo
    {
        private List<UserInfo> _users = new List<UserInfo>
        {
            new UserInfo{Username="Administrator",Password="admin123", Role="Admin"}
            
        };
        private readonly AppSettings _apSettings;
         
        public UserInfoRepo(IOptions<AppSettings> appSettings)
        {
            _apSettings = appSettings.Value;

        }

        public UserInfo Authenticate(string username , string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);
            if (user == null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_apSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserID.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
                
            return user;
        }


        public IEnumerable <UserInfo> GetAll()
        {
            return _users;
        }
    }
}
