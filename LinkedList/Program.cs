using System;
using System.Collections.Generic;
using CustomListLib;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomList<int> myList = new CustomList<int>(new List<int> { 1, 2, 3, 4, 5 });
            myList.Notify += mes => Console.WriteLine(mes);

            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList[i]+" ");
            }
            Console.WriteLine();

            myList.Add(8);
            Console.WriteLine();

            myList.Remove(8);
            Console.WriteLine();

            myList.Remove(10);
            Console.WriteLine();

            myList.RemoveAt(2);
            Console.WriteLine();

            myList.Insert(3, 150);
            Console.WriteLine();

            myList.IndexOf(150);
            Console.WriteLine();

            myList.Contains(1);
            Console.WriteLine();

            myList.Clear();
            Console.WriteLine();

            Console.WriteLine(myList.Count);
        }
    }
}
