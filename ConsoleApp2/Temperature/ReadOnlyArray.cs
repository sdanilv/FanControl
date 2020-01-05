using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp2.Temperature
{
    public class ReadOnlyArray<T> : IReadOnlyArray<T>
    {

        private readonly T[] array;

        public ReadOnlyArray(T[] array)
        {
            this.array = array;
        }

        public T this[int index]
        {
            get { return array[index]; }
        }

        public int Length { get { return array.Length; } }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
        }

        public static implicit operator ReadOnlyArray<T>(T[] array)
        {
            return new ReadOnlyArray<T>(array);
        }

        public T[] ToArray()
        {
            return (T[])array.Clone();
        }
    }
}
