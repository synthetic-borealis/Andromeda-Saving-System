namespace Andromeda.Saving
{
#if ANDROMEDA_SERIALIZER_CBOR
    public class SavingSystem : Cbor.CborSavingSystem
    {
    }
#else
    public class SavingSystem : SavingSystemBase
    {
        protected override GameState LoadFile(string saveFile)
        {
            throw new System.NotImplementedException();
        }

        protected override void SaveFile(string saveFile, GameState state)
        {
            throw new System.NotImplementedException();
        }
    }
#endif // ANDROMEDA_SERIALIZER_CBOR
}