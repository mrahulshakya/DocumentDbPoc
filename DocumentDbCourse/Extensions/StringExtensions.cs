using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;

namespace DocumentDbCourse.Extensions
{
    public static class StringExtensions
    {
        public static SecureString ToSecureString(this string _self)
        {
            SecureString knox = new SecureString();
            char[] chars = _self.ToCharArray();
            foreach (char c in chars)
            {
                knox.AppendChar(c);
            }
            return knox;
        }
    }
}