using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Andromeda.Saving
{
    public abstract class SavingSystemBase : MonoBehaviour
    {
        protected const string LastSceneIndexKey = "lastSceneBuildIndex";

        [SerializeField] private string saveExtension = "sav";

        public string SaveExtension
        {
            get { return saveExtension; }
        }

        [SerializeField] private string saveDirectory = "savedGames";

        public string SaveDirectory
        {
            get { return saveDirectory; }
        }

        private SavableEntity[] _savableEntities;

        private void Awake()
        {
            _savableEntities = FindObjectsOfType<SavableEntity>();
        }

        private string GetPathFromSaveDirectory()
        {
            return Path.Combine(Application.persistentDataPath, saveDirectory);
        }

        protected string GetPathFromSaveFile(string saveFile)
        {
            return Path.Combine(GetPathFromSaveDirectory(), saveFile + "." + saveExtension);
        }

        public IEnumerator LoadLastScene(string saveFile)
        {
            GameState state = LoadFile(saveFile);

            int savedSceneIndex = state.lastSceneBuildIndex;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if ((savedSceneIndex != currentSceneIndex) && (savedSceneIndex != -1))
            {
                yield return SceneManager.LoadSceneAsync(savedSceneIndex);
            }

            RestoreState(state);
        }

        public void Save(string saveFile)
        {
            GameState state = new();

            CaptureState(state);
            Directory.CreateDirectory(GetPathFromSaveDirectory());
            SaveFile(saveFile, state);
        }

        public void Load(string saveFile)
        {
            RestoreState(LoadFile(saveFile));
        }

        private void CaptureState(GameState state)
        {
            state.lastSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

            foreach (SavableEntity entity in _savableEntities)
            {
                state.entities[entity.UniqueIdentifier] = entity.CaptureState();
            }
        }

        private void RestoreState(GameState state)
        {
            foreach (SavableEntity entity in _savableEntities)
            {
                string entityId = entity.UniqueIdentifier;

                if (state.entities.ContainsKey(entityId))
                {
                    entity.RestoreState(state.entities[entityId]);
                }
            }
        }

        protected abstract GameState LoadFile(string saveFile);
        protected abstract void SaveFile(string saveFile, GameState state);
    }
}