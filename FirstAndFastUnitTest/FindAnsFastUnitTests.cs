using System;
using FastFindAndFastAddExample;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace FirstAndFastUnitTest
{
    [TestClass]
    public class FindAnsFastUnitTests
    {
        private const int ElementsCount = 10000000;
        private const int RemoveElement = 77777;
        private string[] data;

        [TestInitialize]
        public void Initialize()
        {
            data = new string[ElementsCount];
            for (int i = 0; i != ElementsCount; i++)
                data[i] = Program.GenerateString(3, 20);
        }

        [TestMethod]
        public void Test_HashSet_FindAndDeleteElement()
        {
            //Arrange
            HashSet<string> hashSet = new HashSet<string>(data);
            Stopwatch stopWatch = new Stopwatch();

            //Act
            stopWatch.Start();
            hashSet.Remove(data[RemoveElement]);
            stopWatch.Stop();

            //Assert
            long result = stopWatch.ElapsedMilliseconds;
            long lessThanMs = 1;

            Assert.IsTrue(result < lessThanMs);
        }

        [TestMethod]
        public void Test_List_AddElement()
        {
            //Arrange
            List<string> list = new List<string>();
            Stopwatch stopWatch = new Stopwatch();
            for (int i = 0; i != ElementsCount - 1; i++)
                list.Add(data[i]);

            //Act
            stopWatch.Start();
            list.Add(data[ElementsCount - 1]);
            stopWatch.Stop();

            //Assert
            long result = stopWatch.ElapsedMilliseconds;
            long lessThanMs = 1;

            Assert.IsTrue(result < lessThanMs);
        }
    }
}
