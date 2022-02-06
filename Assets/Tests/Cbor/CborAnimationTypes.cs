#if ANDROMEDA_SERIALIZER_CBOR
using Dahomey.Cbor.Util;
using NUnit.Framework;
using UnityEngine;
using DahomeyCbor = Dahomey.Cbor.Cbor;

namespace Andromeda.Tests.Cbor
{
    public class CborAnimationTypes
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

            Assert.IsTrue(Mathf.Approximately(keyframe.time, deserialized.time));
            Assert.IsTrue(Mathf.Approximately(keyframe.value, deserialized.value));
            Assert.IsTrue(Mathf.Approximately(keyframe.inTangent, deserialized.inTangent));
            Assert.IsTrue(Mathf.Approximately(keyframe.outTangent, deserialized.outTangent));
            Assert.IsTrue(Mathf.Approximately(keyframe.inWeight, deserialized.inWeight));
            Assert.IsTrue(Mathf.Approximately(keyframe.outWeight, deserialized.outWeight));
            Assert.AreEqual(keyframe.weightedMode, deserialized.weightedMode);
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

            for (float i = 0.0f; i <= 5.0f; i += 0.25f)
            {
                float originalVal = curve.Evaluate(i);
                float deserializedVal = deserialized.Evaluate(i);
                Assert.IsTrue(Mathf.Approximately(originalVal, deserializedVal));
            }
        }
    }
}
#endif // ANDROMEDA_SERIALIZER_CBOR
