﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.JWT
{
    public class TokenOptions
    {
        public string Audience { get; set; } // bir kimlik doğrulama tokeninin hedef kitlesini temsil eden özellik
        public string Issuer { get; set; } // bir kimlik doğrulama işleminde tokeni veren kim olduğunu belirtiyor.
        public int AccessTokenExpiration { get; set; } // token geçerlilik süresi
        public string SecurityKey { get; set; } // Kimlik doğrulama için kullanılan güvenlik anahtarı
    }
}
