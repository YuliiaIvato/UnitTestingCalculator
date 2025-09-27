using AnalaizerClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Configuration;

namespace UnitTestProject1
{
    //[TestClass]
    //public class AnalizerClassTest
    //{
    //    [TestMethod]
    //    public void IsDelimeterTest()
    //    {
    //        //Arrange
    //        char c = ' ';
    //        bool expected = true;
    //        //Actual
    //        bool actual = AnalaizerClass.IsDelimeter(c);
    //        //Assert
    //        Assert.AreEqual(expected, actual);
    //    }

    //    [TestMethod]
    //    public void IsOperatorTest()
    //    {
    //        //Arrange
    //        string s = "+";
    //        bool expected = true;
    //        //Actual
    //        bool actual = AnalaizerClass.IsOperator(s);
    //        //Assert
    //        Assert.AreEqual(expected, actual);
    //    }

    //    [TestMethod]
    //    public void IsDelimeter_Test()
    //    {
    //        Assert.IsTrue(AnalaizerClass.IsDelimeter(' '));
    //        Assert.IsFalse(AnalaizerClass.IsDelimeter('\t'));
    //        Assert.IsFalse(AnalaizerClass.IsDelimeter('\n'));
    //        Assert.IsFalse(AnalaizerClass.IsDelimeter('a'));
    //        Assert.IsFalse(AnalaizerClass.IsDelimeter('+'));
    //    }

    //    [TestMethod]
    //    public void IsOperator_Test()
    //    {
    //        string[] operators = { "+", "-", "*", "/", "(", ")"};
    //        foreach (var op in operators)
    //        {
    //            Assert.IsTrue(AnalaizerClass.IsOperator(op));
    //        }
    //        string[] notOperators = { "a", "1", " "};
    //        foreach (var notOp in notOperators)
    //        {
    //            Assert.IsFalse(AnalaizerClass.IsOperator(notOp));
    //        }
    //    }



    //}

    [TestClass]
    public class AnalizerClassTest
    { 
        [TestMethod]
        public void IsDelimiterTest()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=WIN-R2HTMOFGAGL;Database=Calculator;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Symbol, Expected FROM Delimiters", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //Arrange
                    string symbol = reader.GetString(0); 
                    bool expected = reader.GetBoolean(1);

                    //Actual
                    char c = symbol[0];   
                    bool actual = AnalaizerClass.IsDelimeter(c);

                    //Assert
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public void IsOperatorTest()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=WIN-R2HTMOFGAGL;Database=Calculator;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Symbol, Expected FROM Operators", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //Arrange
                    string symbol = reader.GetString(0).Trim();     
                    bool expected = reader.GetBoolean(1);

                    //Actual
                    bool actual = AnalaizerClass.IsOperator(symbol);

                    //Assert
                    Assert.AreEqual(expected, actual);
                }
            }
        }

    }
}
