﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.CodeGeneration.ConsoleTest
{
    using System;
    using NUnit.Framework;
    using Karkas.CodeGenerationHelper.Interfaces;
    using Karkas.CodeGenerationHelper;

    [TestFixture]
    public class PropertyNameCheckerTest
    {
        INameChecker nameChecker = new NameChecker();

        [SetUp]
        public void Init()
        {
            nameChecker = new NameChecker();
        }
        [Test]
        public void Property2BuyukHarfTest()
        {
            string propertyName = "UKullaniciKey";
            string propertyNameNew = nameChecker.SetPascalCase(propertyName);
            Assert.IsTrue(String.Equals("UKullaniciKey", propertyNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void PropertyHasNonStandardCharsInTheMiddleTest()
        {
            string propertyName = "a-/#1b";
            string propertyNameNew = nameChecker.SetPascalCase(propertyName);
            Assert.IsTrue(String.Equals("A1b", propertyNameNew, StringComparison.InvariantCulture)); 
        }
        
        [Test]
        public void PropertyHasNonStandardCharsLeftAndRightParanthesisDotAndSpaceInTheMiddleTest()
        {
            string propertyName = "(1.3) ip";
            string propertyNameNew = nameChecker.SetPascalCase(propertyName);
            Assert.IsTrue(String.Equals("d13Ip", propertyNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void PropertyHasNonStandardCharsAtTheBeginningTest()
        {
            string propertyName = "-/#ba";
            string propertyNameNew = nameChecker.SetPascalCase(propertyName);
            Assert.IsTrue(String.Equals("Ba", propertyNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void PropertyHasNonStandardCharsAtTheBeginningAndInTheMiddleTest()
        {
            string propertyName = "-/#b-/a";
            string propertyNameNew = nameChecker.SetPascalCase(propertyName);
            Assert.IsTrue(String.Equals("BA", propertyNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void PropertyHasNumericCharsAtTheBeginningTest()
        {
            string propertyName = "1-2#days";
            string propertyNameNew = nameChecker.SetPascalCase(propertyName);
            Assert.IsTrue(String.Equals("D12Days", propertyNameNew, StringComparison.InvariantCulture));
        }

        [Test]
        public void PropertyHasNumericCharsAtTheBeginningAndInTheMiddleTest()
        {
            string propertyName = "01to-2days";
            string propertyNameNew = nameChecker.SetPascalCase(propertyName);
            Assert.IsTrue(String.Equals("D01to2days", propertyNameNew, StringComparison.InvariantCulture));
        }
    }
}

