using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //jwt servislerinde tokenların oluşturulabilmesi için credential lara ihtiyacımız var burada da securitykey
        //bu da onun imzalama listesini döndürecek
        //aspnete diyoruz ki anahtar olarak bu securityi kullan çünkü hashing işlemi yapacaksın algoritma olarak da sha512 yapacaksın dedik
        //biz core da yaptık zaten ama buna aspnetin de bilmesi lazım. hangi anahtar hangi doğrulama belirttik.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}