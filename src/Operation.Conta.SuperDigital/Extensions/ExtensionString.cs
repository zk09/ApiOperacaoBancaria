using System.Text.RegularExpressions;

namespace OperationAccount.Api.SuperDigital.Extensions
{
    public static class ExtensionString
    {
        public static string OnlyNumbers(this string str)
        {
            var apenasDigitos = new Regex(@"[^\d]");
            var number = apenasDigitos.Replace(str, "");
            return number;
        }
    }
}
