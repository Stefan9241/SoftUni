using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomDoublyLinkedList
{
    public class CustomLinkedList
    {
        /// <summary>
        /// Двойно свързан списък
        /// </summary>
        public int Count { get; private set; } = 0;
        /// <summary>
        /// Брой елементи в списъка
        /// </summary>
        public Node Head { get; set; } = null;
        /// <summary>
        /// Първи елемент
        /// </summary>
        public Node Tail { get; set; } = null;
        /// <summary>
        /// Последен елемент
        /// </summary>

        public CustomLinkedList(int value)
        {
            Node newNode = new Node()
            {
                Value = value,
                Next = null,
                Previews = null
            };
            Count++;
            Head = newNode;
            Tail = newNode;
        }
        /// <summary>
        /// Създава списък от колекция от елементи
        /// </summary>
        /// <param name="list">Елементи,който да бъдат добавени в списъка</param>
        public CustomLinkedList(IEnumerable<int> list)
            :this(list.First())
        {
            bool isFirst = true;
            foreach (var item in list)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    Node newNode = new Node()
                    {
                        Value = item,
                        Previews = Tail,
                        Next = null
                    };
                    Tail.Next = newNode;
                    Tail = newNode;
                    Count++;
                }
            }
        }
        public void AddFirst(int element)
        {
            Node newNode = new Node()
            {
                Value = element
            };
            if (Count == 0)
            {
                Head = newNode;
                Tail = newNode;

            }
            else
            {
                newNode.Next = Head;
                Head.Previews = newNode;
                Head = newNode;
            }
            Count++;
        }
         
        public void AddLast(int element)
        {
            Node newNode = new Node()
            {
                Value = element
            };
            if (Count == 0)
            {
                Head = newNode;
                Tail = newNode;

            }
            else
            {
                newNode.Previews = Tail;
                Tail.Next = newNode;
                Tail = newNode;
            }
            Count++;
        }

        public int RemoveFirst()
        {
            if (Count > 0)
            {
                int result = Head.Value;

                Node second = Head.Next;
                if (second == null)
                {
                    Tail = null;
                }
                else
                {
                    second.Previews = null;
                }
                
                Head = second;
                Count--;

                return result;
            }

            throw new IndexOutOfRangeException("Empty list");
        }

        public int RemoveLast()
        {
            if (Count > 0)
            {
                int result = Tail.Value;

                Node previous = Tail.Previews;
                if (previous == null)
                {
                    Head = null;
                }
                else
                {
                    previous.Next = null;
                }

                Tail = previous;
                Count--;

                return result;
            }

            throw new IndexOutOfRangeException("Empty list");
        }

        public void Foreach(Action<int> action)
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                action(currentNode.Value);

                currentNode = currentNode.Next;
            }
        }

        public int[] toArray()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("Empty list");
            }
            int[] array = new int[Count];
            int index = 0;
            Node currentNode = Head;

            while (currentNode != null)
            {
                array[index] = currentNode.Value;
                index++;
                currentNode = currentNode.Next;
            }

            return array;
        }
    }
}
