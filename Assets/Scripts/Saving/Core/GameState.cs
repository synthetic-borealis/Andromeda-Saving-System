using System.Collections.Generic;

namespace Andromeda.Saving
{
    public class GameState
    {
        public int lastSceneBuildIndex;
        public Dictionary<string, EntityState> entities = new Dictionary<string, EntityState>();
    }
}
