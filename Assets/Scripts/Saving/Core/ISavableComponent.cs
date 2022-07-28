namespace Andromeda.Saving
{
    public interface ISavableComponent
    {
        ComponentState CaptureState();
        void RestoreState(ComponentState state);
    }
}