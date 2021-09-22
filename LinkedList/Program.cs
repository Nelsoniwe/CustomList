using System;
using System.Collections.Generic;
using CustomListLib;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomList<int> myList = new CustomList<int>(new List<int> { 1, 4, 6, 3, 5 });
            myList.Notify += mes => Console.WriteLine(mes);
            Console.WriteLine("Stack is created.");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }
            
            //myList.Push(0);
            //int FirstElement = myList.Peek();
            //Console.WriteLine($"First element in the stack is: {FirstElement}");
            //int ElementToDelete = myList.Pop();

            //int[] Array = new int[10];
            //myList.CopyTo(Array, 2);

            //int[] Array2 = myList.ToArray();
            //Console.ReadKey();
        }
    }
}
