using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Andromeda.Saving
{
    public abstract class SavingSystemBase : MonoBehaviour
    {
        protected const string LastSceneIndexKey = "lastSceneBuildIndex";

        [SerializeField]
        private string _saveExtension = "sav";
        public string saveExtension { get { return _saveExtension; } }

        [SerializeField]
        private string _saveDirectory = "savegames";
        public string saveDirectory { get { return _saveDirectory; } }

        protected string GetPathFromSaveDirectory()
        {
            return Path.Combine(Application.persistentDataPath, _saveDirectory);
        }

        protected string GetPathFromSaveFile(string saveFile)
        {
            return Path.Combine(GetPathFromSaveDirectory(), saveFile + "." + _saveExtension);
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
            GameState state = new GameState();

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

            foreach (SaveableEntity entity in FindObjectsOfType<SaveableEntity>())
            {
                state.entities[entity.uniqueIdentifier] = entity.CaptureState();
            }
        }

        private void RestoreState(GameState state)
        {
            foreach (SaveableEntity entity in FindObjectsOfType<SaveableEntity>())
            {
                string entityId = entity.uniqueIdentifier;

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
