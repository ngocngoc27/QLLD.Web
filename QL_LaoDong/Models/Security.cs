using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QL_LaoDong.Models
{
    public class Security
    {
        public static string MD5(string pas)
        {
            Byte[] pass = Encoding.UTF8.GetBytes(pas);
            MD5 md5 = new MD5CryptoServiceProvider();
            string strPassword = Encoding.UTF8.GetString(md5.ComputeHash(pass));
            return strPassword;
        }
    }
}
