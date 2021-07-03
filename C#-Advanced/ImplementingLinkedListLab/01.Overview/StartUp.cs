using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomLinkedList myList = new CustomLinkedList(new int[] { 5,7,12});

            myList.AddFirst(100);
            Console.WriteLine($"Removed last: {myList.RemoveLast()}");

            myList.AddLast(2);
            Console.WriteLine($"Removed first: {myList.RemoveFirst()}");

            int[] arr = myList.toArray();
            myList.Foreach(Console.WriteLine);
        }
    }
}
