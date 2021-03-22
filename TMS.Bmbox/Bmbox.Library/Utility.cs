using System;
using System.Collections.Generic;
using System.Text;

namespace Bmbox.Library
{
  public static class Utility
  {
    //public static string GetIPAddress()
    //{
    //  System.Web.HttpContext context = System.Web.HttpContext.Current;
    //  string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

    //  if (!string.IsNullOrEmpty(ipAddress))
    //  {
    //    string[] addresses = ipAddress.Split(',');
    //    if (addresses.Length != 0)
    //    {
    //      return addresses[0];
    //    }
    //  }

    //  return context.Request.ServerVariables["REMOTE_ADDR"];
    //}

    public static string ConvertTurkishChars(string text)
    {
        String[] olds = { "Ğ", "ğ", "Ü", "ü", "Ş", "ş", "İ", "ı", "Ö", "ö", "Ç", "ç" };
        String[] news = { "G", "g", "U", "u", "S", "s", "I", "i", "O", "o", "C", "c" };

        for (int i = 0; i < olds.Length; i++)
        {
            text = text.Replace(olds[i], news[i]);
        }

        text = text.ToUpper();

        return text;
    }
  }
}
