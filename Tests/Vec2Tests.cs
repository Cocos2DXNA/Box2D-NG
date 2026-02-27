using Microsoft.VisualStudio.TestTools.UnitTesting;
using Box2DNG;

namespace Box2DNG.Tests
{
    [TestClass]
    public class Vec2Tests
    {
        [TestMethod]
        public void Vec2_Constructor_InitializesCorrectly()
        {
            var vec = new Vec2(1.0f, 2.0f);
            Assert.AreEqual(1.0f, vec.X);
            Assert.AreEqual(2.0f, vec.Y);
        }

        [TestMethod]
        public void Vec2_Zero_ReturnsZeroVector()
        {
            Assert.AreEqual(new Vec2(0.0f, 0.0f), Vec2.Zero);
        }

        [TestMethod]
        public void Vec2_Length_CalculatesCorrectly()
        {
            var vec = new Vec2(3.0f, 4.0f);
            Assert.AreEqual(5.0f, vec.Length, 0.001f);
        }

        [TestMethod]
        public void Vec2_LengthSquared_CalculatesCorrectly()
        {
            var vec = new Vec2(3.0f, 4.0f);
            Assert.AreEqual(25.0f, vec.LengthSquared);
        }

        [TestMethod]
        public void Vec2_Equals_ReturnsTrueForEqualVectors()
        {
            var vec1 = new Vec2(1.0f, 2.0f);
            var vec2 = new Vec2(1.0f, 2.0f);
            Assert.IsTrue(vec1.Equals(vec2));
        }

        [TestMethod]
        public void Vec2_Equals_ReturnsFalseForDifferentVectors()
        {
            var vec1 = new Vec2(1.0f, 2.0f);
            var vec2 = new Vec2(2.0f, 3.0f);
            Assert.IsFalse(vec1.Equals(vec2));
        }
    }
}