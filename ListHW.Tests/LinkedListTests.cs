using NUnit.Framework;
using System;
using ListHW.LinkedList;

namespace ListHWTests
{
    internal class LinkedListTests
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
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);

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
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);

            //act
            actual.AddFirst(value);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, 1, new int[] { 1, 2, 3 }, new int[] { 1, 4, 2, 3 })]
        public void AddAtTest(int value, int index, int[] array, int[] expectedArray)
        {
            //arrange
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);

            //act
            actual.AddAt(value, index);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 })]
        public void RemoveLastTest(int[] array, int[] expectedArray)
        {
            //arrange
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);

            //act
            actual.RemoveLast();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4 })]
        public void RemoveFirstTest(int[] array, int[] expectedArray)
        {
            //arrange
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);

            //act
            actual.RemoveFirst();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 4, 1, 2, 3 }, new int[] { 4, 1, 3 })]
        public void RemoveAtTest(int index, int[] array, int[] expectedArray)
        {
            //arrange
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);

            //act
            actual.RemoveAt(index);

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestCase(2, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2 })]
        public void RemoveLastMultipleTest(int n, int[] array, int[] expectedArray)
        {
            //arrange
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);

            //act
            actual.RemoveLastMultiple(n);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4 }, new int[] { 3, 4 })]
        public void RemoveFirstMultipleTest(int value, int[] array, int[] expectedArray)
        {
            //arrange
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);

            //act
            actual.RemoveFirstMultiple(value);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveAtMultipleTest(int index, int n, int[] array, int[] expectedArray)
        {
            //arrange
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);

            //act
            actual.RemoveAtMultiple(index, n);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4 }, 1)]
        public void GetTest(int index, int[] array, int expected)
        {
            //arrange
            LinkedList linkedList = new LinkedList(array);

            //act
            int actual = linkedList.Get(index);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 1)]
        public void GetFirstTest(int[] array, int expected)
        {
            //arrange
            LinkedList linkedList = new LinkedList(array);

            //act
            int actual = linkedList.GetFirst();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        public void GetLastTest(int[] array, int expected)
        {
            //arrange
            LinkedList linkedList = new LinkedList(array);

            //act
            int actual = linkedList.GetLast();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4 }, 1)]
        public void IndexOfTest(int value, int[] array, int expected)
        {
            //arrange
            LinkedList linkedList = new LinkedList(array);

            //act
            int actual = linkedList.IndexOf(value);

            //assert
            Assert.AreEqual(expected, actual);
        }



        [TestCase(1, 1, new int[] { 1, 2, 3 }, new int[] { 1, 1, 3 })]
        public void SetTest(int index, int value, int[] array, int[] expectedArray)
        {
            //arrange
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);

            //act
            actual.Set(index, value);

            //assert
            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        public void ReversTest(int[] array, int[] expectedArray)
        {
            //arrange
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            //act
            actual.Revers();

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        public void MaxTest(int[] array, int expected)
        {
            //arrange
            LinkedList linkedList = new LinkedList(array);

            //act
            int actual = linkedList.Max();

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4 }, 1)]
        public void MinTest(int[] array, int expected)
        {
            //arrange
            LinkedList linkedList = new LinkedList(array);

            //act
            int actual = linkedList.Min();

            //assert
            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 1, 2, 2, 4, 6, 8, 2 }, 5)]
        public void IndexOfMaxTest(int[] array, int expected)
        {
            //arrange
            LinkedList linkedList = new LinkedList(array);

            //act
            int actual = linkedList.IndexOfMax();

            //assert
            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 1, 2, 2, 4, 6, 8, 2 }, 0)]
        public void IndexOfMinTest(int[] array, int expected)
        {
            //arrange
            LinkedList linkedList = new LinkedList(array);

            //act
            int actual = linkedList.IndexOfMin();

            //assert
            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 4, 8, 1, 6, 2 }, new int[] { 1, 2, 4, 6, 8 })]
        public void SortTest(int[] array, int[] expectedArray)
        {
            //arrange
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            //act
            actual.Sort();

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 4, 8, 1, 6, 2 }, new int[] { 8, 6, 4, 2, 1 })]
        public void SortDescTest(int[] array, int[] expectedArray)
        {
            //arrange
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            //act
            actual.SortDesc();

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestCase(2, new int[] { 1, 2, 2, 4, 6, 8, 2 }, 1)]
        public void RemoveFirstValueTest(int value, int[] array, int expected)
        {
            //arrange
            LinkedList linkedList = new LinkedList(array);

            //act
            int actual = linkedList.RemoveFirst(value);

            //assert
            Assert.AreEqual(expected, actual);
        }



        [TestCase(2, new int[] { 1, 2, 2, 4, 6, 2, 8, 2 }, 4)]
        public void RemoveAllTest(int value, int[] array, int expected)
        {
            //arrange
            LinkedList linkedList = new LinkedList(array);

            //act
            int actual = linkedList.RemoveAll(value);

            //assert
            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        public void AddLastTest(int[] arrayOne, int[] arrayTwo, int[] expectedArray)
        {
            //arrange
            LinkedList actual = new LinkedList(arrayOne);
            LinkedList linkedList = new LinkedList(arrayTwo);
            LinkedList expected = new LinkedList(expectedArray);

            //act
            actual.AddLast(linkedList);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        public void AddFirstTest(int[] arrayOne, int[] arrayTwo, int[] expectedArray)
        {
            //arrange
            LinkedList actual = new LinkedList(arrayOne);
            LinkedList linkedList = new LinkedList(arrayTwo);
            LinkedList expected = new LinkedList(expectedArray);

            //act
            actual.AddFirst(linkedList);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 4, 5, 6 }, new int[] { 1, 2, 4, 5, 6, 3 })]
        public void AddAtTest(int[] arrayOne, int index, int[] arrayTwo, int[] expectedArray)
        {
            //arrange
            LinkedList actual = new LinkedList(arrayOne);
            LinkedList linkedList = new LinkedList(arrayTwo);
            LinkedList expected = new LinkedList(expectedArray);

            //act
            actual.AddAt(index, linkedList);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 2, 4 }, 4, false)]
        [TestCase(new int[] { 1, 2, 2 }, 4, false)]
        [TestCase(new int[] { }, 4, false)]
        public void ContainsTest(int[] array, int value, bool expected)
        {
            //arrange
            LinkedList linkedListyList = new LinkedList(array);

            //act
            bool actual = linkedListyList.Contains(value);

            //assert
            Assert.AreEqual(expected, actual);

        }
    }
}
