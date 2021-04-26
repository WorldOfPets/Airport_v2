using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Aiport_v2.classFolder
{
    class classHash
    {
        public static string GetHashString(string password)//Получение хэш-кода
        {
            //var User = classFolder.dbClass.entities.User.FirstOrDefault(x => x.Id == i);
            //User.Password.GetHashCode();
            //classFolder.dbClass.entities.SaveChanges();
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
            //User.Password = hash;
            //classFolder.dbClass.entities.SaveChanges();
        }
    }
}
