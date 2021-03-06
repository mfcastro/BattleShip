// <copyright file="MapTest.cs">Copyright ©  2016</copyright>
using System;
using BattleShip;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleShip.Tests
{
    /// <summary>This class contains parameterized unit tests for Map</summary>
    [PexClass(typeof(Map))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class MapTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        internal Map ConstructorTest()
        {
            Map target = new Map();
            return target;
            // TODO: add assertions to method MapTest.ConstructorTest()
        }

        /// <summary>Test stub for drawMap()</summary>
        [PexMethod]
        internal void drawMapTest([PexAssumeUnderTest]Map target)
        {
            target.drawMap();
            // TODO: add assertions to method MapTest.drawMapTest(Map)
        }

        /// <summary>Test stub for fillMap(Int32, Int32)</summary>
        [PexMethod]
        internal void fillMapTest(
            [PexAssumeUnderTest]Map target,
            int length,
            int width
        )
        {
            target.fillMap(length, width);
            // TODO: add assertions to method MapTest.fillMapTest(Map, Int32, Int32)
        }
    }
}
