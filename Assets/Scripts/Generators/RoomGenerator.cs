using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Assets.Scripts.Models;

public class RoomGenerator : MonoBehaviour
{
    private readonly int tileSize = 1;
    private int floorNumber = 1;
    private int difficulty = 1;
    public readonly List<GameObject> tiles = new List<GameObject>();
    private int roomSizeX;
    private int roomSizeY;

    public void StartGame(int sceneAmount, int roomMaxSizeX, int roomMaxSizeY, int roomMinSizeY, int roomMinSizeX)
    {
        for (int i = 0; i < sceneAmount; i++)
        {
            roomSizeX = new System.Random().Next(roomMinSizeY, roomMaxSizeX);
            roomSizeY = new System.Random().Next(roomMinSizeX, roomMaxSizeY);

            SceneManager.MoveGameObjectToScene(GenerateRoom(), SceneManager.CreateScene("Scene " + floorNumber));

            floorNumber++;
            difficulty++;
        }
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    /// <summary>Do thingy</summary>
    private void OnActiveSceneChanged(Scene scene1, Scene scene2)
    {
        Scene activeScene = SceneManager.GetActiveScene();

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);

            GameObject[] rootGameObjects = scene.GetRootGameObjects();

            foreach (var obj in rootGameObjects)
            {
                if (scene != activeScene)
                {
                    obj.SetActive(false);
                }
                else
                {
                    GameObject player = null;
                    List<GameObject> agents = new List<GameObject>();
                    if (scene1.name != null)
                    {
                        player = scene1.GetRootGameObjects().FirstOrDefault(s => s.name == "Player");
                        agents = scene1.GetRootGameObjects().Where(s => s.name.Contains("agent")).ToList();
                    }

                    if (player != null)
                    {
                        foreach (var agent in agents)
                        {
                            agent.SetActive(true);
                            agent.transform.parent = player.transform;
                            agent.transform.localPosition = player.transform.localPosition;
                        }
                        player.SetActive(true);
                        var spawnUp = scene2.GetRootGameObjects().FirstOrDefault().transform.Find("SpawnUp");
                        var spawnDown = scene2.GetRootGameObjects().FirstOrDefault().transform.Find("SpawnDown");

                        if (scene1.name == "First Room" && scene2.name != "mainMenu" && scene2.name != "bossHuone")
                        {
                            player.transform.localPosition = spawnDown.gameObject.transform.localPosition;
                        }
                        else if(scene2.name == "bossHuone")
                        {
                            var foo = scene2.GetRootGameObjects().ToList();
                            var bossRoomSpawn = scene2.GetRootGameObjects().Where(s => s.name == "SpawnDown").FirstOrDefault().transform;
                            player.transform.localPosition = bossRoomSpawn.localPosition;
                        }
                        else if (scene1.name == "mainMenu" && scene2.name == "First Room")
                        {
                            player.transform.localPosition = new Vector3(-1f, 0f, 0f);
                        }
                        else if (scene2.name == "mainMenu")
                        {
                            // TODO thingy
                        }
                        else
                        {
                            var scene1Number = System.Convert.ToInt32(Regex.Replace(scene1.name, "[A-Za-z]", ""));
                            var scene2Number = System.Convert.ToInt32(Regex.Replace(scene2.name, "[A-Za-z]", ""));

                            if (scene2Number < scene1Number)
                            {
                                player.transform.localPosition = spawnUp.gameObject.transform.localPosition;
                            }

                            if (scene2Number > scene1Number)
                            {
                                player.transform.localPosition = spawnDown.gameObject.transform.localPosition;
                            }
                        }
                        SceneManager.MoveGameObjectToScene(player, scene2);
                    }
                    obj.SetActive(true);
                }
            }
        }
        if (scene1.name != null)
        {
            AstarPath.active.Scan();
        }
    }

    private RandomModelVectors GenerateVectorsForRandomObjects(int randomObjectsPerLevel, int diffuculty)
    {
        var tempVectors = new List<Vector2>();
        var randomObjectVectors = new RandomModelVectors();
        for (int i = 0; i < randomObjectsPerLevel; i++)
        {
            while (tempVectors.Count < randomObjectsPerLevel)
            {
                var randomX1 = Random.Range(0, roomSizeX * tileSize - 1);
                var randomY1 = Random.Range(0, roomSizeY * -tileSize);

                if (!tempVectors.Contains(new Vector2(randomX1, randomY1)) && !tempVectors.Contains(new Vector2(randomX1 + 1f, randomY1)) && !tempVectors.Contains(new Vector2(randomX1, randomY1 - 1f)) && !tempVectors.Contains(new Vector2(randomX1 + 1f, randomY1 - 1f)))
                {
                    randomObjectVectors.BigRockVectors.Add(new Vector2(randomX1, randomY1));
                    tempVectors.Add(new Vector2(randomX1, randomY1));
                    tempVectors.Add(new Vector2(randomX1 + 1f, randomY1));
                    tempVectors.Add(new Vector2(randomX1, randomY1 + 1f));
                    tempVectors.Add(new Vector2(randomX1 + 1f, randomY1 - 1f));
                }

                var randomX2 = Random.Range(0, roomSizeX * tileSize - 1);
                var randomY2 = Random.Range(0, roomSizeY * -tileSize);
                if (!tempVectors.Contains(new Vector2(randomX2, randomY2)))
                {
                    randomObjectVectors.SmallRock1Vectors.Add(new Vector2(randomX2, randomY2));
                    tempVectors.Add(new Vector2(randomX2, randomY2));
                }

                var randomX3 = Random.Range(0, roomSizeX * tileSize - 1);
                var randomY3 = Random.Range(0, roomSizeY * -tileSize);
                if (!tempVectors.Contains(new Vector2(randomX3, randomY3)))
                {
                    randomObjectVectors.SmallRock2Vectors.Add(new Vector2(randomX3, randomY3));
                    tempVectors.Add(new Vector2(randomX3, randomY3));
                }

                var randomX4 = Random.Range(0, roomSizeX * tileSize - 1);
                var randomY4 = Random.Range(0, roomSizeY * -tileSize);
                if (!tempVectors.Contains(new Vector2(randomX4, randomY4)))
                {
                    randomObjectVectors.EnemyMeleeVectors.Add(new Vector2(randomX4, randomY4));
                    tempVectors.Add(new Vector2(randomX4, randomY4));
                }

                var randomX5 = Random.Range(0, roomSizeX * tileSize - 1);
                var randomY5 = Random.Range(0, roomSizeY * -tileSize);
                if (!tempVectors.Contains(new Vector2(randomX5, randomY5)))
                {
                    randomObjectVectors.EnemyRangedVectors.Add(new Vector2(randomX5, randomY5));
                    tempVectors.Add(new Vector2(randomX5, randomY5));
                }
            }
        }
        return randomObjectVectors;
    }

    private GameObject GenerateRoom()
    {
        int objectPerLevel = roomSizeX + roomSizeY / 4;
        RandomModelVectors randomObjectVectors = GenerateVectorsForRandomObjects(objectPerLevel, difficulty);
        List<Vector2> vectors = new List<Vector2>();
        Dictionary<string, bool> setConstantObjects = new Dictionary<string, bool>();
        var staticGameObjects = new List<GameObject>();
        var enemyGameObjects = new List<GameObject>();

        GameObject tempRoom = new GameObject("Room " + floorNumber);
        var vectorsAroundSpawn = new List<Vector2>();

        foreach (var resource in Resources.LoadAll<GameObject>("Objects").Cast<GameObject>())
        {
            staticGameObjects.Add(resource);
        }
        foreach (var resource in Resources.LoadAll<GameObject>("Enemies").Cast<GameObject>())
        {
            enemyGameObjects.Add(resource);
        }

        #region tileGeneration

        for (int i = 0; i < 9; i++)
        {
            GameObject tile = new GameObject();
            tiles.Add(tile);
        }

        #endregion tileGeneration

        // Loop through the X and Y parameters and generate walls and floor.
        for (int row = 0; row < roomSizeX + 1; row++)
        {
            for (int col = 0; col < roomSizeY + 1; col++)
            {
                int posX = col * tileSize;
                int posY = row * -tileSize;
                vectorsAroundSpawn.AddRange(ObjectGenerators.GenerateDoors(tiles, tileSize, col, row, roomSizeY, roomSizeX, posX, posY, setConstantObjects, staticGameObjects, vectors, tempRoom, "S"));
                vectorsAroundSpawn.AddRange(ObjectGenerators.GenerateDoors(tiles, tileSize, col, row, roomSizeY, roomSizeX, posX, posY, setConstantObjects, staticGameObjects, vectors, tempRoom, "N"));
                vectorsAroundSpawn.AddRange(ObjectGenerators.GenerateDoors(tiles, tileSize, col, row, roomSizeY, roomSizeX, posX, posY, setConstantObjects, staticGameObjects, vectors, tempRoom, "L"));

                ObjectGenerators.GenerateCorners(tiles, col, row, roomSizeY, roomSizeX, posX, posY, setConstantObjects, staticGameObjects, vectors, tempRoom);
                ObjectGenerators.GenerateWalls(tiles, col, row, roomSizeY, roomSizeX, posX, posY, staticGameObjects, vectors, tempRoom);
                ObjectGenerators.GenerateFloors(tiles, posX, posY, staticGameObjects, vectors, tempRoom);
            }
        }

        //fill unfilled floorpieces, which the earlier for-loop leaves.
        for (int row = 0; row < roomSizeX + 1; row++)
        {
            for (int col = 0; col < roomSizeY + 1; col++)
            {
                float posX = col * tileSize;
                float posY = row * -tileSize;

                if (!vectors.Contains(new Vector2(posX, posY)))
                {
                    tiles[1] = Instantiate(staticGameObjects.FirstOrDefault(s => s.name.StartsWith("Floor2")), tempRoom.transform);
                    tiles[1].transform.localPosition = new Vector2(posX, posY);
                    vectors.Add(new Vector2(posX, posY));
                }

                if (tiles[1] != null)
                    tiles[1].transform.parent = tempRoom.transform;
            }
        }

        #region SmallObjects

        // TODO create more generic way of creating objects. ForEach loop for every item is not very efficient.
        foreach (var vector in randomObjectVectors.SmallRock1Vectors)
        {
            ObjectGenerators.GenerateSmallRock1(vector, tiles, staticGameObjects, tempRoom, vectorsAroundSpawn);
        }
        foreach (var vector in randomObjectVectors.SmallRock2Vectors)
        {
            ObjectGenerators.GenerateSmallRock2(vector, tiles, staticGameObjects, tempRoom, vectorsAroundSpawn);
        }
        foreach (var vector in randomObjectVectors.BigRockVectors)
        {
            ObjectGenerators.GenerateBigRock(vector, tiles, staticGameObjects, tempRoom, vectorsAroundSpawn);
        }
        foreach (var vector in randomObjectVectors.EnemyMeleeVectors)
        {
            ObjectGenerators.GenerateMeleeEnemy(tempRoom, tiles, enemyGameObjects, difficulty, vector);
        }
        foreach (var vector in randomObjectVectors.EnemyRangedVectors)
        {
            ObjectGenerators.GenerateRangedEnemy(tempRoom, tiles, enemyGameObjects, difficulty, vector);
        }

        #endregion SmallObjects

        return tempRoom;
    }
}