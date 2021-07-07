using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomDoublyLinkedList
{
    public class CustomLinkedList<T>
    {
        /// <summary>
        /// Двойно свързан списък
        /// </summary>
        public int Count { get; private set; } = 0;
        /// <summary>
        /// Брой елементи в списъка
        /// </summary>
        public Node<T> Head { get; set; } = null;
        /// <summary>
        /// Първи елемент
        /// </summary>
        public Node<T> Tail { get; set; } = null;
        /// <summary>
        /// Последен елемент
        /// </summary>

        public CustomLinkedList(T value)
        {
            Node<T> newNode = new Node<T>()
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
        public CustomLinkedList(IEnumerable<T> list)
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
                    Node<T> newNode = new Node<T>()
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
        public void AddFirst(T element)
        {
            Node<T> newNode = new Node<T>()
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
         
        public void AddLast(T element)
        {
            Node<T> newNode = new Node<T>()
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

        public T RemoveFirst()
        {
            if (Count > 0)
            {
                T result = Head.Value;

                Node<T> second = Head.Next;
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

        public T RemoveLast()
        {
            if (Count > 0)
            {
                T result = Tail.Value;

                Node<T> previous = Tail.Previews;
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

        public void Foreach(Action<T> action)
        {
            Node<T> currentNode = Head;
            while (currentNode != null)
            {
                action(currentNode.Value);

                currentNode = currentNode.Next;
            }
        }

        public T[] toArray()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("Empty list");
            }
            T[] array = new T[Count];
            int index = 0;
            Node<T> currentNode = Head;

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
