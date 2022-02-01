#if ANDROMEDA_SERIALIZER_CBOR
using Dahomey.Cbor.Serialization;
using Dahomey.Cbor.Serialization.Converters;
using Dahomey.Cbor.Util;
using UnityEngine;

namespace Andromeda.Saving.Cbor
{
    public class AnimationCurveConverter : CborConverterBase<AnimationCurve>
    {
        public override AnimationCurve Read(ref CborReader reader)
        {
            byte[] keyframeBytes = reader.ReadByteString().ToArray();
            Keyframe[] keyframes = Dahomey.Cbor.Cbor.Deserialize<Keyframe[]>(keyframeBytes);

            return new AnimationCurve(keyframes);
        }

        public override void Write(ref CborWriter writer, AnimationCurve value)
        {
            byte[] keyframeBytes = null;

            using (ByteBufferWriter bufferWriter = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(value.keys, bufferWriter);
                keyframeBytes = bufferWriter.WrittenSpan.ToArray();
            }

            writer.WriteByteString(keyframeBytes);
        }
    }
}
#endif
