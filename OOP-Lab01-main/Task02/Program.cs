using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Просим ввести значення n;
            Console.Write("Enter n value: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int bk;
            int count = 0;

            int[] array = new int[n];


            for (int k = 0; k < n; k++)
            {
                //Просим ввести значення bk;
                Console.Write($"Enter b{k + 1} value: ");
                bk = Convert.ToInt32(Console.ReadLine());

                //Наповнюєм масив
                array[k] = bk;

                //Перевіряєм чи порядковий номер k є парним та перевіряєм чи bk непарне
                if (((k + 1) % 2 == 0) && ((bk % 2) == 1))
                {
                    count++;
                }
            }

            //Виводим результат
            Console.WriteLine($"Count {count}");
        }
    }
}
