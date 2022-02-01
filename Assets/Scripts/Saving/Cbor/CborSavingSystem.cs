#if ANDROMEDA_SERIALIZER_CBOR
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
            GameState state = new GameState();
            string saveFilePath = GetPathFromSaveFile(saveFile);

            if (!File.Exists(saveFilePath)) return state;

            byte[] bytes = File.ReadAllBytes(saveFilePath);
            if (bytes == null) return state;

            state = Dahomey.Cbor.Cbor.Deserialize<GameState>(bytes);

            return state;
        }

        protected override void SaveFile(string saveFile, GameState state)
        {
            string saveFilePath = GetPathFromSaveFile(saveFile);

            byte[] bytes = null;
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
