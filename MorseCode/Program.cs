
using System;
using System.Collections.Generic;
using System.Threading;

namespace MorseCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\Users\jonat\source\repos\MorseCode\MorseCode\Sounds\long.wav");
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer(@"c:\Users\jonat\source\repos\MorseCode\MorseCode\Sounds\short.wav");
            Console.WriteLine("Morse or Binary? (M for text -> morse, " +
                "\nB for text -> binary, " +
                "\nT for binary -> text, " +
                "\nK for text -> binary -> morse, " +
                "\nC for binary -> text -> morse)");
            Console.WriteLine("Morse or Binary? (M for morse and B for binary or K for both)");
            char choice = char.Parse(Console.ReadLine());
            if (choice == 'M')
            {
                Console.WriteLine("Input a string to convert to morse:");
                string str = Console.ReadLine();
                string morsified = ToMorse(str);
                MorseReader(morsified, str, player, player2, false);
            }
            else if (choice == 'B')
            {
                Console.WriteLine("Input string to binary:");
                string str = ToBinary(Console.ReadLine());
                Console.WriteLine(str);
            }
            else if (choice == 'T')
            {
                Console.WriteLine("Input binary to string:");
                string str = ToString(Console.ReadLine());
                Console.WriteLine(str);
            }
            else if (choice == 'K')
            {
                Console.WriteLine("Input a string to binary and then to morse:");
                string str = Console.ReadLine();
                string binariedMorsified = ToMorse(ToBinary(str));
                MorseReader(binariedMorsified, str, player, player2, true);
            }
            else if (choice == 'C')
            {
                Console.WriteLine("Input a binary string to text and then to morse:");
                string str = Console.ReadLine();
                string textified = ToString(str);
                string textifiedMorse = ToMorse(textified);
                MorseReader(textifiedMorse, textified, player, player2, false);
            }
        }
               
        //Thanks to a special lad who made it easier 😉
        private static string ToMorse(string str)
        {
            str = str.ToLower().Replace(" ", "/ ")
                .Replace(".", ".-.-.- ")
                .Replace("?", "..--.. ")
                .Replace(",", "--..-- ")
                .Replace("!", "-.-.-- ");
            return str.Replace("a", ".- ")
                .Replace("b", "-... ")
                .Replace("c", "-.-. ")
                .Replace("d", "-.. ")
                .Replace("e", ". ")
                .Replace("f", "..-. ")
                .Replace("g", "--. ")
                .Replace("h", ".... ")
                .Replace("i", ".. ")
                .Replace("j", ".--- ")
                .Replace("k", "-.- ")
                .Replace("l", ".-.. ")
                .Replace("m", "-- ")
                .Replace("n", "-. ")
                .Replace("o", "--- ")
                .Replace("p", ".--. ")
                .Replace("q", "--.- ")
                .Replace("r", ".-. ")
                .Replace("s", "... ")
                .Replace("t", "- ")
                .Replace("u", "..- ")
                .Replace("v", "...- ")
                .Replace("w", ".-- ")
                .Replace("x", "-..- ")
                .Replace("y", "-.-- ")
                .Replace("z", "--.. ")
                .Replace("1", ".---- ")
                .Replace("2", "..--- ")
                .Replace("3", "...-- ")
                .Replace("4", "....- ")
                .Replace("5", "..... ")
                .Replace("6", "-.... ")
                .Replace("7", "--... ")
                .Replace("8", "---.. ")
                .Replace("9", "----. ")
                .Replace("0", "----- ");
        }
       
        private static string ToBinary(string str)
        {
            char[] chars = str.ToCharArray();
            int j = 0, remainder, count=0;
            string newStr = "", tempStr = "";
            char intToChar;
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < chars.Length; i++)
            {
                j = chars[i];
                while (j != 0)
                {
                    remainder = j % 2;
                    intToChar = (char)(remainder + '0');
                    stack.Push(intToChar);
                    count++;
                    j /= 2;   
                }
                while (tempStr.Length <= count)
                {
                    if (stack.Count == 0) break;
                    tempStr += stack.Pop();
                }
                newStr += "0" + tempStr;
                if (i < chars.Length - 1) newStr += " ";
                tempStr = "";
            }
            return newStr;
        }
        private static string ToString(string binary)
        {
            //Doubling method
            int asciiVal = 0;
            char[] arr = binary.ToCharArray();
            string str = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == ' ')
                {
                    str += (char)asciiVal;
                    asciiVal = 0;
                } 
                else if (i == arr.Length-1)
                {
                    asciiVal = asciiVal * 2 + (arr[i] - '0');
                    str += (char)asciiVal;
                }
                else
                asciiVal = asciiVal * 2 + (arr[i]-'0');
            }
            return str;

        }
        private static void ShowCharacter(string str, int i)
        {
            char[] arr = str.ToCharArray();
            Console.Write(str.Substring(0, i));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(arr[i]);
            Console.ResetColor();
            Console.Write(str.Substring(i + 1));
            Console.WriteLine();

        }
        //https://stackoverflow.com/questions/11150332/how-to-change-foreground-color-of-each-letter-in-a-string-in-c-sharp-console
        private static void WriteLineWithColoredLetter(string morsified,char[] arr, int i)
        {
            Console.Write(morsified.Substring(0, i));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(arr[i]);
            Console.ResetColor();
            Console.WriteLine(morsified.Substring(i + 1));
        }
        private static void MorseReader(string morsified, string str, System.Media.SoundPlayer player, System.Media.SoundPlayer player2, bool isBinarified)
        {
            char[] arr = morsified.ToCharArray();
            string binary = "";
            int count = 0, binaryCount = 0;

            Console.Clear();
            Console.WriteLine("The message: ");
            Console.WriteLine(morsified);
            if (isBinarified)
            {
                Console.WriteLine("Message in Binary:");
                binary = ToBinary(str);
                Console.WriteLine(binary);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Clear();
                Console.WriteLine("Original Message: ");
                if (!isBinarified) ShowCharacter(str, count);
                else ShowCharacter(str, binaryCount);
                if (isBinarified) ShowCharacter(binary, count);
                WriteLineWithColoredLetter(morsified, arr, i);
                if (arr[i] == '-')
                {
                    player.PlaySync();
                }
                else if (arr[i] == '.')
                {
                    player2.PlaySync();
                }
                else if (arr[i] == ' ')
                {
                    count++;
                    Thread.Sleep(200);
                }
                else if (arr[i] == '/')
                {
                    if (isBinarified) binaryCount++;
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
