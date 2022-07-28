#if ANDROMEDA_SERIALIZER_CBOR||UNITY_EDITOR
using Dahomey.Cbor;
using Dahomey.Cbor.Util;
using System.IO;
using UnityEngine;

namespace Andromeda.Saving.Cbor
{
    [AddComponentMenu("")]
    public class CborSavingSystem : SavingSystemBase
    {
        protected override GameState LoadFile(string saveFile)
        {
            string saveFilePath = GetPathFromSaveFile(saveFile);

            if (!File.Exists(saveFilePath)) return new();

            byte[] bytes = File.ReadAllBytes(saveFilePath);
            if (bytes.Length == 0) return new();

            GameState state = Dahomey.Cbor.Cbor.Deserialize<GameState>(bytes);

            return state ?? new();
        }

        protected override void SaveFile(string saveFile, GameState state)
        {
            string saveFilePath = GetPathFromSaveFile(saveFile);

            byte[] bytes;
            using (ByteBufferWriter writer = new ByteBufferWriter())
            {
                Dahomey.Cbor.Cbor.Serialize(state, writer, CborOptions.Default);
                bytes = writer.WrittenSpan.ToArray();
            }

            using (FileStream stream = File.Open(saveFilePath, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(bytes);
                }
            }
        }
    }
}
#endif // ANDROMEDA_SERIALIZER_CBOR