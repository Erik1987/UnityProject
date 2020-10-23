using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneAmount = 1;
    public int roomMaxSizeX = 20;
    public int roomMaxSizeY = 20;
    public int roomMinSizeY = 20;
    public int roomMinSizeX = 20;

    public void StartGame()
    {
        Time.timeScale = 1f;

        var roomGenerator = gameObject.AddComponent<RoomGenerator>();
        roomGenerator.StartGame(sceneAmount, roomMaxSizeX, roomMaxSizeY, roomMinSizeY, roomMinSizeX);

        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "New Game Object");
        foreach (var obj in objects)
        {
            Destroy(obj);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("First Room", LoadSceneMode.Additive);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
    }
}