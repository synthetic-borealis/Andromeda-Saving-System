namespace Andromeda.Saving
{
    public interface ISaveableComponent
    {
        ComponentState CaptureState();
        void RestoreState(ComponentState state);
    }
}
