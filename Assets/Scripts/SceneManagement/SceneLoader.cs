using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneAmount = 1;
    public int roomMaxSizeX = 20;
    public int roomMaxSizeY = 20;
    public int roomMinSizeY = 20;
    public int roomMinSizeX = 20;
    private bool firstTimeLoad = true;
    
    
    public void StartGame()
    {

        GameObject loadingScreen = Resources.Load("loadingScreen") as GameObject;
        Instantiate(loadingScreen);

        Time.timeScale = 1f;

        var roomGenerator = gameObject.AddComponent<RoomGenerator>();
        var foo = roomGenerator.StartGame(sceneAmount, roomMaxSizeX, roomMaxSizeY, roomMinSizeY, roomMinSizeX);


        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "New Game Object");
        foreach (var obj in objects)
        {
            Destroy(obj);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("bossHuone", LoadSceneMode.Additive);
        SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
        SceneManager.LoadScene("First Room", LoadSceneMode.Additive);
        firstTimeLoad = false;

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "First Room")
        {
            SceneManager.SetActiveScene(scene);
        }
        if (scene.name == "bossHuone" && !firstTimeLoad)
        {
            GameObject[] rootGameObjects = scene.GetRootGameObjects();

            foreach (var obj in rootGameObjects)
            {
                obj.SetActive(false);
            }
        }
    }
}