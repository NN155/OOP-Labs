using System;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Task03
{
    class Program
    {
        static void Main()
        {
            void countPunctuationSymbol(string msg, char[] punctuationSymbols) 
            {
                string temp;
                int count;
                int index;
                foreach (var i in punctuationSymbols)
                {
                    temp = msg;
                    count = 0;
                    while(temp.Contains(i))
                    {
                        index = temp.IndexOf(i);
                        temp = temp.Remove(index, 1);
                        count++;
                    }
                    if (count > 0) 
                    {
                        Console.WriteLine($"{count} - count '{i}' in the text.");
                        
                    }
                }
            }
            void printEvenWords(string msg, char[] punctuationSymbols)
            {
                foreach (var i in msg.Split(punctuationSymbols))
                {
                    if (i.Length % 2 == 0)
                    {
                    Console.Write($"{i} ");
                    }
                }
                Console.WriteLine();
            }
   

            void swapFirstAndLastSymbol(string msg, char[] punctuationSymbols)
            {
                string newWord;
                char firstSymbol, lastSymbol;
                foreach (var i in msg.Split(punctuationSymbols))
                {
                    newWord = i;
                    if (newWord.Length > 1)
                    {
                        firstSymbol = newWord[0];
                        lastSymbol = newWord[i.Length - 1];
                        newWord = newWord.Remove(i.Length - 1, 1);
                        newWord = newWord.Remove(0, 1);
                        newWord = lastSymbol + newWord + firstSymbol;
                    }
                    Console.Write($"{newWord} ");
                }
                Console.WriteLine();
            }
            string msg;
            char[] punctuationSymbols1 = new char[] {'.', ',', '!', '?' };
            char[] punctuationSymbols2 = new char[] {' ' ,'.', ',', '!', '?'};
            Console.Write("Enter text: ");
            msg = Console.ReadLine();
            
            countPunctuationSymbol(msg, punctuationSymbols1);
            printEvenWords(msg, punctuationSymbols2);
            swapFirstAndLastSymbol(msg, punctuationSymbols2);
        }
    }
}