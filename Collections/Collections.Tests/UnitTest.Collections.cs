using NUnit.Framework;
using System;
using System.Linq;

namespace Collections.Tests
{
    public class Tests
    {
        private Collection<int> collection;
        //private Collection<int> expected;


        [Test]
        [Timeout(1000)]
        public void Test_OneMilionItems()
        {
            //arrange
            int oneMilionItems = 1000000;
            collection = new Collection<int>();
            //act
            collection.AddRange(Enumerable.Range(0, oneMilionItems).ToArray());
            //assert
            Assert.AreEqual(0, collection[0]);
            Assert.AreEqual(oneMilionItems, collection.Count);
            Assert.That(collection.Capacity >= oneMilionItems);

        }

        [Test]
        public void Test_Add()
        {
            //arrange
            collection = new Collection<int>();
            int addItem = 19;
            //act
            collection.Add(addItem);
            //assert
            Assert.AreEqual(addItem, collection[0]);

        }

        [Test]
        public void Test_AddWithGrow()
        {
            //arrange
            int grow = 10;
            collection = new Collection<int>(grow);
            int addItem = 19;
            //act
            collection.Add(addItem);
            //assert
            Assert.AreEqual(10, collection[0]);
            Assert.AreEqual(19, collection[1]);

        }

        [Test]
        public void Test_AddRange()
        {
            //arrange
            int [] addRangeItems = new int[] {10,20,30};
            collection = new Collection<int>();
            //act
            collection.AddRange(addRangeItems);
            //assert
            Assert.AreEqual(addRangeItems.Length , collection.Count);
        }

        [Test]
        public void Test_AddRangeWithGrow()
        {
            //arrange
           int [] numbers = new int[10];
           collection = new Collection<int>(numbers);

            //act
            collection.AddRange(10, 20, 30);
            //assert
            Assert.AreEqual(30, collection[collection.Count - 1]);
            Assert.AreEqual(numbers.Length + 3, collection.Count);
            Assert.AreEqual(numbers.Length * 2, collection.Capacity);
            Console.WriteLine(collection);

        }

        [Test]

        public void Test_Clear()
        {
            collection = new Collection<int>(1,2,3,4,5);
            collection.Clear();
            Assert.AreEqual(0, collection.Count);
        }

        [Test]

        public void Test_ConstructorMultiplyItems()
        {
            collection = new Collection<int>(1, 2, 3, 4, 5);
            string expected = "[1, 2, 3, 4, 5]";
            Assert.AreEqual(expected, collection.ToString());
            Assert.AreEqual(5, collection.Count);
        }

        [Test]

        public void Test_ConstructorOneItem()
        {
            collection = new Collection<int>(5);
            string expected = "[5]";
            Assert.AreEqual(expected, collection.ToString());
            Assert.AreEqual(1, collection.Count);
            Assert.That(collection.Count, Is.EqualTo(1));
        }

        [Test]

        public void Test_EmptyConstructor()
        {
            collection = new Collection<int>();
            Assert.AreEqual(0, collection.Count);
        }

        [Test]

        public void Test_CountAndCapacity()
        {
            collection = new Collection<int>();
            Assert.AreEqual(collection.Count,0);
            Assert.AreEqual(collection.Capacity, 16);
        }

        [Test]

        public void Test_ExchangeFirstAndLast()
        {
            Collection<int> collection = new Collection<int>(new int[] {1,2,3,4,5});
            collection.Exchange(0,collection.Count - 1);
            Assert.AreEqual(collection[0], 5);
            Assert.AreEqual(collection[4], 1);
        }

        [Test]
        public void Test_ExchangeInvalidElementThrows()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });
            Assert.Throws<ArgumentOutOfRangeException>(() => collection.Exchange(collection[-1],collection[10]));
        }

        [Test]

        public void Test_ExchangeMiddle()
        {
            Collection<int> collection = new Collection<int>(new int[] {1,2,3,4,5,6,7});
            collection.Exchange(0, collection.Count / 2);
            collection.Exchange(collection.Count / 2 , collection.Count - 1);
            Assert.AreEqual(collection[0], 4);
            Assert.AreEqual(collection[collection.Count / 2], 7);
            Assert.AreEqual(collection[collection.Count - 1], 1);

        }

        [Test]

        public void Test_GetByIndex()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5, 6, 7});
            var actual = collection[collection.Count / 2];
            Assert.AreEqual(actual, 4);
            Assert.That(actual, Is.EqualTo(collection[collection.Count / 2]));
        }

        [Test]
        public void Test_GetByInvalidIndexThrows()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            Assert.That(() => { var invalid = collection[-1]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { var invalid = collection[collection.Count * 2]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.IsNotEmpty(collection.Count.ToString());
            
        }

        [Test]
        public void Test_InserdAtEnd()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4 });
            var inserdItem = 5;
            collection.InsertAt(collection.Count, inserdItem);
            Assert.That(inserdItem, Is.Not.Null);
            Assert.That(inserdItem, Is.EqualTo(collection[4]));
            Assert.That(inserdItem, Is.EqualTo(collection[collection.Count - 1]));
            Assert.That(collection.Count == 5);
        }


        [Test]
        public void Test_InserdAtInvalidThrows()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });
            var item = 6;
            Assert.That(() => { collection.InsertAt(collection[-1] ,item); },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { collection.InsertAt(collection.Count * 2, item); },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.IsNotEmpty(collection.Count.ToString());

        }

        [Test]
        public void Test_InserdAtMiddle()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 4, 5 });
            var inserdItem = 3;
            collection.InsertAt(collection.Count / 2, inserdItem);
            Assert.That(inserdItem, Is.Not.Null);
            Assert.That(inserdItem, Is.EqualTo(collection[2]));
            Assert.That(inserdItem, Is.EqualTo(collection[collection.Count / 2]));
            Assert.That(collection.Count == 5);
        }

        [Test]
        public void Test_InserdAtSrat()
        {
            Collection<int> collection = new Collection<int>(new int[] { 2, 3, 4, 5 });
            var inserdItem = 1;
            collection.InsertAt(0, inserdItem);
            Assert.That(inserdItem, Is.Not.Null);
            Assert.That(inserdItem, Is.EqualTo(collection[0]));
            Assert.That(collection.Count == 5);
            // Console.WriteLine(collection);
        }


        [Test]
        public void Test_InserdWithGrow()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });
            int [] inserdItems = {6,7,8,9,10};
            for (int i = 0; i < inserdItems.Length; i++)
            {
                collection.InsertAt(collection.Count, inserdItems[i]);
            }

            Assert.That(collection.ToString(), Is.EqualTo("[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]")); ;
            Assert.That(collection.Count == 10);
            Assert.That(collection.Capacity, Is.GreaterThanOrEqualTo(inserdItems.Length));
        }

        [Test]
        public void Test_RemoveAll()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });
            collection.Clear();

            Assert.That(collection.Count, Is.EqualTo(0));
            Assert.That(collection.Capacity, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void Test_RemoveAtEnd()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            collection.RemoveAt(collection.Count - 1);
            Assert.That(collection.ToString(), Is.EqualTo("[1, 2, 3, 4]")); ;
            Assert.That(collection.Count == 4);
        }

        [Test]
        public void Test_RemoveAtStart()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            collection.RemoveAt(0);
            Assert.That(collection.ToString(), Is.EqualTo("[2, 3, 4, 5]")); ;
            Assert.That(collection.Count == 4);
        }

        [Test]
        public void Test_RemoveAtMiddle()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            collection.RemoveAt(collection.Count / 2);
            Assert.That(collection.ToString(), Is.EqualTo("[1, 2, 4, 5]")); ;
            Assert.That(collection.Count == 4);
        }

        [Test]
        public void Test_RemoveAtInvalidThrows()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            Assert.That(() => { collection.RemoveAt(collection[-1]); },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { collection.RemoveAt(collection.Count * 2); },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.IsNotEmpty(collection.Count.ToString());
        }

        [Test]
        public void Test_SetByIndex()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5, 6, 7});
            var newIndex = 10;
            collection[collection.Count / 2] = newIndex;
            Assert.AreEqual(collection[collection.Count / 2], 10);
            Assert.That(collection.ToString(), Is.EqualTo("[1, 2, 3, 10, 5, 6, 7]")); ;

        }

        [Test]
        public void Test_SetByInvalidThrows()
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            var newIndex = 10;

            Assert.That(() => { collection[-1] = newIndex; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { collection[collection.Count * 2] = newIndex; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.IsNotEmpty(collection.Count.ToString());
        }

        [Test]
        public void Test_ToStringCollectionOfCollections()
        {
            var uno = new Collection<int>(1, 2, 3);
            var dos = new Collection<int>(4, 5, 6);
            var tres = new Collection<object>(uno, dos);

            Assert.That(tres.ToString(), Is.EqualTo("[[1, 2, 3], [4, 5, 6]]"));
        }

        [Test]
        public void Test_ToEmptyString()
        {
            collection = new Collection<int>();
            Assert.That(collection.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_ToStringMultiply()
        {
            collection = new Collection<int>();
            Assert.That(collection.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_ToStringSingle()
        {
            collection = new Collection<int>();
            Assert.That(collection.ToString(), Is.EqualTo("[]"));
        }
    }
}