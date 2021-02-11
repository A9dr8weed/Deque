using Deque.Model;

using System;

namespace Deque
{
    public static class Program
    {
        private static void Main()
        {
            EasyDeque<int> easyDeque = new EasyDeque<int>();

            easyDeque.PushFront(1);
            easyDeque.PushFront(2);
            easyDeque.PushFront(3);
            easyDeque.PushBack(4);
            easyDeque.PushBack(5);
            easyDeque.PushFront(6);
            easyDeque.PushBack(7);
            Console.WriteLine(easyDeque.Contains(10));

            Console.WriteLine(easyDeque.PopFront());
            Console.WriteLine(easyDeque.PeekFront());
            Console.WriteLine(easyDeque.PopBack());
            Console.WriteLine(easyDeque.PeekBack());

            DoublyLinkedDeque<int> doublyLinkedDeque = new DoublyLinkedDeque<int>();

            doublyLinkedDeque.PushFront(10);
            doublyLinkedDeque.PushFront(20);
            doublyLinkedDeque.PushFront(30);
            doublyLinkedDeque.PushBack(40);
            doublyLinkedDeque.PushBack(50);
            doublyLinkedDeque.PushFront(60);
            doublyLinkedDeque.PushBack(70);
            Console.WriteLine(doublyLinkedDeque.Contains(100)); 

            Console.WriteLine(doublyLinkedDeque.PopFront());
            Console.WriteLine(doublyLinkedDeque.PeekFront());
            Console.WriteLine(doublyLinkedDeque.PopBack());
            Console.WriteLine(doublyLinkedDeque.PeekBack());
        }
    }
}