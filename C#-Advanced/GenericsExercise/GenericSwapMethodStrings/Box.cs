using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Box<T>
    {
        public List<T> Elements { get; } = new List<T>();
        public Box(List<T> elements)
        {
            Elements = elements;
        }

        public void SwapMethod(int indexOne,int indexTwo)
        {
            T firstElement = Elements[indexOne];
            Elements[indexOne] = Elements[indexTwo];
            Elements[indexTwo] = firstElement;
        }
        public Box(T element)
        {
            Element = element;
        }
        public T Element { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var element in Elements)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }
            return sb.ToString();
        }
    }
}
