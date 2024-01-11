using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MorseCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\Users\jonat\Downloads\long.wav");
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer(@"c:\Users\jonat\Downloads\short.wav");
            Console.WriteLine("Input a string to convert to morse:");
            string str = Console.ReadLine();
            string morsified = ToMorse(str);
            char[] arr = morsified.ToCharArray();
            Console.Clear();
            Console.WriteLine("The message: ");
            Console.WriteLine(morsified);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Clear();
                WriteLineWithColoredLetter(morsified, arr, i);
                if (arr[i] == '-')
                {
                    player.PlaySync();
                }
                else if (arr[i] == '.')
                    {
                    player2.PlaySync();
                }
                else if (arr[i] == '/') Thread.Sleep(1000);

            }


        }
        //Thanks for a special lad who made it easier
        private static string ToMorse(string str)
        {
            str = str.ToLower();
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
                .Replace("0", "----- ")
                .Replace(" ", "/ ");

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
    }
}
