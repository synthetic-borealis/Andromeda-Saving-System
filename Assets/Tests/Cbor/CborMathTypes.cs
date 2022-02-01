#if ANDROMEDA_SERIALIZER_CBOR
using Dahomey.Cbor.Util;
using NUnit.Framework;
using UnityEngine;

namespace Andromeda.Tests.Cbor
{
    public class CborMathTypes
    {
        [Test]
        public void ConvertVector2()
        {
            Vector2 vector = new Vector2(Mathf.PI, Mathf.Exp(1f));

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(vector, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Vector2 deserialized = Dahomey.Cbor.Cbor.Deserialize<Vector2>(bytes);

            Assert.AreEqual(vector, deserialized);
        }

        [Test]
        public void ConvertVector2Int()
        {
            Vector2Int vector = Vector2Int.left + Vector2Int.up;

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(vector, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Vector2Int deserialized = Dahomey.Cbor.Cbor.Deserialize<Vector2Int>(bytes);

            Assert.AreEqual(vector, deserialized);
        }

        [Test]
        public void ConvertVector3()
        {
            Vector3 vector = new Vector3(Mathf.PI, Mathf.Exp(1f), -2.5f);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(vector, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Vector3 deserialized = Dahomey.Cbor.Cbor.Deserialize<Vector3>(bytes);

            Assert.AreEqual(vector, deserialized);
        }

        [Test]
        public void ConvertVector3Int()
        {
            Vector3Int vector = Vector3Int.up + Vector3Int.right + Vector3Int.forward;

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(vector, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Vector3Int deserialized = Dahomey.Cbor.Cbor.Deserialize<Vector3Int>(bytes);

            Assert.AreEqual(vector, deserialized);
        }

        [Test]
        public void ConvertVector4()
        {
            Vector4 vector = new Vector4(Mathf.PI, Mathf.Exp(1f), -2.5f, 0.5f);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(vector, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Vector4 deserialized = Dahomey.Cbor.Cbor.Deserialize<Vector4>(bytes);

            Assert.AreEqual(vector, deserialized);
        }

        [Test]
        public void ConvertQuaternion()
        {
            Quaternion quaternion = new Quaternion(Mathf.PI, Mathf.Exp(1f), -2.5f, 0.5f);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(quaternion, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Quaternion deserialized = Dahomey.Cbor.Cbor.Deserialize<Quaternion>(bytes);

            Assert.AreEqual(quaternion, deserialized);
        }

        [Test]
        public void ConvertMatrix4x4()
        {
            Matrix4x4 matrix = new Matrix4x4(Vector4.one, Vector4.one * Mathf.PI, Vector4.zero, -Vector4.one);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(matrix, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Matrix4x4 deserialized = Dahomey.Cbor.Cbor.Deserialize<Matrix4x4>(bytes);

            Assert.AreEqual(matrix, deserialized);
        }

        [Test]
        public void ConvertColor()
        {
            Color color = Color.magenta;

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(color, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Color deserialized = Dahomey.Cbor.Cbor.Deserialize<Color>(bytes);

            Assert.AreEqual(color, deserialized);
        }

        [Test]
        public void ConvertColor32()
        {
            Color color = Color.magenta;
            Color32 color32 = color;

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(color32, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Color32 deserialized = Dahomey.Cbor.Cbor.Deserialize<Color32>(bytes);

            Assert.AreEqual(color32, deserialized);
        }
    }
}
#endif
