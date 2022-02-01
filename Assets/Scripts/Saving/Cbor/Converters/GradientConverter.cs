#if ANDROMEDA_SERIALIZER_CBOR
using Dahomey.Cbor.Serialization;
using Dahomey.Cbor.Serialization.Converters;
using Dahomey.Cbor.Util;
using UnityEngine;

namespace Andromeda.Saving.Cbor
{
    public class GradientConverter : CborConverterBase<Gradient>
    {
        public override Gradient Read(ref CborReader reader)
        {
            byte[] colorKeyBytes = reader.ReadByteString().ToArray();
            byte[] alphaKeyBytes = reader.ReadByteString().ToArray();
            int gradientMode = reader.ReadInt32();

            GradientColorKey[] colorKeys = Dahomey.Cbor.Cbor.Deserialize<GradientColorKey[]>(colorKeyBytes);
            GradientAlphaKey[] alphaKeys = Dahomey.Cbor.Cbor.Deserialize<GradientAlphaKey[]>(alphaKeyBytes);

            Gradient gradient = new Gradient();
            gradient.mode = (GradientMode)gradientMode;
            gradient.SetKeys(colorKeys, alphaKeys);

            return gradient;
        }

        public override void Write(ref CborWriter writer, Gradient value)
        {
            byte[] colorKeyBytes = null;
            byte[] alphaKeyBytes = null;

            using (ByteBufferWriter bufferWriter = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(value.colorKeys, bufferWriter);
                colorKeyBytes = bufferWriter.WrittenSpan.ToArray();
                bufferWriter.Dispose();
                Dahomey.Cbor.Cbor.Serialize(value.alphaKeys, bufferWriter);
                alphaKeyBytes = bufferWriter.WrittenSpan.ToArray();
            }

            writer.WriteByteString(colorKeyBytes);
            writer.WriteByteString(alphaKeyBytes);
            writer.WriteInt32((int)value.mode);
        }
    }
}
#endif
