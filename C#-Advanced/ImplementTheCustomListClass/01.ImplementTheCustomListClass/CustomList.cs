using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ImplementTheCustomListClass
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }
        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentException();
                }
                return items[index];
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentException();
                }
                items[index] = value;
            }
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];
            for (int i = 0; i < copy.Length; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        public void AddMember(int item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
                this.items[this.Count] = item;
                this.Count++;
            }
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }

        public int RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentException();
            }
            var item = this.items[index];
            this.items[index] = default(int);
            this.Shift(index);

            this.Count--;
            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }
            return item;
        }

        private void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        public void Insert(int index, int element)
        {
            if (index > this.Count)
            {
                throw new IndexOutOfRangeException();
            }
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftToRight(index);
            this.items[index] = element;
            this.Count++;
        }
        public bool Cointains(int element)
        {
            bool isFound = false;
            for (int i = 0; i < this.Count; i++)
            {
                if (items[i] == element)
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex >= 0 && firstIndex > this.Count 
                && secondIndex >= 0 && secondIndex > this.Count)
            {
                int firstIndexToSave = this.items[firstIndex];
                items[firstIndex] = secondIndex;
                items[secondIndex] = firstIndexToSave;
            }
        }
        public void Clear()
        {
            this.Count = 0;
            this.items = new int[InitialCapacity];
        }
    }
}
