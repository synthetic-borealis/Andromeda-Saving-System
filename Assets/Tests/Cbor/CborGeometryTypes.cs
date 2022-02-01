#if ANDROMEDA_SERIALIZER_CBOR
using Dahomey.Cbor.Util;
using NUnit.Framework;
using UnityEngine;
using DahomeyCbor = Dahomey.Cbor.Cbor;

namespace Andromeda.Tests.Cbor
{
    public class CborGeometryTypes
    {
        [Test]
        public void ConvertBounds()
        {
            Bounds bounds = new Bounds(Vector3.zero, Vector3.one);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(bounds, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Bounds deserialized = DahomeyCbor.Deserialize<Bounds>(bytes);

            Assert.AreEqual(bounds, deserialized);
        }

        [Test]
        public void ConvertBoundsInt()
        {
            BoundsInt bounds = new BoundsInt(Vector3Int.zero, Vector3Int.one);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(bounds, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            BoundsInt deserialized = DahomeyCbor.Deserialize<BoundsInt>(bytes);

            Assert.AreEqual(bounds, deserialized);
        }

        [Test]
        public void ConvertBoundingSphere()
        {
            BoundingSphere bounds = new BoundingSphere(Vector3.zero, 2f);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(bounds, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            BoundingSphere deserialized = DahomeyCbor.Deserialize<BoundingSphere>(bytes);

            Assert.AreEqual(bounds, deserialized);
        }

        [Test]
        public void ConvertRect()
        {
            Rect rect = new Rect(0, 0, 2, 2);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(rect, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Rect deserialized = DahomeyCbor.Deserialize<Rect>(bytes);

            Assert.AreEqual(rect, deserialized);
        }

        [Test]
        public void ConvertRectInt()
        {
            RectInt rect = new RectInt(-1, 0, 2, 8);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(rect, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            RectInt deserialized = DahomeyCbor.Deserialize<RectInt>(bytes);

            Assert.AreEqual(rect, deserialized);
        }

        [Test]
        public void ConvertRectOffset()
        {
            RectOffset rectOffset = new RectOffset(1, 0, 2, 8);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(rectOffset, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            RectOffset deserialized = DahomeyCbor.Deserialize<RectOffset>(bytes);

            Assert.AreEqual(rectOffset.ToString(), deserialized.ToString());
        }

        [Test]
        public void ConvertPlane()
        {
            Plane plane = new Plane(
                new Vector3(Random.Range(1f, Mathf.PI), Random.Range(1f, Mathf.PI), Random.Range(1f, Mathf.PI)), Mathf.PI
                );

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(plane, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Plane deserialized = DahomeyCbor.Deserialize<Plane>(bytes);

            Assert.AreEqual(plane, deserialized);
        }
    }
}
#endif // ANDROMEDA_SERIALIZER_CBOR
