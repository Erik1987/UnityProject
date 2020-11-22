using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Player
{
    public class TrackedScenes : MonoBehaviour
    {
        public Scene PreviousScene { get => GetPreviousRoomScene(); }
        public Scene NextScene { get => GetNextRoomScene(); }
        public Scene StoreScene { get => GetStoreScene(); }
        public Scene BossScene { get => GetBossScene(); }
        public Scene OriginalScene { get; set; }
        public List<Scene> RoomScenes { get; set; } = new List<Scene>();

        public void CacheAllRoomScenes()
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i).name.StartsWith("Scene"))
                {
                    RoomScenes.Add(SceneManager.GetSceneAt(i));
                }
            }
       }

        private Scene GetNextRoomScene()
        {
            Scene result = SceneManager.GetActiveScene();
            
            if(SceneManager.GetActiveScene().name == "bossHuone")
            {
                var originalScene = RoomScenes.FindIndex(s => s == OriginalScene);
                result = RoomScenes[originalScene + 1];
            }
            else
            {
                var currentScene = RoomScenes.FindIndex(s => s == SceneManager.GetActiveScene());
                result = RoomScenes[currentScene + 1];
            }

            return result;
        }

        private Scene GetPreviousRoomScene()
        {
            var nextScene = RoomScenes.FindIndex(s => s == SceneManager.GetActiveScene());
            return RoomScenes[nextScene - 1];
        }

        private Scene GetStoreScene()
        {
            return SceneManager.GetSceneByName("Shop");
        }

        private Scene GetBossScene()
        {
            return SceneManager.GetSceneByName("bossHuone");
        }
    }
}