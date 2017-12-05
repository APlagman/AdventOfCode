using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventSolutions;

namespace AdventTests
{
    [TestClass]
    public class Day4Tests
    {
        [TestMethod]
        public void TestAreAllWordsDistinct()
        {
            Assert.AreEqual(true, Day4.AreAllWordsDistinct("aa bb cc dd ee"));
            Assert.AreEqual(false, Day4.AreAllWordsDistinct("aa bb cc dd aa"));
            Assert.AreEqual(true, Day4.AreAllWordsDistinct("aa bb cc dd aaa"));
        }

        [TestMethod]
        public void TestAreNoWordsAnagrams()
        {
            Assert.AreEqual(true, Day4.AreNoWordsAnagrams("abcde fghij"));
            Assert.AreEqual(false, Day4.AreNoWordsAnagrams("abcde xyz ecdab"));
            Assert.AreEqual(true, Day4.AreNoWordsAnagrams("a ab abc abd abf abj"));
            Assert.AreEqual(true, Day4.AreNoWordsAnagrams("iiii oiii ooii oooi oooo"));
            Assert.AreEqual(false, Day4.AreNoWordsAnagrams("oiii ioii iioi iiio"));
        }
    }
}
