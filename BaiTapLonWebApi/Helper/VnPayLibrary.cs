using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

public class VnPayLibrary
{
    private SortedList<string, string> requestData = new();
    private SortedList<string, string> responseData = new();

    // ================== REQUEST ==================
    public void AddRequestData(string key, string value)
    {
        if (!string.IsNullOrEmpty(value))
            requestData.Add(key, value);
    }

    public string CreateRequestUrl(string baseUrl, string vnp_HashSecret)
    {
        var data = new StringBuilder();

        foreach (var kv in requestData)
        {
            data.Append(kv.Key);
            data.Append("=");
            data.Append(WebUtility.UrlEncode(kv.Value));
            data.Append("&");
        }

        string signData = data.ToString().TrimEnd('&');
        string hash = HmacSHA512(vnp_HashSecret, signData);

        return $"{baseUrl}?{signData}&vnp_SecureHash={hash}";
    }

    // ================== RESPONSE ==================
    public void AddResponseData(string key, string value)
    {
        if (!string.IsNullOrEmpty(value))
            responseData.Add(key, value);
    }

    public string GetResponseData(string key)
    {
        return responseData.ContainsKey(key) ? responseData[key] : null;
    }

    public bool ValidateSignature(string inputHash, string secretKey)
    {
        var data = new StringBuilder();

        foreach (var kv in responseData
            .Where(x => x.Key != "vnp_SecureHash" && x.Key != "vnp_SecureHashType")
            .OrderBy(x => x.Key))
        {
            data.Append(kv.Key);
            data.Append("=");
            data.Append(System.Net.WebUtility.UrlEncode(kv.Value));
            data.Append("&");
        }

        string signData = data.ToString().TrimEnd('&');
        string myHash = HmacSHA512(secretKey, signData);

        return myHash.Equals(inputHash, StringComparison.OrdinalIgnoreCase);
    }


    // ================== HASH ==================
    private static string HmacSHA512(string key, string data)
    {
        using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(key));
        return BitConverter.ToString(hmac.ComputeHash(Encoding.UTF8.GetBytes(data)))
            .Replace("-", "")
            .ToLower();
    }
}
