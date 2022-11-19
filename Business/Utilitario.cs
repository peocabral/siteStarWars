using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace Business
{
    public class Utilitario
    {
        private byte[] chave = { };
        private byte[] iv = { 12, 34, 56, 78, 90, 102, 114, 126 };

        private string chaveCriptografia = "unifev123456";

        //Criptografa 
        public string Criptografar(string text)
        {
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs; byte[] input;

            try
            {
                des = new DESCryptoServiceProvider();
                ms = new MemoryStream();

                input = Encoding.UTF8.GetBytes(text);
                chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));

                cs = new CryptoStream(ms, des.CreateEncryptor(chave, iv), CryptoStreamMode.Write);
                cs.Write(input, 0, input.Length);
                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Descriptografa
        public string Descriptografar(string text)
        {
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs; byte[] input;

            try
            {
                des = new DESCryptoServiceProvider();
                ms = new MemoryStream();

                input = new byte[text.Length];
                input = Convert.FromBase64String(text.Replace(" ", "+"));

                chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));

                cs = new CryptoStream(ms, des.CreateDecryptor(chave, iv), CryptoStreamMode.Write);
                cs.Write(input, 0, input.Length);
                cs.FlushFinalBlock();

                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //--------------------------------------------------

        public bool SendMail(string subject, string body, string to)
        {
            using (MailMessage mail = new MailMessage())
            {
                string from = "swsite88757@gmail.com";
                string pwd = "unifev2017";

                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(from, pwd);
                    smtp.EnableSsl = true;

                    try
                    {
                        smtp.Send(mail);
                        return true;
                    }
                    catch { return false; }
                }
            }
        }
    }
}
