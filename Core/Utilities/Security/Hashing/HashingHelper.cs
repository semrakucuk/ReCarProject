using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passworsHash , out byte[] passwordSalt ) 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) 
            {
                passwordSalt = hmac.Key;
                passworsHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password ,   byte[] passworsHash,   byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
              var  computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i]!=passworsHash[i])
                    {
                        return false;
                    }
                }
            }
            return true; 
        }

        public static bool VerifyPasswordHash(string password, object passwordHash, object passwordSalt)
        {
            throw new NotImplementedException();
        }
    }
}
