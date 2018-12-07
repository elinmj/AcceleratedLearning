using MethodsAndLists.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MethodsAndLists.Test
{   
    [TestClass]

    public class StringToBoolTests

    {
        StringToBool x = new StringToBool();

        [TestMethod]
        public void should_return_palindrome()
        {
            Assert.IsTrue(x.IsPalindrome("anna"));
            Assert.IsFalse(x.IsPalindrome("elin"));
            Assert.IsFalse(x.IsPalindrome("     "));
            Assert.IsFalse(x.IsPalindrome(null));
        }

        [TestMethod]
        public void should_return_zupcode()
        {
            Assert.IsTrue(x.IsZipCode("113 12"));
            Assert.IsFalse(x.IsZipCode("000 00"));
            Assert.IsFalse(x.IsZipCode("66666"));
            Assert.IsFalse(x.IsZipCode("PANDA"));
        }

        [TestMethod]
        public void if_all_words_are_five_letters_or_longer_should_return_true()
        {
            Assert.IsTrue(x.FiveLettersOrLonger_True(new[] { "dfagdfgadgad", "dfsfsfsdfs", "asdadadasasd" }));
            
        }

        [TestMethod]
        public void if_all_words_are_five_letters_or_longer_should_return_false()
        {
            Assert.IsFalse(x.FiveLettersOrLonger_False(new[] { "dfagdfgadgad", "dfsfsfsdfs", "asdadadasasd" }));

        }
    }
}
