using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WEBEAPOS.DataAccess.DataModels;
using WEBEAPOS.DataAccess.DbContexts;

namespace WEBEAPOS.DataAccess.BusinessLayer
{
    public class UserHelper
    {
        EAPOSDBContext Context = new EAPOSDBContext();
        public List<TBL_USERS> GetAll()
        {
            return Context.TBL_USERS.ToList();
        }
        public TBL_USERS GetById(int id)
        {
            return Context.TBL_USERS.Where(p => p.UserId == id).FirstOrDefault();
        }
        public void Save(TBL_USERS obj)
        {
            var k = Context.TBL_USERS.Where(p => p.UserId == obj.UserId).FirstOrDefault();
            obj.Password = Encrypt(obj.Password);
            if (k == null)
            {
                obj.CreationDate = DateTime.Today;
                Context.TBL_USERS.Add(obj);
            }
            else
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<TBL_USERS, TBL_USERS>();
                });

                Mapper.Map(obj, k);
                //k.Password = Encrypt(obj.Password);
            }
            
            Context.SaveChanges();
        }
        public void Delete(int Id)
        {
            Context.TBL_USERS.Remove(Context.TBL_USERS.Where(p => p.UserId == Id).FirstOrDefault());
            Context.SaveChanges();
        }

        #region Encriptacion
        private readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;

        public string Encrypt(string plainText)
        {
            string passPhrase = "EncryptingIt!";
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                byte[] cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public string Decrypt(string cipherText)
        {
            string passPhrase = "EncryptingIt!";
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
