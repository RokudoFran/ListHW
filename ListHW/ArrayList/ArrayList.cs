using System;

namespace ListHW.ArrayList
{
    public class ArrayList
    {
        // свойство
        public int Length { get; private set; }

        // поле
        private int[] _array;

        private int _minLength = 10;

        // конструктор пустой 
        public ArrayList()
        {
            _array = new int[_minLength];
        }

        // конструктор на основе одного элемента
        public ArrayList(int value)
        {
            _array = new int[_minLength];
            _array[0] = value;
        }

        // конструктор на основе массива
        public ArrayList(int[] array)
        {
            Length = array.Length;
            int length;

            if (array.Length > _minLength)
            {
                length = array.Length;
            }
            else
            {
                length = _minLength;
            }

            int[] array1 = new int[length];
            for (int i = 0; i < Length; i++)
            {

                array1[i] = array[i];
            }
            _array = array1;
        }

        public int this[int index]
        {
            get
            {
                return _array[index];
            }

            set
            {
                _array[index] = value;
            }
        }

        //узнать кол-во элементов в списке
        public int GetLength()
        {
            return Length;
        }

        //вернёт хранимые данные в виде массива
        public int[] ToArray()
        {
            int[] array = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                array[i] = _array[i];
            }
            return array;

        }

        public void AddLast(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }

            _array[Length] = value;

            Length++;
        }

        public void AddFirst(int value)
        {
            AddAt(value, 0);
        }

        public void AddAt(int value, int index)
        {
            ReturnTheErrorIndex(index);

            if (Length == _array.Length)
            {
                UpSize();
            }

            ShiftToRight(index, 1);

            _array[index] = value;

            Length++;
        }

        public void RemoveLast()
        {
            Length--;

            if (Length <= (_array.Length / 2))
            {
                DownSize();
            }
        }

        public void RemoveFirst()
        {
            RemoveAt(0);
        }

        public void RemoveAt(int index)
        {
            ReturnTheErrorIndex(index);

            int n = 1;

            _array = ShiftToLeft(index, n);

            Length--;

            if (Length <= (_array.Length / 2))
            {
                DownSize();
            }
        }

        public void RemoveLastMultiple(int n)
        {

            ReturnTheErrorN(n, 0);

            Length -= n;

            if (Length <= (_array.Length / 2))
            {
                DownSize();
            }
        }

        public void RemoveFirstMultiple(int n)
        {
            RemoveAtMultiple(0, n);
        }

        public void RemoveAtMultiple(int index, int n)
        {
            ReturnTheErrorN(n, index);

            ReturnTheErrorIndex(index);

            for (int i = index; i < Length - n; i++)
            {
                _array[i] = _array[i + n];
            }

            Length -= n;

            if (Length <= (_array.Length / 2))
            {
                DownSize();
            }

        }

        public int Get(int index)
        {
            ReturnTheErrorIndex(index);

            return _array[index];
        }

        public int GetFirst()
        {
            ReturnTheErrorLength(Length);

            int n = _array[0];

            return n;

        }

        public int GetLast()
        {

            ReturnTheErrorLength(Length);
            int n = _array[Length - 1];

            return n;

        }

        public int IndexOf(int value, int usl = -1)
        {
            ReturnTheErrorLength(Length);
            int index = -1;
            int count = 1;

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    index = i;
                    count++;

                    if (usl == 0)
                    {
                        break;
                    }
                    else
                    {
                        RemoveAt(index);
                    }
                }
            }

            if (usl == -1)
            {
                return index;
            }
            else
            {
                return count;
            }
        }

        public void Set(int index, int value)
        {
            ReturnTheErrorLength(Length);
            ReturnTheErrorIndex(index);

            _array[index] = value;

        }

        public void Revers()
        {
            ReturnTheErrorLength(Length);

            int tmp = 0;

            for (int i = 0; i < Length / 2; i++)
            {
                tmp = _array[i];
                _array[i] = _array[Length - i - 1];
                _array[Length - i - 1] = tmp;
            }
        }

        public int Max()
        {
            ReturnTheErrorLength(Length);

            return _array[IndexOfMax()];
        }

        public int Min()
        {
            ReturnTheErrorLength(Length);

            return _array[IndexOfMin()];
        }

        public int IndexOfMax()
        {
            ReturnTheErrorLength(Length);

            int max = _array[0], indexMax = 0;

            for (int i = 0; i < Length; i++)
            {
                if (max <= _array[i])
                {
                    max = _array[i];
                    indexMax = i;
                }
            }

            return indexMax;
        }

        public int IndexOfMin()
        {
            ReturnTheErrorLength(Length);

            int min = _array[0], indexMin = 0;

            for (int i = 1; i < Length; i++)
            {
                if (min > _array[i])
                {
                    min = _array[i];
                    indexMin = i;
                }
            }

            return indexMin;
        }

        public int[] Sort()
        {
            ReturnTheErrorLength(Length);

            int tmp;

            for (int i = 0; i < Length; i++)
            {
                for (int j = Length - 1; j > i; j--)
                {
                    if (_array[j - 1] > _array[j])
                    {
                        tmp = _array[j - 1];
                        _array[j - 1] = _array[j];
                        _array[j] = tmp;
                    }
                }
            }

            return _array;
        }

        public int[] SortDesc()
        {
            ReturnTheErrorLength(Length);

            int tmp;

            for (int i = 0; i < Length - 1; i++)
            {
                int indexOfMax = i;

                for (int j = i; j < Length; j++)
                {
                    if (_array[indexOfMax] < _array[j])
                    {
                        indexOfMax = j;
                    }
                }

                tmp = _array[i];
                _array[i] = _array[indexOfMax];
                _array[indexOfMax] = tmp;
            }

            return _array;
        }

        public int RemoveFirst(int value)
        {
            ReturnTheErrorLength(Length);

            int index = IndexOf(value);

            RemoveAt(index);

            return index;
        }

        public int RemoveAll(int value)
        {
            ReturnTheErrorLength(Length);

            int kol = 0;

            kol = IndexOf(value, 1);


            return kol;
        }

        public void AddLast(ArrayList listOne)
        {
            AddAt(listOne, Length);
        }

        public void AddFirst(ArrayList listOne)
        {
            int index = 0;

            AddAt(listOne, index);
        }

        public void AddAt(ArrayList listOne, int index)
        {
            UpSize(listOne.Length);

            Length += listOne.Length;

            _array = ShiftToRight(index, listOne.Length);

            for (int i = 0; i < listOne.Length; i++)
            {
                _array[i + index] = listOne[i];
            }
        }

        public bool Contains(int val)
        {
            foreach (var item in _array)
            {
                if (item == val)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Join(";", ToArray());
        }

        public override bool Equals(object obj)
        {
            ArrayList other = (ArrayList)obj;

            if (other.Length != Length)
            {
                return false;
            }

            for (int i = 0; i < Length; i++)
            {
                if (other._array[i] != _array[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void UpSize() // увеличение длины массива
        {
            int newLength = (int)(_array.Length * 1.33d + 1);

            int[] tmpArray = new int[newLength];

            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }

        private void UpSize(int Length)
        {
            int newLength = (int)((_array.Length + Length) * 1.33d);

            int[] tmpArray = new int[newLength];

            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }

        private void DownSize() //уменьшение длинны массивы
        {
            int newLength = (int)(_array.Length * 0.67d + 1);

            int[] tmpArray = new int[newLength];

            for (int i = 0; i < tmpArray.Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }

        private int[] ShiftToLeft(int index, int n) // сдвиг влево
        {
            if (Length == _array.Length / 2)
            {
                DownSize();
            }

            for (int i = index; i < Length - n; i++)
            {
                _array[i] = _array[i + n];
            }

            return _array;

        }

        private int[] ShiftToRight(int index, int n) //сдвиг вправо
        {
            if (Length + n < _array.Length)
            {
                UpSize(n);
            }

            for (int i = Length; i > index + n - 1; i--)
            {
                _array[i] = _array[i - n];

            }

            return _array;
        }

        private void ReturnTheErrorIndex(int index)//вызови ошибку
        {
            if (index > Length || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void ReturnTheErrorN(int n, int index)//вызови ошибку
        {
            if (n > Length - index || n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void ReturnTheErrorLength(int Length)
        {
            if (Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

        }
    }
}
