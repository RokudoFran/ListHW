using NUnit.Framework;
using System;
using ListHW.ArrayList;

namespace ListHWTests
{
    public class ArrayListTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(4, new int[] { }, new int[] { 4 })]
        [TestCase(4, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        public void AddLastTest(int value, int[] array, int[] expectedArray)
        {
            //arrange
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);

            //act
            actual.AddLast(value);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, new int[] { }, new int[] { 4 })]
        [TestCase(4, new int[] { 1, 2, 3 }, new int[] { 4, 1, 2, 3 })]
        public void AddFirstTest(int value, int[] array, int[] expectedArray)
        {
            //arrange
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);

            //act
            actual.AddFirst(value);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, 1, new int[] { 1, 2, 3 }, new int[] { 1, 4, 2, 3 })]
        public void AddAtTest(int value, int index, int[] array, int[] expectedArray)
        {
            //arrange
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);

            //act
            actual.AddAt(value, index);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, -2, new int[] { 1, 2, 3 })]
        public void AddAtNegativeTest(int value, int index, int[] array)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act,assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.AddAt(value, index));
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 })]
        public void RemoveLastTest(int[] array, int[] expectedArray)
        {
            //arrange
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);

            //act
            actual.RemoveLast();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4 })]
        public void RemoveFirstTest(int[] array, int[] expectedArray)
        {
            //arrange
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);

            //act
            actual.RemoveFirst();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 4, 1, 2, 3 }, new int[] { 4, 1, 3 })]
        public void RemoveAtTest(int index, int[] array, int[] expectedArray)
        {
            //arrange
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);

            //act
            actual.RemoveAt(index);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-2, new int[] { 4, 1, 2, 3 })]
        public void RemoveAtNegativeTest(int index, int[] array)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.RemoveAt(index));
        }

        [TestCase(2, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2 })]
        public void RemoveLastMultipleTest(int n, int[] array, int[] expectedArray)
        {
            //arrange
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);

            //act
            actual.RemoveLastMultiple(n);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 5)]
        [TestCase(new int[] { 1, 2, 3 }, -5)]
        public void RemoveLastMultipleNegativeTest(int[] array, int value)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.RemoveLastMultiple(value));
        }

        [TestCase(2, new int[] { 1, 2, 3, 4 }, new int[] { 3, 4 })]
        public void RemoveFirstMultipleTest(int value, int[] array, int[] expectedArray)
        {
            //arrange
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);

            //act
            actual.RemoveFirstMultiple(value);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 5 })]
        public void RemoveAtMultipleTest(int index, int n, int[] array, int[] expectedArray)
        {
            //arrange
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);

            //act
            actual.RemoveAtMultiple(index, n);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 1, 5)]
        [TestCase(new int[] { 1, 2, 3 }, 1, -5)]
        [TestCase(new int[] { 1, 2, 3 }, -5, 5)]
        [TestCase(new int[] { 1, 2, 3 }, 5, -5)]
        public void RemoveAtMultipleNNegativeTest(int[] array, int index, int value)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.RemoveAtMultiple(index, value));
        }

        [TestCase(new int[] { 1, 2, 3 }, -5, 1)]
        [TestCase(new int[] { 1, 2, 3 }, 5, 1)]
        [TestCase(new int[] { 1, 2, 3 }, -5, 5)]
        [TestCase(new int[] { 1, 2, 3 }, 5, -5)]
        public void RemoveAtMultipleIndexNegativeTest(int[] array, int index, int value)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.RemoveAtMultiple(index, value));
        }

        [TestCase(2, new int[] { 1, 2, 3, 4 }, 3)]
        public void GetTest(int index, int[] array, int expected)
        {
            //arrange
            ArrayList arrayList = new ArrayList(array);

            //act
            int actual = arrayList.Get(index);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-2, new int[] { 1, 2, 3, 4 })]
        [TestCase(5, new int[] { 1, 2, 3, 4 })]
        public void GetNegativeTest(int index, int[] array)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.Get(index));
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 1)]
        public void GetFirstTest(int[] array, int expected)
        {
            //arrange
            ArrayList arrayList = new ArrayList(array);

            //act
            int actual = arrayList.GetFirst();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetFirstNegativeTest(int[] array)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.GetFirst());
        }


        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        public void GetLastTest(int[] array, int expected)
        {
            //arrange
            ArrayList arrayList = new ArrayList(array);

            //act
            int actual = arrayList.GetLast();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetLastNegativeTest(int[] array)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.GetLast());
        }

        [TestCase(2, new int[] { 1, 2, 3, 4 }, 1)]
        public void IndexOfTest(int value, int[] array, int expected)
        {
            //arrange
            ArrayList arrayList = new ArrayList(array);

            //act
            int actual = arrayList.IndexOf(value);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { })]
        public void IndexOfNegativeTest(int value, int[] array)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.IndexOf(value));
        }

        [TestCase(1, 1, new int[] { 1, 2, 3 }, new int[] { 1, 1, 3 })]
        public void SetTest(int index, int value, int[] array, int[] expectedArray)
        {
            //arrange
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);

            //act
            actual.Set(index, value);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -5, 5)]
        [TestCase(new int[] { }, 1, 6)]
        public void SetNegativeTest(int[] array, int index, int value)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.Set(index, value));
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        public void ReversTest(int[] array, int[] expectedArray)
        {
            //arrange
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            //act
            actual.Revers();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void ReversNegativeTest(int[] array)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.Revers());
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        public void MaxTest(int[] array, int expected)
        {
            //arrange
            ArrayList arrayList = new ArrayList(array);

            //act
            int actual = arrayList.Max();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void MaxNegativeTest(int[] array)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.Max());
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 1)]
        public void MinTest(int[] array, int expected)
        {
            //arrange
            ArrayList arrayList = new ArrayList(array);

            //act
            int actual = arrayList.Min();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void MinNegativeTest(int[] array)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.Min());
        }

        [TestCase(new int[] { 1, 2, 2, 4, 6, 8, 2 }, 5)]
        public void IndexOfMaxTest(int[] array, int expected)
        {
            //arrange
            ArrayList arrayList = new ArrayList(array);

            //act
            int actual = arrayList.IndexOfMax();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void IndexOfMaxNegativeTest(int[] array)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.IndexOfMax());
        }

        [TestCase(new int[] { 1, 2, 2, 4, 6, 8, 2 }, 0)]
        public void IndexOfMinTest(int[] array, int expected)
        {
            //arrange
            ArrayList arrayList = new ArrayList(array);

            //act
            int actual = arrayList.IndexOfMin();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void IndexOfMinNegativeTest(int[] array)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.IndexOfMin());
        }

        [TestCase(new int[] { 4, 8, 1, 6, 2 }, new int[] { 1, 2, 4, 6, 8 })]
        public void SortTest(int[] array, int[] expectedArray)
        {
            //arrange
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            //act
            actual.Sort();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void SortNegativeTest(int[] array)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.Sort());
        }

        [TestCase(new int[] { 4, 8, 1, 6, 2 }, new int[] { 8, 6, 4, 2, 1 })]
        public void SortDescTest(int[] array, int[] expectedArray)
        {
            //arrange
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            //act
            actual.SortDesc();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void SortDescNegativeTest(int[] array)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.SortDesc());
        }

        [TestCase(2, new int[] { 1, 2, 2, 4, 6, 8, 2 }, 1)]
        public void RemoveFirstValueTest(int value, int[] array, int expected)
        {
            //arrange
            ArrayList arrayList = new ArrayList(array);

            //act
            int actual = arrayList.RemoveFirst(value);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 3)]
        public void RemoveFirstNegativeTest(int[] array, int value)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.RemoveFirst(value));
        }

        [TestCase(2, new int[] { 1, 2, 2, 4, 6, 2, 8, 2 }, 4)]
        public void RemoveAllTest(int value, int[] array, int expected)
        {
            //arrange
            ArrayList arrayList = new ArrayList(array);

            //act
            int actual = arrayList.RemoveAll(value);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 3)]
        public void RemoveAllNegativeTest(int[] array, int value)
        {
            //arrange
            ArrayList actual = new ArrayList(array);

            //act, assert
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.RemoveAll(value));
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        public void AddLastTest(int[] arrayOne, int[] arrayTwo, int[] expectedArray)
        {
            //arrange
            ArrayList actual = new ArrayList(arrayOne);
            ArrayList arrayList = new ArrayList(arrayTwo);
            ArrayList expected = new ArrayList(expectedArray);

            //act
            actual.AddLast(arrayList);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        public void AddFirstTest(int[] arrayOne, int[] arrayTwo, int[] expectedArray)
        {
            //arrange
            ArrayList actual = new ArrayList(arrayOne);
            ArrayList arrayList = new ArrayList(arrayTwo);
            ArrayList expected = new ArrayList(expectedArray);

            //act
            actual.AddFirst(arrayList);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 4, 5, 6 }, new int[] { 1, 2, 4, 5, 6, 3 })]
        public void AddAtTest(int[] arrayOne, int index, int[] arrayTwo, int[] expectedArray)
        {
            //arrange
            ArrayList actual = new ArrayList(arrayOne);
            ArrayList arrayList = new ArrayList(arrayTwo);
            ArrayList expected = new ArrayList(expectedArray);

            //act
            actual.AddAt(arrayList, index);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 2, 4 }, 4, true)]
        [TestCase(new int[] { 1, 2, 2 }, 4, false)]
        [TestCase(new int[] { }, 4, false)]
        public void ContainsTest(int[] array, int value, bool expected)
        {
            //arrange
            ArrayList arrayList = new ArrayList(array);

            //act
            bool actual = arrayList.Contains(value);

            //assert
            Assert.AreEqual(expected, actual);

        }
    }
}