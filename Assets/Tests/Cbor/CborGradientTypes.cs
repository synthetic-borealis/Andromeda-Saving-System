#if ANDROMEDA_SERIALIZER_CBOR
using Dahomey.Cbor.Util;
using NUnit.Framework;
using UnityEngine;
using DahomeyCbor = Dahomey.Cbor.Cbor;

namespace Andromeda.Tests.Cbor
{
    public class CborGradientTypes
    {
        [Test]
        public void ConvertGradientAlphaKey()
        {
            GradientAlphaKey alphaKey = new GradientAlphaKey(0.2f, 5.0f);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(alphaKey, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            GradientAlphaKey deserialized = DahomeyCbor.Deserialize<GradientAlphaKey>(bytes);

            Assert.AreEqual(alphaKey, deserialized);
        }

        [Test]
        public void ConvertGradientColorKey()
        {
            GradientColorKey colorKey = new GradientColorKey(Color.cyan, Mathf.PI);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(colorKey, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            GradientColorKey deserialized = DahomeyCbor.Deserialize<GradientColorKey>(bytes);

            Assert.AreEqual(colorKey, deserialized);
        }

        [Test]
        public void ConvertGradient()
        {
            Gradient gradient = new Gradient();
            GradientColorKey[] colorKeys = new GradientColorKey[2];
            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];

            colorKeys[0].color = Color.red;
            colorKeys[0].time = 0.0f;
            colorKeys[1].color = Color.blue;
            colorKeys[1].time = 1.0f;
            alphaKeys[0].alpha = 1.0f;
            alphaKeys[0].time = 0.0f;
            alphaKeys[1].alpha = 0.0f;
            alphaKeys[1].time = 1.0f;

            gradient.SetKeys(colorKeys, alphaKeys);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(gradient, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Gradient deserialized = DahomeyCbor.Deserialize<Gradient>(bytes);

            Assert.AreEqual(gradient, deserialized);
        }
    }
}
#endif // ANDROMEDA_SERIALIZER_CBOR
