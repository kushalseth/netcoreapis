using System;
using System.Web;
using System.IO;
using Newtonsoft.Json.Linq;

namespace encodingresponses
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter a string having '&', '<', '>' or '\"' in it: ");
            string myString = Console.ReadLine();

            var jsonString = @"{""Name<"":""Rick"",""Company"":""West Wind"",
                        ""Entered"":""2012-03-16&00:03:33.245-10:00""}";

            dynamic json = JValue.Parse(jsonString);


            // Encode the string.
            string myEncodedString = HttpUtility.HtmlEncode(json);

        }
    }
}
