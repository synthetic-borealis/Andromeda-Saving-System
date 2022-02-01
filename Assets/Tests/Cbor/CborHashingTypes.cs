#if ANDROMEDA_SERIALIZER_CBOR
using Dahomey.Cbor.Util;
using NUnit.Framework;
using UnityEngine;
using DahomeyCbor = Dahomey.Cbor.Cbor;

namespace Andromeda.Tests.Cbor
{
    public class CborHashingTypes
    {
        [Test]
        public void ConvertHash128()
        {
            Hash128 hash128 = new Hash128(
                    (uint)Random.Range(0, 2048),
                    (uint)Random.Range(0, 2048),
                    (uint)Random.Range(0, 2048),
                    (uint)Random.Range(0, 2048)
                );

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(hash128, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            Hash128 deserialized = DahomeyCbor.Deserialize<Hash128>(bytes);

            Assert.AreEqual(hash128, deserialized);
        }
    }
}
#endif // ANDROMEDA_SERIALIZER_CBOR
