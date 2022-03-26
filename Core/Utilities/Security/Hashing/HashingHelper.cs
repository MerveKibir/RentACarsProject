using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public static class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //hmacsha512 algoritmasını kullandık.
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                //salt anahtarı aldık
                passwordSalt = hmac.Key;
                //pasword vermeliyim ama bunu byte olarak vermeliyiz bunu da encoding ile çevirerek yapıyoruz.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        //kullanıcıların parola hashlerini karşılaştırdığımız metot
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //key anahtarını vererek yeni hmac oluşturduk.
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                //bu oluşturulan hmacin hash halini almalıyız.
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    //karakter karakter kontrol edildi. array olduğu için for ile gezdik.
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;//eşleşmiyorsa false döndür
                    }
                }
                return true;//eşleşiyorsa true döndür
            }
        }
    }
}