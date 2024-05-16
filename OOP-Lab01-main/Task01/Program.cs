using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Просим ввести значення x;
            Console.Write("Enter x value: ");
            double x = Convert.ToDouble(Console.ReadLine());

            //Просим ввести значення z;
            Console.Write("Enter z value: ");
            double z = Convert.ToDouble(Console.ReadLine());

            //Шукаємо y за формулою(Math.Pow - число до степення, Math.Abs - модуль числа)
            double y = z + (x / Math.Pow(z, 2) - Math.Abs(Math.Pow(x, 2) / z - (Math.Pow(x, 3) / 3)));

            //Виводимо y і задопомогою Math.Round округлюєм до 3 чисел після коми
            Console.Write(Math.Round(y, 3));
        }
    }
}