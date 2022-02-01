#if ANDROMEDA_SERIALIZER_CBOR
using Dahomey.Cbor.Util;
using NUnit.Framework;
using UnityEngine;
using DahomeyCbor = Dahomey.Cbor.Cbor;

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
                DahomeyCbor.Serialize(vector, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Vector2 deserialized = DahomeyCbor.Deserialize<Vector2>(bytes);

            Assert.AreEqual(vector, deserialized);
        }

        [Test]
        public void ConvertVector2Int()
        {
            Vector2Int vector = Vector2Int.left + Vector2Int.up;

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(vector, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Vector2Int deserialized = DahomeyCbor.Deserialize<Vector2Int>(bytes);

            Assert.AreEqual(vector, deserialized);
        }

        [Test]
        public void ConvertVector3()
        {
            Vector3 vector = new Vector3(Mathf.PI, Mathf.Exp(1f), -2.5f);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(vector, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Vector3 deserialized = DahomeyCbor.Deserialize<Vector3>(bytes);

            Assert.AreEqual(vector, deserialized);
        }

        [Test]
        public void ConvertVector3Int()
        {
            Vector3Int vector = Vector3Int.up + Vector3Int.right + Vector3Int.forward;

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(vector, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Vector3Int deserialized = DahomeyCbor.Deserialize<Vector3Int>(bytes);

            Assert.AreEqual(vector, deserialized);
        }

        [Test]
        public void ConvertVector4()
        {
            Vector4 vector = new Vector4(Mathf.PI, Mathf.Exp(1f), -2.5f, 0.5f);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(vector, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Vector4 deserialized = DahomeyCbor.Deserialize<Vector4>(bytes);

            Assert.AreEqual(vector, deserialized);
        }

        [Test]
        public void ConvertQuaternion()
        {
            Quaternion quaternion = new Quaternion(Mathf.PI, Mathf.Exp(1f), -2.5f, 0.5f);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(quaternion, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Quaternion deserialized = DahomeyCbor.Deserialize<Quaternion>(bytes);

            Assert.AreEqual(quaternion, deserialized);
        }

        [Test]
        public void ConvertMatrix4x4()
        {
            Matrix4x4 matrix = new Matrix4x4(Vector4.one, Vector4.one * Mathf.PI, Vector4.zero, -Vector4.one);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(matrix, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Matrix4x4 deserialized = DahomeyCbor.Deserialize<Matrix4x4>(bytes);

            Assert.AreEqual(matrix, deserialized);
        }

        [Test]
        public void ConvertColor()
        {
            Color color = Color.magenta;

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(color, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Color deserialized = DahomeyCbor.Deserialize<Color>(bytes);

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
                DahomeyCbor.Serialize(color32, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Color32 deserialized = DahomeyCbor.Deserialize<Color32>(bytes);

            Assert.AreEqual(color32, deserialized);
        }
    }
}
#endif
