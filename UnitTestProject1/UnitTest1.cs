using AnalaizerClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class AnalizerClassTest
    {
        [TestMethod]
        public void IsDelimeterTest()
        {
            //Arrange
            char c = ' ';
            bool expected = true;
            //Actual
            bool actual = AnalaizerClass.IsDelimeter(c);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsOperatorTest()
        {
            //Arrange
            string s = "+";
            bool expected = true;
            //Actual
            bool actual = AnalaizerClass.IsOperator(s);
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}