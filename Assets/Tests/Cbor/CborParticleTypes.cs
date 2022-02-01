#if ANDROMEDA_SERIALIZER_CBOR
using Dahomey.Cbor.Util;
using NUnit.Framework;
using UnityEngine;
using DahomeyCbor = Dahomey.Cbor.Cbor;

namespace Andromeda.Tests.Cbor
{
    public class CborParticleTypes
    {
        [Test]
        public void ConvertParticle()
        {
            ParticleSystem.Particle particle = new ParticleSystem.Particle
            {
                velocity = Random.rotation.eulerAngles,
                angularVelocity = Random.Range(0.5f, 100.0f),
                angularVelocity3D = (Vector3.forward + Vector3.up + Vector3.right) * Random.Range(0.5f, 100.0f),
                axisOfRotation = Vector3.forward,
                position = Vector3.zero,
                rotation = Random.Range(0.5f, 100.0f),
                rotation3D = Random.rotation.eulerAngles,
                randomSeed = (uint)Random.Range(0.0f, 650.0f),
                remainingLifetime = 0.5f,
                startColor = Color.red,
                startLifetime = 15.0f,
                startSize = Random.Range(2.0f, 15.0f),
                startSize3D = (Vector3.forward + Vector3.up + Vector3.right) * Random.Range(0.5f, 100.0f),
            };

            byte[] bytes = null;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                DahomeyCbor.Serialize(particle, writer);
                bytes = writer.WrittenSpan.ToArray();
            }

            var deserialized = DahomeyCbor.Deserialize<ParticleSystem.Particle>(bytes);

            Assert.AreEqual(particle, deserialized);
        }
    }
}
#endif
