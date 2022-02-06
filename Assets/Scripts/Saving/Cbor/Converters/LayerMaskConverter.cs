#if ANDROMEDA_SERIALIZER_CBOR||UNITY_EDITOR
using Dahomey.Cbor.Serialization;
using Dahomey.Cbor.Serialization.Converters;
using UnityEngine;

namespace Andromeda.Saving.Cbor
{
    public class LayerMaskConverter : CborConverterBase<LayerMask>
    {
        public override LayerMask Read(ref CborReader reader)
        {
            LayerMask layerMask = new LayerMask();
            layerMask.value = reader.ReadInt32();
            return layerMask;
        }

        public override void Write(ref CborWriter writer, LayerMask value)
        {
            writer.WriteInt32(value.value);
        }
    }
}
#endif
