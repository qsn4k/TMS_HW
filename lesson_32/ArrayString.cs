using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_32
{
    class ArrayString : IEnumerable<string>
    {
        private string[] items;
        private int count;

        ArrayString(int capacity = 4)
        {
            if (capacity < 4)
            {
                throw new ArgumentException();
            }

            items = new string[capacity];
            count = 0;
        }

        public void Add(string item)
        {
            if(count >= items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
            items[count++] = item;
        }

        public IEnumerator<string> GetEnumerator()
        {
            for(int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
