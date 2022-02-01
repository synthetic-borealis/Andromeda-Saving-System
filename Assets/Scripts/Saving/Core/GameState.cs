using System.Collections.Generic;

namespace Andromeda.Saving
{
    public class GameState
    {
        public int lastSceneBuildIndex = -1;
        public Dictionary<string, EntityState> entities = new Dictionary<string, EntityState>();
    }
}
