using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Task01
{
    class Program
    {
        static void Main()
        {
            int max(int[] array) 
            {
                int maxNumber = Int32.MinValue;
                foreach (var i in array)
                {
                    if (i > maxNumber)
                    {
                        maxNumber = i;
                    }           
                }
                return maxNumber;
            }
            int sum(int[] array) 
            {
                int sumCount = 0;
                int lastIndex = 0;
                for (int i = 0; i < array.Length; i ++)
                {
                    if (array[i] > 0)
                    {
                        lastIndex = i;
                    }
                }
                ArraySegment<int> newArray = new ArraySegment<int>(array,0, lastIndex);
                foreach (var i in newArray) 
                {

                    sumCount += i;
                }
                return sumCount;
            }
            //Просим ввести значення n - розмір масиву;
            Console.Write("Enter n value: ");
            int n = Convert.ToInt32(Console.ReadLine());

            //Створюєм та заповнюєм масив
            int[] array = new int[n];
            int arrayValue;
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter a{i} value: ");
                arrayValue = Convert.ToInt32(Console.ReadLine());
                array[i] = arrayValue;
            }
            Console.WriteLine($"max array = {max(array)}");
            Console.WriteLine($"sum array = {sum(array)}");
            //Просим ввести значення a;
            Console.Write("Enter a value: ");
            int a = Convert.ToInt32(Console.ReadLine());
            //Просим ввести значення b;
            Console.Write("Enter b value: ");
            int b = Convert.ToInt32(Console.ReadLine());
            int index = 0;
            Queue<int> indexQueue = new Queue<int>();
            foreach (int i in array)
            {
                if (!(Math.Abs(i) >= a && Math.Abs(i) <= b))
                {
                    indexQueue.Enqueue(index);
                }
                index++;
            }
            int indexQueueCount = indexQueue.Count;
            int[] needArray = new int[n];
            for (int i = 0; i < n; i++) 
            {
                if (i < indexQueueCount)
                {
                    needArray[i] = array[indexQueue.Dequeue()];
                }
                else
                {
                    needArray[i] = 0;
                }
            }
            foreach (int i in needArray)
            {
                Console.Write($"{i} ");
            }
        }
    }
}