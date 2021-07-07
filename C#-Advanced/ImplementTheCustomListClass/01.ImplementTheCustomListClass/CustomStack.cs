﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ImplementTheCustomListClass
{
    public class CustomStack
    {
        private int[] data;
        private const int INITIAL_CAPACITY = 4;
        public int Count { get; private set; }
        public CustomStack()
        {
            this.Count = 0;
            this.data = new int[INITIAL_CAPACITY];
        }

        public void Push(int number)
        {
            CheckIfResizeIsNeeded();

            this.data[this.Count] = number;
            this.Count++;
        }
        private void Resize()
        {
            var newSize = new int[this.data.Length * 2];
            for (int i = 0; i < this.data.Length; i++)
            {
                newSize[i] = data[i];
            }
            this.data = newSize;
        }
        private void CheckIfResizeIsNeeded()
        {
            if (this.Count == this.data.Length)
            {
                Resize();
            }
        }
        public int Pop()
        {
            CheckIsValid();
            var number = this.data[this.Count - 1];
            this.data[this.Count - 1] = default(int);
            this.Count--;
            return number;
        }
        public int Peek()
        {
            CheckIsValid();
            var number = this.data[this.Count - 1];
            return number;
        }
        public void Clear()
        {
            this.Count = 0;
            this.data = new int[INITIAL_CAPACITY];
        }
        public void ForEach(Action<int> action)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                action(this.data[i]);
            }
        }
        private void CheckIsValid()
        {
            if (this.data.Length == 0)
            {
                throw new ArgumentException("Stack is empty");
            }
        }
    }
}
