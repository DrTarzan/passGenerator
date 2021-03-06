using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        if (args != null && args.Length > 0)
        {
            if (args[0] == "?" || args[0] == "-?" || args[0] == "/?" || args[0] == "help")
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Usage:");
                System.Console.WriteLine("\t> passgen ");
                System.Console.WriteLine("\t> passgen -[lowerCaseCount] -[upperCaseCount] -[digitCount] -[strangeCharsCount]");
                System.Console.WriteLine();
                System.Console.WriteLine("Examples:");
                System.Console.WriteLine("\t> passgen \t ...Gives one random standard Password thats been copied to clipboard");
                System.Console.WriteLine("\t> passgen -2 -2 -2 -2 \t ...Gives an random Password with a total of 8 chars thats been copied to clipboard.");
                System.Console.WriteLine("\t> passgen -4 -4 -4 -4 \t ...Gives an random Password with a total of 16 chars and so on also copied to clipboard.");
            }
            else
            {
                try
                {
                    int arg0 = Convert.ToInt32(args[0].TrimStart('/').TrimStart('-'));
                    int arg1 = Convert.ToInt32(args[1].TrimStart('/').TrimStart('-'));
                    int arg2 = Convert.ToInt32(args[2].TrimStart('/').TrimStart('-'));
                    int arg3 = Convert.ToInt32(args[3].TrimStart('/').TrimStart('-'));
                    DoPrint(arg0, arg1, arg2, arg3, false);
                }
                catch
                {
                    DoPrint(0, 0, 0, 0, true);
                }
            }
        }
        else
        {
            //Return standard password with 8 chars and two of each type
            DoPrint(2, 2, 2, 2, false);
        }
    }

    static void DoPrint(int lowerCase, int upperCase, int digit, int strangeChars, bool error)
    {
        if (error)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Error");
            System.Console.WriteLine("====================================");
            System.Console.WriteLine("An error occured, please try again!");
        }
        else
        {
            System.Console.WriteLine();
            System.Console.WriteLine("New Password");
            System.Console.WriteLine("====================================");
            string pass = GenerateRandomPassword(lowerCase, upperCase, digit, strangeChars);
            System.Console.WriteLine(string.Format("Length: {0}", pass.Length));
            System.Console.WriteLine(string.Format("Password: {0} (Copied to clipboard)", pass));
            Clipboard.SetText(pass);
        }
    }

    private static string GenerateRandomPassword(int lowerCaseCount, int upperCaseCount, int digitCount, int strangeCharsCount)
    {
        // Letters and numbers to choose from
        string lowerChars = "abcdefghijkmnopqrstuvwxyz";
        string upperChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
        string digits = "0123456789";
        string strangeChars = "<>-_!#$@%&/()=+?";

        // Randomly choose letters and numbers
        var dictionary = new Dictionary<Guid, char>();
        AddRandomFromString(lowerCaseCount, lowerChars, dictionary);
        AddRandomFromString(upperCaseCount, upperChars, dictionary);
        AddRandomFromString(digitCount, digits, dictionary);
        AddRandomFromString(strangeCharsCount, strangeChars, dictionary);

        // "Unsort" and return as string
        return new string(dictionary.OrderBy(item => item.Key).Select(item => item.Value).ToArray());
    }

    private static void AddRandomFromString(int length, string source, Dictionary<Guid, char> targetDictionary)
    {
        Random rd = new Random();
        for (int i = 0; i < length; i++)
        {
            targetDictionary.Add(Guid.NewGuid(), source[rd.Next(0, source.Length)]);
            System.Threading.Thread.Sleep(1); // Improves randomness of generated Guids
        }
    }
}
