using System.Collections.Generic;

namespace Andromeda.Saving
{
    public class EntityState
    {
        public Dictionary<string, ComponentState> components = new();
    }
}