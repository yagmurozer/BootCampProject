using Core.Security.Dtos;
using Core.Security.Entites;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        AccessToken Register(UserForRegisterDto userForRegisterDto);
        AccessToken Login(UserForLoginDto userForLoginDto);
        AccessToken CreateAccessToken(User user);
    }
}
