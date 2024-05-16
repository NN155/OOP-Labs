using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Task02
{
    class Program
    {
        static void Main()
        {
            void printMatrix(int[,] matrix)
            {
                string printElement;
                int maxLen = 1;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        printElement = Convert.ToString(matrix[i, j]);
                        if (printElement.Length > maxLen)
                        {
                            maxLen = printElement.Length + 1;
                        }
                    }
                }
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        printElement = Convert.ToString(matrix[i, j]);
                        printElement = printElement.PadRight(maxLen + 1);
                        Console.Write(printElement);
                    }
                    Console.WriteLine();
                }
            }
            int sumMatrixColomn(int[,] matrix)
            {
                int sum = 0;
                int sumColumn = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, j] >= 0)
                        {
                            sumColumn += matrix[i, j];
                        }
                        else 
                        {
                            sumColumn = 0;
                            break;
                        }
                    }
                    sum += sumColumn;
                    sumColumn = 0;
                }
                return sum;
            }
            int sumMatrixDiagonals(int[,] matrix)
            { 
                int sumDiagonal1 = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    
                    sumDiagonal1 += Math.Abs(matrix[i, i]);
                }
                int sumDiagonal2 = 0;
                for (int i = matrix.GetLength(0) - 1; i > 0; i--)
                {
                    sumDiagonal2 += Math.Abs(matrix[i, i]);
                }
                if (sumDiagonal1 > sumDiagonal2)
                    {
                    return sumDiagonal1;
                    }
                return sumDiagonal2;
            }
            int a;
            int b;
            Console.Write("Enter a value - count Matrix rows: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter b value - count Matrix columns: ");
            b = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[a, b];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"Enter Matrix[{i},{j}] value - count Matrix rows: ");
                    matrix[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            printMatrix(matrix);
            Console.Write($"{sumMatrixColomn(matrix)}");
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                Console.WriteLine($"{sumMatrixDiagonals(matrix)} - sum min diagonal");
            }
        }
    }
}