#if ANDROMEDA_SERIALIZER_CBOR
using Dahomey.Cbor.Util;
using NUnit.Framework;
using UnityEngine;
using DahomeyCbor = Dahomey.Cbor.Cbor;

namespace Andromeda.Tests.Cbor
{
    public class CborAnimationCurveTypes
    {
        [Test]
        public void ConvertKeyframe()
        {
            Keyframe keyframe = new Keyframe(Random.Range(0.0f, 10.0f), Mathf.PI);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(keyframe, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Keyframe deserialized = DahomeyCbor.Deserialize<Keyframe>(bytes);

            Assert.AreEqual(keyframe, deserialized);
        }

        [Test]
        public void ConvertAnimationCurve()
        {
            AnimationCurve curve = AnimationCurve.EaseInOut(0.0f, 0.5f, 5.0f, Mathf.PI);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(curve, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            AnimationCurve deserialized = DahomeyCbor.Deserialize<AnimationCurve>(bytes);

            Assert.AreEqual(curve, deserialized);
        }
    }
}
#endif // ANDROMEDA_SERIALIZER_CBOR
