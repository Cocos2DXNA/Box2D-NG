using Microsoft.VisualStudio.TestTools.UnitTesting;
using Box2DNG;

namespace Box2DNG.Tests
{
    [TestClass]
    public class ShapeGeometryTests
    {
        [TestMethod]
        public void ShapeGeometry_ToCircle_ConvertsCircleShape()
        {
            var circleShape = new CircleShape(new Vec2(1.0f, 2.0f), 3.0f);
            var circle = ShapeGeometry.ToCircle(circleShape);

            Assert.AreEqual(circleShape.Center, circle.Center);
            Assert.AreEqual(circleShape.Radius, circle.Radius);
        }

        [TestMethod]
        public void ShapeGeometry_ToCapsule_ConvertsCapsuleShape()
        {
            var capsuleShape = new CapsuleShape(new Vec2(1.0f, 2.0f), new Vec2(3.0f, 4.0f), 2.0f);
            var capsule = ShapeGeometry.ToCapsule(capsuleShape);

            Assert.AreEqual(capsuleShape.Center1, capsule.Center1);
            Assert.AreEqual(capsuleShape.Center2, capsule.Center2);
            Assert.AreEqual(capsuleShape.Radius, capsule.Radius);
        }

        [TestMethod]
        public void ShapeGeometry_ToSegment_ConvertsSegmentShape()
        {
            var segmentShape = new SegmentShape(new Vec2(1.0f, 2.0f), new Vec2(3.0f, 4.0f));
            var segment = ShapeGeometry.ToSegment(segmentShape);

            Assert.AreEqual(segmentShape.Point1, segment.Point1);
            Assert.AreEqual(segmentShape.Point2, segment.Point2);
        }

        [TestMethod]
        public void ShapeGeometry_ToProxy_ConvertsCircleShape()
        {
            var circleShape = new CircleShape(new Vec2(1.0f, 2.0f), 3.0f);
            var proxy = ShapeGeometry.ToProxy(circleShape);

            Assert.IsNotNull(proxy);
            Assert.AreEqual(1, proxy.Count);
            Assert.AreEqual(circleShape.Radius, proxy.Radius);
            Assert.AreEqual(circleShape.Center, proxy.Points[0]);
        }

        [TestMethod]
        public void ShapeGeometry_ToProxy_ConvertsCapsuleShape()
        {
            var capsuleShape = new CapsuleShape(new Vec2(1.0f, 2.0f), new Vec2(3.0f, 4.0f), 2.0f);
            var proxy = ShapeGeometry.ToProxy(capsuleShape);

            Assert.IsNotNull(proxy);
            Assert.AreEqual(2, proxy.Count);
            Assert.AreEqual(capsuleShape.Radius, proxy.Radius);
            Assert.AreEqual(capsuleShape.Center1, proxy.Points[0]);
            Assert.AreEqual(capsuleShape.Center2, proxy.Points[1]);
        }

        [TestMethod]
        public void ShapeGeometry_ToProxy_ConvertsSegmentShape()
        {
            var segmentShape = new SegmentShape(new Vec2(1.0f, 2.0f), new Vec2(3.0f, 4.0f));
            var proxy = ShapeGeometry.ToProxy(segmentShape);

            Assert.IsNotNull(proxy);
            Assert.AreEqual(2, proxy.Count);
            Assert.AreEqual(Constants.PolygonRadius, proxy.Radius);
            Assert.AreEqual(segmentShape.Point1, proxy.Points[0]);
            Assert.AreEqual(segmentShape.Point2, proxy.Points[1]);
        }

        [TestMethod]
        public void ShapeGeometry_ComputeAabb_CircleShape()
        {
            var circleShape = new CircleShape(new Vec2(1.0f, 2.0f), 3.0f);
            var transform = new Transform(new Vec2(0.0f, 0.0f), new Rot(0.0f));
            var aabb = ShapeGeometry.ComputeAabb(circleShape, transform);

            Assert.IsNotNull(aabb);
        }

        [TestMethod]
        public void ShapeGeometry_ComputeAabb_CapsuleShape()
        {
            var capsuleShape = new CapsuleShape(new Vec2(1.0f, 2.0f), new Vec2(3.0f, 4.0f), 2.0f);
            var transform = new Transform(new Vec2(0.0f, 0.0f), new Rot(0.0f));
            var aabb = ShapeGeometry.ComputeAabb(capsuleShape, transform);

            Assert.IsNotNull(aabb);
        }

        [TestMethod]
        public void ShapeGeometry_ComputeAabb_SegmentShape()
        {
            var segmentShape = new SegmentShape(new Vec2(1.0f, 2.0f), new Vec2(3.0f, 4.0f));
            var transform = new Transform(new Vec2(0.0f, 0.0f), new Rot(0.0f));
            var aabb = ShapeGeometry.ComputeAabb(segmentShape, transform);

            Assert.IsNotNull(aabb);
        }
    }
}
