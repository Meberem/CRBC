using CRBC.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CRBC
{
    public static class SiteUtils
    {
        public static string GenerateSaltedHash(string password, string user_guid)
        {
            byte[] passswordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Encoding.UTF8.GetBytes(user_guid);
            IEnumerable<byte> passwordWithSalt = passswordBytes.Concat(saltBytes);
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] saltedHashBytes = algorithm.ComputeHash(passwordWithSalt.ToArray());
            return Convert.ToBase64String(saltedHashBytes);
        }

        public static UserInfo ReadUserInfo(ClaimsPrincipal user)
        {
            Claim customerClaim = user.Claims.Where(x => x.Type == "userInfo").FirstOrDefault();
            return JsonConvert.DeserializeObject<UserInfo>(customerClaim.Value);
        }
    }
}
