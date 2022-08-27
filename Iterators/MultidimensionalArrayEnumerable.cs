using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Iterators;

public readonly ref partial struct MultidimensionalArrayEnumerable<T> //: IEnumerable<T>
{
    readonly Array _array;

    MultidimensionalArrayEnumerable(Array array)
    {
        _array = array;
    }

    public static MultidimensionalArrayEnumerable<T> FromArray(Array array)
    {
        if (array.GetType().GetElementType() != typeof(T))
            throw new ArgumentException("", nameof(array));
        
        return new MultidimensionalArrayEnumerable<T>(array);
    }

    public Enumerator GetEnumerator() => new Enumerator(_array);
    
    public ref struct Enumerator //: IEnumerator<T>
    {
        readonly Array _array;
        long _index = -1;

        internal Enumerator(Array array)
        {
            _array = array;
        }

        public ref readonly T Current
        {
            get
            {
                if (_index > -1 && _index < _array.LongLength)
                    return ref ReadCurrent();

                throw new InvalidOperationException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        ref readonly T ReadCurrent()
        {
            var pinned = GCHandle.Alloc(_array, GCHandleType.Pinned);
                    
            try
            {
                unsafe
                {
                    void* p = Unsafe.AsPointer(ref MemoryMarshal.GetArrayDataReference(_array));
                    return ref Unsafe.AsRef(Unsafe.Add(ref Unsafe.AsRef<T>(p), new IntPtr(_index)));
                }
            }
            finally
            {
                pinned.Free();
            }
        }

        public bool MoveNext()
        {
            if (_index >= _array.Length - 1)
                return false;

            _index++;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}