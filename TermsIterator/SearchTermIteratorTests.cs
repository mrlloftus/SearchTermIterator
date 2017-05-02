using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TermsIterator
{
    [TestClass]
    public class SearchTermIteratorTests
    {


        [TestMethod]
        public void NullInputTest()
        {
            var terms = SearchTermIterator.GetInstance(null);
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void EmptyInputTest()
        {
            var terms = SearchTermIterator.GetInstance(string.Empty);
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void ShrimpWhiteTest()
        {
            var terms = SearchTermIterator.GetInstance("shrimp white");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("shrimp white", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("shrimp", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("white", terms.Next());
            terms.ReportHit();
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void MahiMahiTest()
        {
            var terms = SearchTermIterator.GetInstance("mahi mahi");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("mahi mahi", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("mahi", terms.Next());
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void MahiMahiHitTest()
        {
            var terms = SearchTermIterator.GetInstance("mahi mahi");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("mahi mahi", terms.Next());
            terms.ReportHit();
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void MahiMahiSecondHitTest()
        {
            var terms = SearchTermIterator.GetInstance("mahi mahi");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("mahi mahi", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("mahi", terms.Next());
            terms.ReportHit();
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestOne()
        {
            var terms = SearchTermIterator.GetInstance("test");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("test", terms.Next());
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestOneHit()
        {
            var terms = SearchTermIterator.GetInstance("test");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("test", terms.Next());
            terms.ReportHit();
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestTwo()
        {
            var terms = SearchTermIterator.GetInstance("one two");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two", terms.Next());
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestTwoFirstHit()
        {
            var terms = SearchTermIterator.GetInstance("one two");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two", terms.Next());
            terms.ReportHit();
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestTwoSecondHit()
        {
            var terms = SearchTermIterator.GetInstance("one two");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one", terms.Next());
            terms.ReportHit();
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two", terms.Next());
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestTwoThirdHit()
        {
            var terms = SearchTermIterator.GetInstance("one two");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two", terms.Next());
            terms.ReportHit();
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestThree()
        {
            var terms = SearchTermIterator.GetInstance("one two three");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two three", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("three", terms.Next());
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestThreeFirstHit()
        {
            var terms = SearchTermIterator.GetInstance("one two three");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three", terms.Next());
            terms.ReportHit();
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestThreeSecondHit()
        {
            var terms = SearchTermIterator.GetInstance("one two three");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two", terms.Next());
            terms.ReportHit();
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("three", terms.Next());
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestThreeThirdHit()
        {
            var terms = SearchTermIterator.GetInstance("one two three");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two three", terms.Next());
            terms.ReportHit();
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one", terms.Next());
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestFour()
        {
            var terms = SearchTermIterator.GetInstance("one two three four");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two three four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two three", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("three four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("three", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("four", terms.Next());
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestFourFirstHit()
        {
            var terms = SearchTermIterator.GetInstance("one two three four");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three four", terms.Next());
            terms.ReportHit();
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestFourSecondHit()
        {
            var terms = SearchTermIterator.GetInstance("one two three four");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three", terms.Next());
            terms.ReportHit();
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("four", terms.Next());
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestFourThirdHit()
        {
            var terms = SearchTermIterator.GetInstance("one two three four");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two three four", terms.Next());
            terms.ReportHit();
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one", terms.Next());
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestFourFourthHit()
        {
            var terms = SearchTermIterator.GetInstance("one two three four");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two three four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two", terms.Next());
            terms.ReportHit();
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("three four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("three", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("four", terms.Next());
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestFourFifthHit()
        {
            var terms = SearchTermIterator.GetInstance("one two three four");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two three four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two three", terms.Next());
            terms.ReportHit();
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("four", terms.Next());
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestFourSixthHit()
        {
            var terms = SearchTermIterator.GetInstance("one two three four");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two three four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two three", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("three four", terms.Next());
            terms.ReportHit();
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two", terms.Next());
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestFive()
        {
            var terms = SearchTermIterator.GetInstance("one two three four five");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three four five", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two three four five", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two three four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("three four five", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two three", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("three four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("four five", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("two", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("three", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("four", terms.Next());
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("five", terms.Next());
            Assert.IsFalse(terms.HasNext());
        }

        [TestMethod]
        public void SearchTermIteratorTestFiveRemovingExtraSpace()
        {
            var terms = SearchTermIterator.GetInstance("one two three four  five");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("one two three four five", terms.Next());
            Assert.IsTrue(terms.HasNext());
        }

        [TestMethod]
        public void TestStringRemovingPunctuation()
        {
            var terms = SearchTermIterator.GetInstance("this:  Is my, string");
            Assert.IsTrue(terms.HasNext());
            Assert.AreEqual("this Is my string", terms.Next());
            Assert.IsTrue(terms.HasNext());
        }

    }
}
