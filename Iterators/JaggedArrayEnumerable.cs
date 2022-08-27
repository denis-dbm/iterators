namespace Iterators;

public readonly ref struct JaggedArrayEnumerable<T> //: IEnumerable<T>
{
    readonly T[][] _array;

    public JaggedArrayEnumerable(T[][] array)
    {
        _array = array ?? throw new ArgumentNullException(nameof(array));
    }

    public long CountElements() => _array != null ? _array.CountElements() : 0;

    public Enumerator GetEnumerator() => new Enumerator(_array);

    public ref struct Enumerator //: IEnumerator<T>
    {
        readonly T[][] _array;
        T[]? _inner = null;
        long _index = 0;
        long _innerIndex = 0;

        internal Enumerator(T[][] array)
        {
            _array = array;
        }

        public ref readonly T Current
        {
            get
            {
                if (_inner is not null && _innerIndex < _inner.LongLength)
                    return ref _inner[_innerIndex];
                
                throw new InvalidOperationException();
            }
        }

        public bool MoveNext()
        {
            if (_inner is null || _innerIndex == _inner.LongLength - 1)
            {
                if (_array == null || _index == _array.LongLength)
                    return false;

                _inner = _array[_index++];
                _innerIndex = 0;
            }
            else
            {
                _innerIndex++;
            }

            return true;
        }

        public void Reset()
        {
            _index = 0;
            _inner = null;
        }
    }
}