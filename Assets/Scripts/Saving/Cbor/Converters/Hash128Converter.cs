#if ANDROMEDA_SERIALIZER_CBOR||UNITY_EDITOR
using Dahomey.Cbor.Serialization;
using Dahomey.Cbor.Serialization.Converters;
using System.Text;
using UnityEngine;

namespace Andromeda.Saving.Cbor
{
    public class Hash128Converter : CborConverterBase<Hash128>
    {
        public override Hash128 Read(ref CborReader reader)
        {
            byte[] hashBytes = reader.ReadByteString().ToArray();
            string hashStr = Encoding.UTF8.GetString(hashBytes);

            return Hash128.Parse(hashStr);
        }

        public override void Write(ref CborWriter writer, Hash128 value)
        {
            byte[] hashBytes = Encoding.UTF8.GetBytes(value.ToString());

            writer.WriteByteString(hashBytes);
        }
    }
}
#endif
