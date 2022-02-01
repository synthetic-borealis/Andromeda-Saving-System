#if ANDROMEDA_SERIALIZER_CBOR
using Dahomey.Cbor.Util;
using NUnit.Framework;
using UnityEngine;
using DahomeyCbor = Dahomey.Cbor.Cbor;

namespace Andromeda.Tests.Cbor
{
    public class CborPhysicsTypes
    {
        [Test]
        public void ConvertRay()
        {
            Ray ray = new Ray(Vector3.zero, Vector3.left * Mathf.PI);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(ray, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Ray deserialized = DahomeyCbor.Deserialize<Ray>(bytes);

            Assert.AreEqual(ray, deserialized);
        }

        [Test]
        public void ConvertRay2D()
        {
            Ray2D ray = new Ray2D(Vector2.one, Vector2.left + Vector2.down);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(ray, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Ray2D deserialized = DahomeyCbor.Deserialize<Ray2D>(bytes);

            Assert.AreEqual(ray, deserialized);
        }

        [Test]
        public void ConvertLayerMask()
        {
            LayerMask layerMask = LayerMask.NameToLayer("Default");

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(layerMask, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            LayerMask deserialized = DahomeyCbor.Deserialize<LayerMask>(bytes);

            Assert.AreEqual(layerMask, deserialized);
        }
    }
}
#endif // ANDROMEDA_SERIALIZER_CBOR
