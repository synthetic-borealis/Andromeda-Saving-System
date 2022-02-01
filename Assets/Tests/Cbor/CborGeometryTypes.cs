#if ANDROMEDA_SERIALIZER_CBOR
using System.Collections;
using System.Collections.Generic;
using Dahomey.Cbor.Util;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

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
                Dahomey.Cbor.Cbor.Serialize(bounds, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Bounds deserialized = Dahomey.Cbor.Cbor.Deserialize<Bounds>(bytes);

            Assert.AreEqual(bounds, deserialized);
        }

        [Test]
        public void ConvertBoundsInt()
        {
            BoundsInt bounds = new BoundsInt(Vector3Int.zero, Vector3Int.one);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(bounds, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            BoundsInt deserialized = Dahomey.Cbor.Cbor.Deserialize<BoundsInt>(bytes);

            Assert.AreEqual(bounds, deserialized);
        }

        [Test]
        public void ConvertBoundingSphere()
        {
            BoundingSphere bounds = new BoundingSphere(Vector3.zero, 2f);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(bounds, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            BoundingSphere deserialized = Dahomey.Cbor.Cbor.Deserialize<BoundingSphere>(bytes);

            Assert.AreEqual(bounds, deserialized);
        }

        [Test]
        public void ConvertRect()
        {
            Rect rect = new Rect(0 , 0, 2, 2);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(rect, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Rect deserialized = Dahomey.Cbor.Cbor.Deserialize<Rect>(bytes);

            Assert.AreEqual(rect, deserialized);
        }

        [Test]
        public void ConvertRectInt()
        {
            RectInt rect = new RectInt(-1, 0, 2, 8);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(rect, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            RectInt deserialized = Dahomey.Cbor.Cbor.Deserialize<RectInt>(bytes);

            Assert.AreEqual(rect, deserialized);
        }

        [Test]
        public void ConvertRectOffset()
        {
            RectOffset rectOffset = new RectOffset(1, 0, 2, 8);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(rectOffset, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            RectOffset deserialized = Dahomey.Cbor.Cbor.Deserialize<RectOffset>(bytes);

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
                Dahomey.Cbor.Cbor.Serialize(plane, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Plane deserialized = Dahomey.Cbor.Cbor.Deserialize<Plane>(bytes);

            Assert.AreEqual(plane, deserialized);
        }
    } 
}
#endif // ANDROMEDA_SERIALIZER_CBOR
