using System;

namespace Test
{
    class TestProgram
    {
        static void Main(string[] args)
        {
            List<int> testList = new List<int>()
            {
                1,2,3,4,5,6,7,8,9
            };

            testList.Insert(3,99 );

            PrintList(testList);

        }

        static void PrintList(List<int> list)
        {
            foreach (var el in list)
            {
                Console.Write(el + " ");
            }
        }
    }
}