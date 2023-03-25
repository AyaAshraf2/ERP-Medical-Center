using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web;
using System;

namespace Utilities
{
    public class WebHelper
    {

        #region Members

        public static DateTime MinDateTime
        {
            get { return new DateTime(1753, 1, 1); }
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Checks whether a string is an integer number or not.
        /// </summary>
        /// <param name="Input">The string to check whether it is an integer number or not.</param>
        /// <returns>Returns true if the input string is an integer number otherwise it returns false.</returns>
        public static bool CheckNumberInt(string strInput)
        {
            if (string.IsNullOrEmpty(strInput))
                return false;
            if (strInput[0] == '-')
                strInput = strInput.Substring(1);
            for (int i = 0; i < strInput.Length; i++)
            {
                char A = strInput[i];
                if (A == '0' || A == '1' || A == '2' || A == '3' ||
                    A == '4' || A == '5' || A == '6' || A == '7' ||
                    A == '8' || A == '9')
                    continue;
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks whether an object  is an integer number or not.
        /// </summary>
        /// <param name="objInput">The object to check whether it is an integer number or not.</param>
        /// <returns>Returns true if the input object is an integer number otherwise it returns false.</returns>
        public static bool CheckNumberInt(object objInput)
        {
            if (objInput == null)
                return false;
            else
                return CheckNumberInt(objInput.ToString());
        }

        /// <summary>
        /// Checks whether a string is a double number or not.
        /// </summary>
        /// <param name="Input">The string to check whether it is a double number or not.</param>
        /// <returns>Returns true if the input string is a double number otherwise it returns false.</returns>
        public static bool CheckNumberDouble(string strInput)
        {
            if (string.IsNullOrEmpty(strInput))
                return false;
            if (strInput.StartsWith(".")) return false;
            if (strInput.EndsWith(".")) return false;
            string SubInput = strInput.Substring(strInput.IndexOf('.') + 1);
            if (SubInput.IndexOf('.') != -1) return false;
            for (int i = 0; i < strInput.Length; i++)
            {
                char A = strInput[i];
                if (A == '0' || A == '1' || A == '2' || A == '3' ||
                    A == '4' || A == '5' || A == '6' || A == '7' ||
                    A == '8' || A == '9' || A == '.')
                    continue;
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks whether an object is a double number or not.
        /// </summary>
        /// <param name="Input">The object to check whether it is a double number or not.</param>
        /// <returns>Returns true if the input object is a double number otherwise it returns false.</returns>
        public static bool CheckNumberDouble(object objInput)
        {
            if (objInput == null)
                return false;
            else
                return CheckNumberDouble(objInput.ToString());
        }

        /// <summary>
        /// Tests if the supplied byte array represents an image or not.
        /// </summary>
        /// <param name="data">The byte array to test.</param>
        /// <returns>Returns true if the supplied byte array is an image other wise it returns false.</returns>
        public static bool IsImage(byte[] data)
        {
            //read 64 bytes of the stream only to determine the type
            string myStr = System.Text.Encoding.ASCII.GetString(data).Substring(0, 16);
            //check if its definately an image.
            if (myStr.Substring(8, 2).ToString().ToLower() != "if")
            {
                //its not a jpeg
                if (myStr.Substring(0, 3).ToString().ToLower() != "gif")
                {
                    //its not a gif 
                    if (myStr.Substring(0, 2).ToString().ToLower() != "bm")
                    {
                        //its not a .bmp                   
                        if (myStr.Substring(0, 2).ToString().ToLower() != "ii")
                        {
                            //its not a .png
                            if (myStr.Substring(1, 3).ToLower() != "png")
                            {
                                myStr = null;
                                return false;
                            }
                        }
                    }
                }
            }
            myStr = null;
            return true;
        }

        /// <summary>
        /// Checks if a string is a valid E-Mail or not.
        /// </summary>
        /// <param name="strEmail">The E-mail to be checked.</param>
        /// <returns>Returns true if the E-mail is valid otherwise it returns false.</returns>
        public static bool IsInvalidEmail(string strEmail)
        {

            if (strEmail == null || strEmail.Length == 0 || !strEmail.Contains("@") || strEmail.IndexOf("@") < 2)
                return true;
            string[] eAddress = strEmail.Split('@')[1].Split('.');
            if (eAddress.Length < 2)
                return true;
            try
            {
                System.Net.Mail.MailAddress mladdrssCheckMail = new System.Net.Mail.MailAddress(strEmail);
                return mladdrssCheckMail.Address != strEmail;
            }
            catch
            {
                return false;
            }
        }
        // password encryption ......................................................................
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }



        #endregion

    }
}