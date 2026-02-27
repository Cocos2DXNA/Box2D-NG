using Microsoft.VisualStudio.TestTools.UnitTesting;
using Box2DNG;

namespace Box2DNG.Tests
{
    [TestClass]
    public class ShapeTests
    {
        [TestMethod]
        public void CircleShape_Constructor_InitializesCorrectly()
        {
            var shape = new CircleShape(5.0f);
            Assert.AreEqual(Vec2.Zero, shape.Center);
            Assert.AreEqual(5.0f, shape.Radius);
        }

        [TestMethod]
        public void CircleShape_Constructor_WithCenter_InitializesCorrectly()
        {
            var center = new Vec2(1.0f, 2.0f);
            var shape = new CircleShape(center, 3.0f);
            Assert.AreEqual(center, shape.Center);
            Assert.AreEqual(3.0f, shape.Radius);
        }

        [TestMethod]
        public void CircleShape_WithCenter_ChangesCenter()
        {
            var shape = new CircleShape(1.0f);
            var newCenter = new Vec2(5.0f, 6.0f);
            var result = shape.WithCenter(newCenter);

            Assert.AreEqual(newCenter, shape.Center);
            Assert.AreEqual(shape, result); // Should return self for chaining
        }

        [TestMethod]
        public void CircleShape_WithRadius_ChangesRadius()
        {
            var shape = new CircleShape(1.0f);
            var result = shape.WithRadius(5.0f);

            Assert.AreEqual(5.0f, shape.Radius);
            Assert.AreEqual(shape, result); // Should return self for chaining
        }

        [TestMethod]
        public void CapsuleShape_Constructor_InitializesCorrectly()
        {
            var center1 = new Vec2(1.0f, 2.0f);
            var center2 = new Vec2(3.0f, 4.0f);
            var shape = new CapsuleShape(center1, center2, 2.0f);

            Assert.AreEqual(center1, shape.Center1);
            Assert.AreEqual(center2, shape.Center2);
            Assert.AreEqual(2.0f, shape.Radius);
        }

        [TestMethod]
        public void CapsuleShape_WithCenters_ChangesCenters()
        {
            var shape = new CapsuleShape(new Vec2(0.0f, 0.0f), new Vec2(1.0f, 1.0f), 1.0f);
            var newCenter1 = new Vec2(5.0f, 6.0f);
            var newCenter2 = new Vec2(7.0f, 8.0f);
            var result = shape.WithCenters(newCenter1, newCenter2);

            Assert.AreEqual(newCenter1, shape.Center1);
            Assert.AreEqual(newCenter2, shape.Center2);
            Assert.AreEqual(shape, result); // Should return self for chaining
        }

        [TestMethod]
        public void CapsuleShape_WithRadius_ChangesRadius()
        {
            var shape = new CapsuleShape(new Vec2(0.0f, 0.0f), new Vec2(1.0f, 1.0f), 1.0f);
            var result = shape.WithRadius(5.0f);

            Assert.AreEqual(5.0f, shape.Radius);
            Assert.AreEqual(shape, result); // Should return self for chaining
        }

        [TestMethod]
        public void SegmentShape_Constructor_InitializesCorrectly()
        {
            var point1 = new Vec2(1.0f, 2.0f);
            var point2 = new Vec2(3.0f, 4.0f);
            var shape = new SegmentShape(point1, point2);

            Assert.AreEqual(point1, shape.Point1);
            Assert.AreEqual(point2, shape.Point2);
        }

        [TestMethod]
        public void PolygonShape_Constructor_InitializesCorrectly()
        {
            var vertices = new Vec2[] { new Vec2(0.0f, 0.0f), new Vec2(1.0f, 0.0f), new Vec2(1.0f, 1.0f) };
            var shape = new PolygonShape(vertices);

            Assert.AreEqual(vertices, shape.Vertices);
        }

        [TestMethod]
        public void ChainSegmentShape_Constructor_InitializesCorrectly()
        {
            var point1 = new Vec2(1.0f, 2.0f);
            var point2 = new Vec2(3.0f, 4.0f);
            var ghost1 = new Vec2(0.0f, 1.0f);
            var ghost2 = new Vec2(4.0f, 5.0f);
            var shape = new ChainSegmentShape(point1, point2, ghost1, ghost2);

            Assert.AreEqual(point1, shape.Point1);
            Assert.AreEqual(point2, shape.Point2);
            Assert.AreEqual(ghost1, shape.Ghost1);
            Assert.AreEqual(ghost2, shape.Ghost2);
        }
    }
}
