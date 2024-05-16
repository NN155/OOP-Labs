using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Просим ввести значення s;
            Console.Write("Enter s value:");
            double s = Convert.ToDouble(Console.ReadLine());

            //Просим ввести значення t;
            Console.Write("Enter t value:");
            double t = Convert.ToDouble(Console.ReadLine());

            //Створюєм масив для зберігання значень від а0 до а12;
            double[] myArray = new double[13];
            for (int i = 0; i < 13; i++)
            {
                //Заповнюєм масив;
                Console.Write($"Enter a{i} value: ");
                myArray[i] = Convert.ToDouble(Console.ReadLine());
            }
            //Створюєм екземпляр класу myClass
            myClass Solve = new myClass(myArray);

            //Рішаєм рівняння p(1) - p(t) + p^2(s-t) - p^3(1)
            double result = Solve.P(1) - Solve.P(t) + Math.Pow(Solve.P(s - t), 2) - Math.Pow(Solve.P(1), 3);
            Console.WriteLine(result);
        }
        //Створюєм класс з методом "P" та конструктором, тільки для того щоб кожен раз не передавати масив myArray {a0, a1, .. , a12} в метод "P"
        class myClass {

            private double[] myArray;
            //Конструктор класу, приймає масив
            public myClass(double[] a)
            {
                myArray = a;
            }
            //Метод P - виконує функцію p(x) = a12 * x^12 + a11 * x^11 + .. + a0 
            public double P(double x)
            {
                double sum = 0;
                for (int i = 0; i < myArray.Length; i++) 
                {
                    sum += Math.Pow(x, i) * myArray[i];
                }
                return sum;
            }
        }
    }
}
