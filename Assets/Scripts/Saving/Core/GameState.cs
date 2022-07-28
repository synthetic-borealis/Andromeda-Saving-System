using System;
using System.Collections.Generic;

namespace Andromeda.Saving
{
    public class GameState
    {
        public class SaveGameMetadata
        {
            public int Version { get; set; } = 0;
            public DateTime CreationTime { get; set; } = DateTime.Now;
        }

        public SaveGameMetadata metadata = new();
        
        public int lastSceneBuildIndex = -1;
        public Dictionary<string, EntityState> entities = new();
    }
}