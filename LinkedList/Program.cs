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
            //myList = new CustomList<int>(null);
            myList.ElementAdded += (obj,ev) => Console.WriteLine(ev.Message + " " + ev.Value);
            myList.ElementRemoved += (obj, ev) => Console.WriteLine(ev.Message + " " + ev.Value);
            myList.ListCleared += (obj, ev) => Console.WriteLine(ev.Message + " " + ev.Value);

            List<int> a = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 0, -1, -3, -4, 5, 12, 13, 15, -78, 100 });
            a.Insert(5, 8);

            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList[i]+" ");
            }
            Console.WriteLine();

            myList.Add(8);
            Console.WriteLine();

            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList[i] + " ");
            }
            Console.WriteLine();

            myList.Remove(8);
            Console.WriteLine();

            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList[i] + " ");
            }
            Console.WriteLine();

            myList.Remove(10);
            Console.WriteLine();

            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList[i] + " ");
            }
            Console.WriteLine();

            myList.RemoveAt(2);
            Console.WriteLine();

            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList[i] + " ");
            }
            Console.WriteLine();

            myList.Insert(3, 150);
            Console.WriteLine();

            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList[i] + " ");
            }
            Console.WriteLine();

            myList.IndexOf(150);
            Console.WriteLine();

            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList[i] + " ");
            }
            Console.WriteLine();

            myList.Contains(1);
            Console.WriteLine();

            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList[i] + " ");
            }
            Console.WriteLine();

            myList.Clear();
            Console.WriteLine();

            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine(myList.Count);
        }
    }
}
