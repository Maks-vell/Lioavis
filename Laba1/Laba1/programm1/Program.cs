using System;

namespace programm1
{
    static class Program
    {
        private static void Main(string[] args)
        {
            Arr1();

            Arr2();
            
        }

        private static void Arr1()
        {
            Console.WriteLine("Enter the size of array: ");
            int size = int.Parse(Console.ReadLine() ?? string.Empty);
            int[] arr = new int[size];
            Random rnd = new Random();

            for (int i = 0; i < size; i++) //заполнение 
            {
                arr[i] = rnd.Next(10);
            }

            for (int i = 0; i < size; i++) //вывод
            {
                Console.WriteLine(arr[i]);
            }

            int max = arr[0]; //подсчет max min
            int min = arr[0];
            foreach (int element in arr)
            {
                if (element > max) max = element;
                if (element < min) min = element;
            }

            Console.WriteLine(max - min);
        }

        private static void Arr2()
        {
            Console.WriteLine("Enter the number of string in array: "); //ввод
            int x = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("Enter the number of columm in array: ");
            int y = int.Parse(Console.ReadLine() ?? string.Empty);
            int[,] arr = new int[x, y];
            Random rnd = new Random();

            for (int i = 0; i < x; i++) //заполнение
            {
                for (int j = 0; j < y; j++)
                {
                    arr[i, j] = rnd.Next(10);
                }
            }

            for (int i = 0; i < x; i++) // вывод
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }

                Console.WriteLine(" ");
            }

            int sum = 0;
            Console.WriteLine("sums: "); //подсчет и вывод сумм
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    sum += arr[i, j];
                }

                Console.WriteLine(sum);
                sum = 0;
            }
            
        }
    }
}