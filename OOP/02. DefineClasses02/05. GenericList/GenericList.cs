// 5. Write a generic class GenericList<T> that keeps a list of elements
//    of some parametric type T. Keep the elements of the list in an array
//    with fixed capacity which is given as parameter in the class constructor.
//    Implement methods for adding element, accessing element by index,
//    removing element by index, inserting element at given position, clearing
//    the list, finding element by its value and ToString(). Check all input
//    parameters to avoid accessing elements at invalid positions.
//
// 6. Implement auto-grow functionality: when the internal array is full,
//    create a new array of double size and move all elements to it.
//
// 7. Create generic methods Min<T>() and Max<T>() for finding the minimal
//    and maximal element in the  GenericList<T>. You may need to add a
//    generic constraints for the type T.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GenericList
{
    public class GenericList<T> where T : IComparable
    {
        private T[] list;       // Holds the list of elements T
        private int index;      // Index of max element in the list

        public GenericList(int size)
        {
            this.list = new T[size];
            this.index = 0;
        }

        // Create a new list with double of previeus size and copy the old one into the new
        private void DoubleSizeMySelf()
        {
            var newDoubleSizeList = new T[this.Capacity + this.Capacity];
            Array.Copy(this.list, newDoubleSizeList, this.Capacity);
            this.list = newDoubleSizeList;
        }

        // Returns the current capacity of the GenericList
        public int Capacity { get { return this.list.Length; } }

        // Returns the count of elements in the list
        public int Length { get { return this.index; } }

        // Create an indexer
        public T this[int indexer]
        {
            get
            {
                if (indexer < 0 || indexer >= this.index)
                {
                    throw new IndexOutOfRangeException(string.Format("Index must be between [0..{0}]", this.Length - 1));
                }

                return this.list[indexer];
            }

            set
            {
                if (indexer < 0 || indexer >= this.index)
                {
                    throw new IndexOutOfRangeException(string.Format("Index must be between [0..{0}]", this.Length - 1));
                }

                this.list[indexer] = value;
            }
        }

        // Add element if list is big enought, else double the size of internal list
        public void Add(T element)
        {
            if (this.index == this.Capacity)
            {
                this.DoubleSizeMySelf();
            }

            this.list[this.index++] = element;
        }

        // Clear the GenericList
        public void Clear()
        {
            if (this.index > 0)
            {
                Array.Clear(this.list, 0, this.index);
                this.index = 0;
            }
        }

        // Return a zero-based index of the first occurrence of an item if exist or -1
        public int IndexOf(T item)
        {
            return Array.IndexOf<T>(this.list, item, 0, this.index);
        }

        // Remove an element at given position
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.index)
            {
                throw new IndexOutOfRangeException(string.Format("Index must be between [0..{0}]", this.Length - 1));
            }

            // Decrease current element index
            this.index--;

            if (index < this.index)
            {
                // Copy the rest of elements if existe
                Array.Copy(this.list, index + 1, this.list, index, this.index - index);
            }

            // Set last element with default T value
            this.list[this.index] = default(T);
        }

        // Insert element at given position
        public void Insert(int index, T item)
        {
            if (index < 0 || index > this.index)
            {
                throw new IndexOutOfRangeException(string.Format("Index must be between [0..{0}]", this.Length - 1));
            }

            if (this.index == this.Capacity)
            {
                this.DoubleSizeMySelf();
            }

            if (index < this.index)
            {
                Array.Copy(this.list, index, this.list, index + 1, this.index - index);
            }

            this.list[index] = item;
            this.index++;
        }

        // Return min element of the GenericList
        public T Min()
        {
            bool isFirstRepeat = true;
            T min = default(T);

            for (int i = 0; i < this.index; i++)
            {
                if (isFirstRepeat)
                {
                    min = this.list[i];
                    isFirstRepeat = false;
                    continue;
                }

                if (min.CompareTo(this.list[i]) > 0)
                {
                    min = this.list[i];
                }

            }
            return min;
        }

        // Return max element of the GenericList
        public T Max()
        {
            bool isFirstRepeat = true;
            T max = default(T);

            for (int i = 0; i < this.index; i++)
            {
                if (isFirstRepeat)
                {
                    max = this.list[i];
                    isFirstRepeat = false;
                    continue;
                }

                if (max.CompareTo(this.list[i]) < 0)
                {
                    max = this.list[i];
                }

            }
            return max;
        }

        // Return the elements to string
        public override string ToString()
        {
            if (this.index > 0)
            {
                StringBuilder sb = new StringBuilder("{ ");
                for (int i = 0; i < this.index; i++)
                {
                    sb.Append(this.list[i]);
                    sb.Append(", ");
                }
                sb.Remove(sb.Length - 2, 2);
                sb.Append(" }");
                return sb.ToString();
            }
            return "{ NULL }";
        }
    }
}