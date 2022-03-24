using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EncryptionDecryption
/// </summary>
public static class EncryptionDecryption
{
    public static string Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
    public static string Decode(string encodedText)
    {
        var encodedTextBytes = System.Convert.FromBase64String(encodedText);
        return System.Text.Encoding.UTF8.GetString(encodedTextBytes);
    }
}