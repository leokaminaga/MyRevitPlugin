using Microsoft.VisualStudio.TestTools.UnitTesting;
using Revit.Plugin.kaminaga;
using System;
using System.Reflection;
using System.Windows.Media.Imaging;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var command = new Command();
            var calc = command.Add(1, 2);
            Assert.AreEqual(3, calc);
        }
    }
}
