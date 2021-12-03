using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListHW.LinkedList
{
    public class Node
    {
        public int Value { get; set; }
        
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }

    }

    public class LinkedList
    {
        private Node _root;
        private Node _tail;

        public int GetLength()
        {
            Node current = _root;
            int length = 0;

            while (current != null)
            {
                length += 1;
                current = current.Next;
            }

            return length;
        }

        public int this[int index]
        {
            get
            {
                if (index > GetLength() - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                if (index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                if (GetLength() == 0)
                {
                    throw new Exception("массив пуст");
                }
                Node current = _root;
                for (int i = 1; i <= index; i++)//начинаем с 1 потому что нулевой элемент уже внутри cuurent
                {
                    current = current.Next;

                }
                return current.Value;

            }

            set
            {
                if (index > GetLength() - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                if (index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                if (GetLength() == 0)
                {
                    throw new Exception("массив пуст");
                }
                Node current = _root;
                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;

                }
                current.Value = value;
            }
        }

        public LinkedList()
        {
            _root = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            _root = new Node(value);
            _tail = _root;
        }

        public LinkedList(int[] values)
        {
            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }

        public LinkedList Clone ()
        {
            LinkedList linkedList = new LinkedList();
            Node current = _root;
            Node tmp;
            Node newCurrent = linkedList._root;
            int length = GetLength();

            if (length != 0)
            {

                linkedList._root = new Node(current.Value);
                linkedList._tail = linkedList._root;
                for (int i = 1; i < length; i++)
                {
                    current = current.Next;
                    linkedList._tail.Next = new Node(current.Value);
                    linkedList._tail = linkedList._tail.Next;

                }


            }
            else
            {

                linkedList._root = null;
                linkedList._tail = null;
            }

            return linkedList;
        }

        public override string ToString()
        {
            return string.Join(";", ToArray());
        }

        public int[] ToArray()
        {

            int[] array = new int[GetLength()];
            Node current = _root;

            for (int i = 0; i <= array.Length - 1; i++)
            {

                array[i] = current.Value;
                current = current.Next;

            }


            return array;
        }

        public override bool Equals(object obj)
        {
            LinkedList list = (LinkedList)obj;

            if (this.GetLength() != list.GetLength())
            {
                return false;
            }

            Node currentThis = this._root;
            Node currentList = list._root;

            do
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
                currentList = currentList.Next;
                currentThis = currentThis.Next;
            }
            while (!(currentThis.Next is null));

            return true;
        }

        public void AddLast(int value)
        {
            Node current = new Node(value);
        
            if (_root != null)
            {
                _tail.Next = new Node(value);
                _tail = _tail.Next;

            }
            else
            {
                _root = current;
                _tail = _root;
            }
        }

        public void AddFirst(int value)
        {
            Node tmp = _root;
            _root = new Node(value);
            _root.Next = tmp;
        }

        public void AddAt(int value, int index)
        {
            Node current = _root;

            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            Node tmp = new Node(value);
            tmp.Next = current.Next;
            current.Next = tmp;

        }

        public void RemoveLast()
        {
            Node current = _root;

            if (_root == null)
            {
                throw new NullReferenceException();
            }

            if (current.Next == null)
            {
                _root = null;
                _tail = null;
            }
            else
            {
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
            }

            current.Next = null;
        }

        public void RemoveFirst()
        {
            _root = _root.Next;
        }

        public void RemoveAt(int index)
        {
            Node current = _root;

            for (int i = 1; i < index; i++)
            {
                current = current.Next;
            }

            current.Next = current.Next.Next;

        }

        public void RemoveLastMultiple(int n)
        {
            Node current = _root;
            int length = GetLength();

            if (_root == null)
            {
                throw new NullReferenceException();
            }

            for (int i = 1; i < length - 1 - n; i++)
            {
                current = current.Next;
            }

            _tail = current;
        }

        public void RemoveFirstMultiple(int n)
        {
            Node current = _root;

            if (_root == null)
            {
                throw new NullReferenceException();
            }

            for (int i = 0; i < n; i++)
            {
                current = current.Next;
            }

            _root = current;
        }

        public void RemoveAtMultiple(int index, int n)
        {
            Node firstTmp = _root;
            Node endTmp = _root;
            Node tmp = _root;

            if (_root == null)
            {
                throw new NullReferenceException();
            }

            for (int i = 0; i < index + n; i++)
            {
                if (i == index - 1)
                {
                    firstTmp = tmp;
                }
                else if (i == index + n + 1)
                {
                    endTmp = tmp;
                }

                tmp = tmp.Next;

            }

            firstTmp = endTmp;
        }

        public int Get(int index)
        {
            Node current = _root;

            for (int i = 1; i < index - 1; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public int GetFirst()
        {
            if (_root == null)
            {
                throw new NullReferenceException();
            }

            Node current = _root;
            return current.Value;
        }

        public int GetLast()
        {
            if (_root == null)
            {
                throw new NullReferenceException();
            }

            Node current = _tail;
            return current.Value;
        }

        public int IndexOf(int value)
        {
            if (_root == null)
            {
                throw new NullReferenceException();
            }

            int index = -1;
            Node current = _root;

            int length = GetLength();

            for (int i = 0; i < length - 1; i++)
            {
                if (current.Value == value)
                {
                    index = i;
                    break;
                }

                current = current.Next;
            }

            return index;

        }

        public void Set(int index, int value)
        {
            if (_root == null)
            {
                throw new NullReferenceException();
            }

            Node current = _root;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Value = value;
        }

        public void Revers()
        {
            if (_root == null)
            {
                throw new NullReferenceException();
            }

            Node current = _root;
            Node tmp = new Node(1);

            while (current.Next != null)
            {
                tmp = current.Next;
                current.Next = tmp.Next;
                tmp.Next = _root;
                _root = tmp;
            }
        }

        public int Max()
        {
            Node current = _root;
            int maxValue = current.Value;
            int length = GetLength();

            for (int i = 0; i < length; i++)
            {
                if (current.Value > maxValue)
                {
                    maxValue = current.Value;
                }
                current = current.Next;
            }

            return maxValue;
        }

        public int Min()
        {
            Node current = _root;
            int minValue = current.Value;
            int length = GetLength();

            for (int i = 1; i < length; i++)
            {
                if (current.Value < minValue)
                {
                    minValue = current.Value;
                }
                current = current.Next;
            }

            return minValue;
        }

        public int IndexOfMax()
        {
            Node current = _root;
            int maxValue = current.Value;
            int index = 0;
            int length = GetLength();

            for (int i = 0; i < length; i++)
            {
                if (current.Value > maxValue)
                {
                    maxValue = current.Value;
                    index = i;
                }
                current = current.Next;
            }

            return index;
        }

        public int IndexOfMin()
        {
            Node current = _root;
            int minValue = current.Value;
            int index = 0;
            int length = GetLength();

            for (int i = 1; i < length; i++)
            {
                if (current.Value < minValue)
                {
                    minValue = current.Value;
                    index = i;
                }
                current = current.Next;
            }

            return index;
        }

        public void Sort()
        {
            Node tmp = _root;
            Node current = _root;
            int length = GetLength();


            for (int i = 0; i < length; i++)
            {
                for (int j = i; j < length; j++)
                {
                    if (current.Next.Value > current.Value)
                    {
                        tmp = current.Next;
                        current.Next = current;
                        current = tmp;
                    }
                }
            }

        }

        public void SortDesc()
        {
            Node current = _root;
            LinkedList sorted = new LinkedList();
            Node nxt = null;

            while (current != null)
            {
                nxt = current.Next;
                sorted = InsertionDesc(sorted, current);
                current = nxt;
            }

            _root = sorted._root;
        }
        public LinkedList InsertionDesc(LinkedList sorted, Node node)
        {
            if (sorted._root == null || sorted._root.Value <= node.Value)
            {
                node.Next = sorted._root;
                sorted._root = node;

            }
            else
            {
                Node current = sorted._root;
                while (current.Next != null && current.Next.Value > node.Value)
                {
                    current = current.Next;
                }
                node.Next = current.Next;
                current.Next = node;
            }
            return sorted;
        }

        public int RemoveFirst(int value)
        {
            Node current = _root;
            Node firstTmp = current;
            Node secondTmp = current;
            int index = -1;
            int length = GetLength();

            for (int i = 0; i < length; i++)
            {
                if (current.Value == value)
                {
                    firstTmp = current;
                    secondTmp = current.Next;
                    index = i;
                    break;
                }
                current = current.Next;

            }

            firstTmp = secondTmp;

            return index;
        }

        public int RemoveAll(int value)
        {
            Node current = _root;
            Node firstTmp = current;
            Node secondTmp = current;
            int length = GetLength();
            int kol = 0;

            for (int i = 0; i < length; i++)
            {
                if (current.Value == value)
                {
                    firstTmp = current;
                    secondTmp = current.Next;

                    kol++;

                    firstTmp = secondTmp;
                }
                current = current.Next;

            }
            return kol;
        }

        public void AddLast(LinkedList listOne)
        {
            Node current = _root;
            int Length = GetLength();
            if (Length == 0)
            {
                _root = listOne._root;
                _tail = listOne._tail;
            }
            _tail.Next = listOne._root;
            _tail = listOne._tail;
        }

        public void AddFirst(LinkedList list)
        {

            LinkedList cloneList = list.Clone();
            Node current = cloneList._root;
            int length = cloneList.GetLength();
            
            if (length == 0)
            {
                return;
            }

            cloneList._tail.Next = _root;
            _root = cloneList._root;
        }

        public void AddAt(int idx, LinkedList list)
        {
            Node current = _root;
            if (idx == 0)
            {
                list._tail.Next = _root;
                _root = list._root;
            }
            else
            {
                if (_root == null)
                {
                    throw new IndexOutOfRangeException();
                }


                for (int i = 0; i < idx - 1; i++)
                {
                    current = current.Next;

                }
                list._tail.Next = current.Next;
                current.Next = list._root;
            }
        }

        public bool Contains(int val)
        {
            Node current = _root;
            int length = GetLength();

            if (_root == null)
            {
                return false;
            }
            while (current.Next != null)
            {
                if (current.Value == val)
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }
    }
}
