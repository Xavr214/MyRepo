using System;
using System.Linq;
using System.Text;

namespace Examples.ExtensionMethods
{
    public static class StringExtension
    {
        public static int ToInt(this string source)
        {
            int.TryParse(source, out int result);
            return result;
        }

        //with additional parameter
        public static int MyContains(this string source, string target)
        {
            return source.Split(new string[] { target }, StringSplitOptions.None).Length - 1;
        }

        //with params
        public static string Shuffle(this string source, params string[] target)
        {
            var rnd = new Random();
            var sb = new StringBuilder(source);
            foreach (var other in target)
            {
                sb.Append(target);
            }

            var whole = sb.ToString();

            return new string(whole.OrderBy(c => rnd.Next()).ToArray());
        }
    }

    public class ExtensionExample {
        public void M()//usage
        {
            int result = "123".ToInt();

            var myString = "11";
            var result2 = myString.ToInt();

            var result3 = "StringToShuffle".Shuffle();

            var result4 = "StringToShuffle".Shuffle("1234567890");
            var result5 = "StringToShuffle".Shuffle("1234567890","abcdefghijklm");

            int result6 = "CountStrinThisString".MyContains("Str");
        }
    }
}
