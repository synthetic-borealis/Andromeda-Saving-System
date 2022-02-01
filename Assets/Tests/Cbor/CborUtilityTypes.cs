#if ANDROMEDA_SERIALIZER_CBOR
using Dahomey.Cbor.Util;
using NUnit.Framework;
using UnityEngine;
using DahomeyCbor = Dahomey.Cbor.Cbor;

namespace Andromeda.Tests.Cbor
{
    public class CborUtilityTypes
    {
        [Test]
        public void ConvertRangeInt()
        {
            RangeInt rangeInt = new RangeInt(2, 15);

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(rangeInt, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            RangeInt deserialized = DahomeyCbor.Deserialize<RangeInt>(bytes);

            Assert.AreEqual(rangeInt, deserialized);
        }
    }
}
#endif // ANDROMEDA_SERIALIZER_CBOR
