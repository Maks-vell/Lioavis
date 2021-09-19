using System;

namespace programm1
{
    static class  Program
    {
        private static void Main(string[] args)
        {
            
            Console.WriteLine("Two-dimensional or one-dimensional array (1/2): ");
            int dimension= int.Parse(Console.ReadLine() ?? string.Empty);

            if (dimension == 2)
            {
                Console.Write("Enter the number of string in array: "); //ввод
                int x = int.Parse(Console.ReadLine() ?? string.Empty);
                Console.Write("Enter the number of columm in array: ");
                int y = int.Parse(Console.ReadLine() ?? string.Empty);
                int[,] arr = new int[x, y];
                Random rnd = new Random();

                for (int i = 0; i < x; i++) // вывод
                {
                    for (int j = 0; j < y; j++)
                    {
                        arr[i,j] = rnd.Next(10);
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
            else
            {
                Console.Write("Enter the size of array: ");
                int size = int.Parse(Console.ReadLine() ?? string.Empty);
                int[] arr = new int[size];
                Random rnd = new Random();

                for (int i = 0; i < size; i++) //заполнение 
                {
                    arr[i] = rnd.Next(10);
                }

                for (int i = 0; i < size; i++) //вывод
                {
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();
                
                int max = arr[0]; //подсчет max min
                int min = arr[0];
                foreach (int element in arr)
                {
                    if (element > max) max = element;
                    if (element < min) min = element;
                }
                
                Console.WriteLine("Min - Max: {0} ", max - min);
            }
        }
    }
}