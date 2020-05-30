using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Moq;
using WindowsFormsApp1;
using System.Numerics;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using System.Diagnostics;

namespace WindowsFormsApp1.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFieldCheckIntersectionWorksProperly()
        {
            CubePrimitive cube = Mock.Of<CubePrimitive>(
                d => d.CheckIntersection(It.IsAny<AbstractPrimitive>()) == true
            );

            RectanglePrimitive rectangle = Mock.Of<RectanglePrimitive>(
                d => d.CheckIntersection(It.IsAny<AbstractPrimitive>()) == true
            );

            RectanglePrimitive rectangle2 = new RectanglePrimitive(new Vector3(100, 100, 100), 3, 3);

            Field field = new Field();

            field.AddObject(cube);
            field.AddObject(rectangle);
            field.AddObject(rectangle2);

            foreach (int i in new int[5] { -1, 3, 5, 7, 0 }) {
                foreach (int j in new int[4] { -1, 3, 5, 7 })
                {
                    Assert.IsFalse(field.CheckIntersection(i, j));
                }
            }

            foreach (int i in new int[2] { 0, 1 })
            {
                foreach (int j in new int[3] { 0, 1, 2 })
                {
                    Assert.IsTrue(field.CheckIntersection(i, j));
                }
            }
        }
    }
}