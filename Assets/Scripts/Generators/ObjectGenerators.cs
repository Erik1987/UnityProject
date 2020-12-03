using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class ObjectGenerators : MonoBehaviour
    {
        public static void GenerateBigRock(Vector2 vector, List<GameObject> tiles, List<GameObject> gameObjects, GameObject tempRoom, List<Vector2> vectorsAroundSpawn)
        {
            if (!vectorsAroundSpawn.Contains(new Vector2(vector.x, vector.y)) && !vectorsAroundSpawn.Contains(new Vector2(vector.x + 1f, vector.y)) && !vectorsAroundSpawn.Contains(new Vector2(vector.x, vector.y - 1f)) && !vectorsAroundSpawn.Contains(new Vector2(vector.x + 1f, vector.y - 1f)))
            {
                tiles[0] = Instantiate(gameObjects.FirstOrDefault(s => s.name.StartsWith("BigRock1")), tempRoom.transform);
                tiles[0].transform.position = new Vector2(vector.x, vector.y);

                tiles[1] = Instantiate(gameObjects.FirstOrDefault(s => s.name.StartsWith("BigRock2")), tempRoom.transform);
                tiles[1].transform.position = new Vector2(vector.x + 1f, vector.y);

                tiles[2] = Instantiate(gameObjects.FirstOrDefault(s => s.name.StartsWith("BigRock3")), tempRoom.transform);
                tiles[2].transform.position = new Vector2(vector.x, vector.y - 1f);

                tiles[3] = Instantiate(gameObjects.FirstOrDefault(s => s.name.StartsWith("BigRock4")), tempRoom.transform);
                tiles[3].transform.position = new Vector2(vector.x + 1f, vector.y - 1f);
            }
        }

        public static void GenerateSmallRock1(Vector2 vector, List<GameObject> tiles, List<GameObject> gameObjects, GameObject tempRoom, List<Vector2> vectorsAroundSpawn)
        {

            if (!vectorsAroundSpawn.Contains(new Vector2(vector.x, vector.y)))
            {
                tiles[0] = Instantiate(gameObjects.FirstOrDefault(s => s.name.StartsWith("SmallRock1")), tempRoom.transform);
                tiles[0].transform.position = new Vector2(vector.x, vector.y);

            }
        }

        public static void GenerateSmallRock2(Vector2 vector, List<GameObject> tiles, List<GameObject> gameObjects, GameObject tempRoom, List<Vector2> vectorsAroundSpawn)
        {
            if (!vectorsAroundSpawn.Contains(new Vector2(vector.x, vector.y)))
            {
                tiles[0] = Instantiate(gameObjects.FirstOrDefault(s => s.name.StartsWith("SmallRock2")), tempRoom.transform);
                tiles[0].transform.position = new Vector2(vector.x, vector.y);
            }
        }

        public static void GenerateCorners(List<GameObject> tiles, int col, int row, int roomY, int roomX, int posX, int posY, Dictionary<string, bool> setConstantObjects, List<GameObject> gameobjects, List<Vector2> vectors, GameObject tempRoom)
        {
            // Right top corner
            if (col == roomY && !setConstantObjects.ContainsKey("topRightCornerSet"))
            {
                tiles[0] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopRightCorner1")), tempRoom.transform);
                vectors.Add(tiles[0].transform.localPosition = new Vector2(posX + 1f, posY + 3f));

                tiles[1] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopRightCorner2")), tempRoom.transform);
                vectors.Add(tiles[1].transform.localPosition = new Vector2(posX + 2f, posY + 3f));

                tiles[2] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopRightCorner3")), tempRoom.transform);
                vectors.Add(tiles[2].transform.localPosition = new Vector2(posX + 3f, posY + 3f));

                tiles[3] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopRightCorner4")), tempRoom.transform);
                vectors.Add(tiles[3].transform.localPosition = new Vector2(posX + 1f, posY + 2f));

                tiles[4] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopRightCorner5")), tempRoom.transform);
                vectors.Add(tiles[4].transform.localPosition = new Vector2(posX + 2f, posY + 2f));

                tiles[5] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopRightCorner6")), tempRoom.transform);
                vectors.Add(tiles[5].transform.localPosition = new Vector2(posX + 3f, posY + 2f));

                tiles[6] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopRightCorner7")), tempRoom.transform);
                vectors.Add(tiles[6].transform.localPosition = new Vector2(posX + 1f, posY + 1f));

                tiles[7] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopRightCorner8")), tempRoom.transform);
                vectors.Add(tiles[7].transform.localPosition = new Vector2(posX + 2f, posY + 1f));

                tiles[8] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopRightCorner9")), tempRoom.transform);
                vectors.Add(tiles[8].transform.localPosition = new Vector2(posX + 3f, posY + 1f));
                setConstantObjects.Add("topRightCornerSet", true);


                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 3f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 2f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 1f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 1f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 2f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 3f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 4f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 5f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 6f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 7f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 8f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 9f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 10f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 11f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 12f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 13f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 14f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 14f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 15f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 16f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 17f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 18f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 19f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 20f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 21f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 22f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 23f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 24f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 25f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 26f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 27f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 28f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 29f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 30f, posY + 3f);


                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 13f, posY + 4f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 13f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 13f, posY + 2f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 13f, posY + 1f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 13f, posY);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 13f, posY - 1f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 13f, posY - 2f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 13f, posY - 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 13f, posY - 4f);


            }
            // Right bot corner
            if (col == roomY && row == roomX && !setConstantObjects.ContainsKey("botRightCornerSet"))
            {
                tiles[0] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotRightCorner1")), tempRoom.transform);
                vectors.Add(tiles[0].transform.localPosition = new Vector2(posX + 1f, posY - 3f));

                tiles[1] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotRightCorner2")), tempRoom.transform);
                vectors.Add(tiles[1].transform.localPosition = new Vector2(posX + 2f, posY - 3f));

                tiles[2] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotRightCorner3")), tempRoom.transform);
                vectors.Add(tiles[2].transform.localPosition = new Vector2(posX + 3f, posY - 3f));

                tiles[3] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotRightCorner4")), tempRoom.transform);
                vectors.Add(tiles[3].transform.localPosition = new Vector2(posX + 1f, posY - 2f));

                tiles[4] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotRightCorner5")), tempRoom.transform);
                vectors.Add(tiles[4].transform.localPosition = new Vector2(posX + 2f, posY - 2f));

                tiles[5] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotRightCorner6")), tempRoom.transform);
                vectors.Add(tiles[5].transform.localPosition = new Vector2(posX + 3f, posY - 2f));

                tiles[6] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotRightCorner7")), tempRoom.transform);
                vectors.Add(tiles[6].transform.localPosition = new Vector2(posX + 1f, posY - 1f));

                tiles[7] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotRightCorner8")), tempRoom.transform);
                vectors.Add(tiles[7].transform.localPosition = new Vector2(posX + 2f, posY - 1f));

                tiles[8] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotRightCorner9")), tempRoom.transform);
                vectors.Add(tiles[8].transform.localPosition = new Vector2(posX + 3f, posY - 1f));
                setConstantObjects.Add("botRightCornerSet", true);

                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 1, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 1f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 2f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 3f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 3f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 5f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 6f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 7f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 8f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 9f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 10f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 11f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 12f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 13f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 14f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 14f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 15f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 16f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 17f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 18f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 19f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 20f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 21f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 22f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 23f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 24f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 25f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 26f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 27f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 28f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 29f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 30f, posY - 18f);

                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 15f, posY - 2f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 15f, posY - 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 15f, posY - 4f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 15f, posY - 5f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 15f, posY - 6f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 15f, posY - 7f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 15f, posY - 8f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 15f, posY - 9f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 15f, posY - 10f);

            }
            //Left top corner
            if (col == 0 && !setConstantObjects.ContainsKey("topLeftCornerSet"))
            {
                tiles[0] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopLeftCorner1")), tempRoom.transform);
                vectors.Add(tiles[0].transform.localPosition = new Vector2(posX - 1f, posY + 3f));

                tiles[1] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopLeftCorner2")), tempRoom.transform);
                vectors.Add(tiles[1].transform.localPosition = new Vector2(posX - 2f, posY + 3f));

                tiles[2] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopLeftCorner3")), tempRoom.transform);
                vectors.Add(tiles[2].transform.localPosition = new Vector2(posX - 3f, posY + 3f));

                tiles[3] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopLeftCorner4")), tempRoom.transform);
                vectors.Add(tiles[3].transform.localPosition = new Vector2(posX - 1f, posY + 2f));

                tiles[4] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopLeftCorner5")), tempRoom.transform);
                vectors.Add(tiles[4].transform.localPosition = new Vector2(posX - 2f, posY + 2f));

                tiles[5] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopLeftCorner6")), tempRoom.transform);
                vectors.Add(tiles[5].transform.localPosition = new Vector2(posX - 3f, posY + 2f));

                tiles[6] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopLeftCorner7")), tempRoom.transform);
                vectors.Add(tiles[6].transform.localPosition = new Vector2(posX - 1f, posY + 1f));

                tiles[7] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopLeftCorner8")), tempRoom.transform);
                vectors.Add(tiles[7].transform.localPosition = new Vector2(posX - 2f, posY + 1f));

                tiles[8] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("TopLeftCorner9")), tempRoom.transform);
                vectors.Add(tiles[8].transform.localPosition = new Vector2(posX - 3f, posY + 1f));
                setConstantObjects.Add("topLeftCornerSet", true);

                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 1, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 1f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 2f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 3f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 3f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 4f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 5f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 6f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 7f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 8f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 9f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 10f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 11f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 12f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 13f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 14f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 14f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 15f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 16f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 17f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 18f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 19f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 20f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 21f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 22f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 24f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 25f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 26f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 27f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 28f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 29f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 30f, posY + 3f);


                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY + 3);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY + 2f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY + 1f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY + 4f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 1f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 2f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 4f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 5f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 6f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 7f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 8f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 9f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 10f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 11f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 12f);
            }
            //Left bot corner
            if (col == 0 && row == roomX && !setConstantObjects.ContainsKey("botLeftCornerSet"))
            {
                tiles[0] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotLeftCorner1")), tempRoom.transform);
                vectors.Add(tiles[0].transform.localPosition = new Vector2(posX - 1f, posY - 3f));

                tiles[1] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotLeftCorner2")), tempRoom.transform);
                vectors.Add(tiles[1].transform.localPosition = new Vector2(posX - 2f, posY - 3f));

                tiles[2] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotLeftCorner3")), tempRoom.transform);
                vectors.Add(tiles[2].transform.localPosition = new Vector2(posX - 3f, posY - 3f));

                tiles[3] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotLeftCorner4")), tempRoom.transform);
                vectors.Add(tiles[3].transform.localPosition = new Vector2(posX - 1f, posY - 2f));

                tiles[4] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotLeftCorner5")), tempRoom.transform);
                vectors.Add(tiles[4].transform.localPosition = new Vector2(posX - 2, posY - 2f));

                tiles[5] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotLeftCorner6")), tempRoom.transform);
                vectors.Add(tiles[5].transform.localPosition = new Vector2(posX - 3, posY - 2f));

                tiles[6] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotLeftCorner7")), tempRoom.transform);
                vectors.Add(tiles[6].transform.localPosition = new Vector2(posX - 1f, posY - 1f));

                tiles[7] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotLeftCorner8")), tempRoom.transform);
                vectors.Add(tiles[7].transform.localPosition = new Vector2(posX - 2f, posY - 1f));

                tiles[8] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BotLeftCorner9")), tempRoom.transform);
                vectors.Add(tiles[8].transform.localPosition = new Vector2(posX - 3f, posY - 1f));
                setConstantObjects.Add("botLeftCornerSet", true);


                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 1, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 1f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 2f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 3f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 3f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 4f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 5f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 6f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 7f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 8f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 9f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 10f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 11f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 12f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 13f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 14f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX + 14f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 15f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 16f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 17f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 18f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 19f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 20f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 21f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 22f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 24f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 25f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 26f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 27f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 28f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 29f, posY - 18f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX - 30f, posY - 18f);

                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 4f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 2);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY - 1f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY + 1f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY + 2f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY + 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 23f, posY + 4f);
            }
        }

        private static int enemyNumber = 1;

        internal static void GenerateMeleeEnemy(GameObject tempRoom, List<GameObject> tiles, List<GameObject> gameobjects, int difficulty, Vector2 vector)
        {
            tiles[0] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("EnemySpawn")), tempRoom.transform);
            tiles[0].name = $"{tiles[0].name}{enemyNumber}";
            tiles[0].transform.position = new Vector2(vector.x, vector.y);
            tiles[1] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("Smart")), tempRoom.transform);
            tiles[1].name = $"Enemy {enemyNumber}";
            tiles[1].transform.localPosition = new Vector2(vector.x, vector.y);
            enemyNumber++;
        }

        internal static void GenerateRangedEnemy(GameObject tempRoom, List<GameObject> tiles, List<GameObject> gameobjects, int difficulty, Vector2 vector)
        {
            tiles[0] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("EnemySpawn")), tempRoom.transform);
            tiles[0].name = $"{tiles[0].name}{enemyNumber}";
            tiles[0].transform.position = new Vector2(vector.x, vector.y);
            tiles[1] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("Ranged")), tempRoom.transform);
            tiles[1].name = $"Enemy {enemyNumber}";
            tiles[1].transform.localPosition = new Vector2(vector.x, vector.y);
            enemyNumber++;
        }

        internal static void GenerateSuperEnemy(GameObject tempRoom, List<GameObject> tiles, List<GameObject> gameobjects, int difficulty, Vector2 vector)
        {
            tiles[0] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("EnemySpawn")), tempRoom.transform);
            tiles[0].name = $"{tiles[0].name}{enemyNumber}";
            tiles[0].transform.position = new Vector2(vector.x, vector.y);
            tiles[1] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("Super")), tempRoom.transform);
            tiles[1].name = $"Enemy {enemyNumber}";
            tiles[1].transform.localPosition = new Vector2(vector.x, vector.y);
            enemyNumber++;
        }

        internal static void GenerateLake1(Vector2 vector, List<GameObject> tiles, List<GameObject> staticGameObjects, GameObject tempRoom, Dictionary<string, bool> setConstantObjects)
        {
            if (!setConstantObjects.ContainsKey("lake1Set"))
            {
                Instantiate(staticGameObjects.FirstOrDefault(s => s.name.StartsWith("Lake1")), tempRoom.transform).transform.position = vector;
                setConstantObjects.Add("lake1Set", true);
            }
        }

        internal static void GenerateLake2(Vector2 vector, List<GameObject> tiles, List<GameObject> staticGameObjects, GameObject tempRoom, Dictionary<string, bool> setConstantObjects)
        {
            if (!setConstantObjects.ContainsKey("lake2Set"))
            {
                Instantiate(staticGameObjects.FirstOrDefault(s => s.name.StartsWith("Lake2")), tempRoom.transform).transform.position = vector;
                setConstantObjects.Add("lake2Set", true);
            }
        }

        internal static void GenerateLake3(Vector2 vector, List<GameObject> tiles, List<GameObject> staticGameObjects, GameObject tempRoom, Dictionary<string, bool> setConstantObjects)
        {
            if (!setConstantObjects.ContainsKey("lake3Set"))
            {
                Instantiate(staticGameObjects.FirstOrDefault(s => s.name.StartsWith("Lake3")), tempRoom.transform).transform.position = vector;
                setConstantObjects.Add("lake3Set", true);
            }
        }

        public static List<Vector2> GenerateDoors(List<GameObject> tiles, int tileSize, int col, int row, int roomY, int roomX, int posX, int posY, Dictionary<string, bool> setConstantObjects, List<GameObject> gameobjects, List<Vector2> vectors, GameObject tempRoom, string doorDirection, int floorNumber, int lastRoom)
        {
            var doorAmount = new System.Random().Next(1, 4);
            var vectorsAroundSpawn = new List<Vector2>();

            System.Random random = new System.Random();

            if (row == 0 && !setConstantObjects.ContainsKey("DoorUp") && doorDirection == "N")
            {
                var DoorUpX = random.Next(0 + 2, roomX - 2) * tileSize;

                tiles[0] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorUp1")), tempRoom.transform);
                vectors.Add(tiles[0].transform.localPosition = new Vector2(DoorUpX, posY + 1));

                tiles[7] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("Fire")), tempRoom.transform);
                vectors.Add(tiles[7].transform.position = new Vector2(DoorUpX - 1f, posY));
                vectorsAroundSpawn.Add(new Vector2(DoorUpX - 1f, posY));

                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorFloor")), tempRoom.transform).transform.localPosition = new Vector2(DoorUpX, posY);

                tiles[1] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorUp2")), tempRoom.transform);
                vectors.Add(tiles[1].transform.localPosition = new Vector2(DoorUpX, posY + 2f));

                tiles[2] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorUp3")), tempRoom.transform);
                vectors.Add(tiles[2].transform.localPosition = new Vector2(DoorUpX, posY + 3f));

                tiles[3] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorUp4")), tempRoom.transform);
                vectors.Add(tiles[3].transform.localPosition = new Vector2(DoorUpX + 1f, posY + 1f));

                tiles[6] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("Fire")), tempRoom.transform);
                vectors.Add(tiles[6].transform.position = new Vector2(DoorUpX + 2f, posY));
                vectorsAroundSpawn.Add(new Vector2(DoorUpX + 2f, posY));


                tiles[4] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorUp5")), tempRoom.transform);
                vectors.Add(tiles[4].transform.localPosition = new Vector2(DoorUpX + 1f, posY + 2f));

                tiles[5] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorUp6")), tempRoom.transform);
                vectors.Add(tiles[5].transform.localPosition = new Vector2(DoorUpX + 1f, posY + 3f));
                setConstantObjects.Add("DoorUp", true);

                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorFloor")), tempRoom.transform).transform.localPosition = new Vector2(DoorUpX, posY);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorFloor")), tempRoom.transform).transform.localPosition = new Vector2(DoorUpX + 1f, posY);

                if (floorNumber == lastRoom)
                {
                    foreach (var tile in tiles)
                    {
                        tile.tag = "DoorToBoss";
                    }
                }


                tiles[8] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("Spawn")), tempRoom.transform);
                tiles[8].name = "SpawnUp";
                tiles[8].transform.localPosition = new Vector2(DoorUpX, posY - 2f);
                vectorsAroundSpawn.Add(new Vector2(DoorUpX, posY - 1f));
                vectorsAroundSpawn.Add(new Vector2(DoorUpX, posY));
                vectorsAroundSpawn.Add(new Vector2(DoorUpX - 1, posY));
                vectorsAroundSpawn.Add(new Vector2(DoorUpX - 1f, posY));
                vectorsAroundSpawn.Add(new Vector2(DoorUpX - 1f, posY - 1f));
                vectorsAroundSpawn.Add(new Vector2(DoorUpX + 1f, posY - 1f));
            }

            if (row == roomX && !setConstantObjects.ContainsKey("DoorDown") && doorDirection == "S")
            {
                var DoorDownX = random.Next(0 + 2, roomX - 2) * tileSize;
                tiles[0] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorDown1")), tempRoom.transform);
                vectors.Add(tiles[0].transform.localPosition = new Vector2(DoorDownX, posY - 1f));

                tiles[6] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("Fire")), tempRoom.transform);
                vectors.Add(tiles[6].transform.position = new Vector2(DoorDownX + 1f, posY));
                vectorsAroundSpawn.Add(new Vector2(DoorDownX + 2f, posY));

                tiles[1] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorDown2")), tempRoom.transform);
                vectors.Add(tiles[1].transform.localPosition = new Vector2(DoorDownX, posY - 2f));

                tiles[2] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorDown3")), tempRoom.transform);
                vectors.Add(tiles[2].transform.localPosition = new Vector2(DoorDownX, posY - 3f));

                tiles[3] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorDown4")), tempRoom.transform);
                vectors.Add(tiles[3].transform.localPosition = new Vector2(DoorDownX - 1f, posY - 1f));

                tiles[7] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("Fire")), tempRoom.transform);
                vectors.Add(tiles[7].transform.position = new Vector2(DoorDownX - 2f, posY));
                vectorsAroundSpawn.Add(new Vector2(DoorDownX - 2f, posY));

                tiles[4] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorDown5")), tempRoom.transform);
                vectors.Add(tiles[4].transform.localPosition = new Vector2(DoorDownX - 1f, posY - 2f));

                tiles[5] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorDown6")), tempRoom.transform);
                vectors.Add(tiles[5].transform.localPosition = new Vector2(DoorDownX - 1f, posY - 3f));
                setConstantObjects.Add("DoorDown", true);

                tiles[8] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("Spawn")), tempRoom.transform);
                tiles[8].name = "SpawnDown";
                tiles[8].transform.localPosition = new Vector2(DoorDownX, posY + 1);
                vectorsAroundSpawn.Add(new Vector2(DoorDownX, posY + 2f));
                vectorsAroundSpawn.Add(new Vector2(DoorDownX + 1, posY));
                vectorsAroundSpawn.Add(new Vector2(DoorDownX, posY));
                vectorsAroundSpawn.Add(new Vector2(DoorDownX - 1, posY));
                vectorsAroundSpawn.Add(new Vector2(DoorDownX - 1f, posY - 1f));
                vectorsAroundSpawn.Add(new Vector2(DoorDownX + 1f, posY - 1f));

                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorFloor")), tempRoom.transform).transform.localPosition = new Vector2(DoorDownX - 1f, posY);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorFloor")), tempRoom.transform).transform.localPosition = new Vector2(DoorDownX, posY);
            }



            if (col == 0 && !setConstantObjects.ContainsKey("DoorLeft") && doorDirection == "L")
            {

                if (floorNumber % 4 == 0)
                {

                var DoorLeftY = random.Next(0 + 2, roomY - 2) * -tileSize;

                tiles[0] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("cavetoshop_tileset_14")), tempRoom.transform); 
                vectors.Add(tiles[0].transform.localPosition = new Vector2(posX - 1f, DoorLeftY));

                tiles[3] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("cavetoshop_tileset_19")), tempRoom.transform); 
                vectors.Add(tiles[3].transform.localPosition = new Vector2(posX - 1f, DoorLeftY - 1f));

                tiles[1] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("cavetoshop_tileset_13")), tempRoom.transform); 
                vectors.Add(tiles[1].transform.localPosition = new Vector2(posX - 2f, DoorLeftY));

                tiles[4] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("cavetoshop_tileset_18")), tempRoom.transform); 
                vectors.Add(tiles[4].transform.localPosition = new Vector2(posX - 2f, DoorLeftY - 1f));

                tiles[5] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("cavetoshop_tileset_12")), tempRoom.transform); 
                vectors.Add(tiles[5].transform.localPosition = new Vector2(posX - 3f, DoorLeftY - 1f));

                tiles[2] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("cavetoshop_tileset_17")), tempRoom.transform); 
                vectors.Add(tiles[2].transform.localPosition = new Vector2(posX - 3f, DoorLeftY));
                var foo = new Inventory();
                tiles[8] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("Spawn")), tempRoom.transform);
                tiles[8].name = "SpawnLeft";
                tiles[8].transform.localPosition = new Vector2(posX, DoorLeftY);

                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorFloor")), tempRoom.transform).transform.localPosition = new Vector2(posX, DoorLeftY - 1f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorFloor")), tempRoom.transform).transform.localPosition = new Vector2(posX, DoorLeftY);

                setConstantObjects.Add("DoorLeft", true);

                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 22f, DoorLeftY - 3f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 22f, DoorLeftY - 4f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 22f, DoorLeftY - 2f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 22f, DoorLeftY - 1f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 22f, DoorLeftY - 5f);
                Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 22f, DoorLeftY - 6f);
                }
            }

            if (col == roomY && !setConstantObjects.ContainsKey("DoorRight") && doorDirection == "R")
            {
                var DoorRightY = random.Next(0 + 2, roomY - 2) * -tileSize;

                tiles[0] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorRight1")), tempRoom.transform);
                vectors.Add(tiles[0].transform.localPosition = new Vector2(posX + 1f, DoorRightY));

                tiles[1] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorRight2")), tempRoom.transform);
                vectors.Add(tiles[1].transform.localPosition = new Vector2(posX + 2f, DoorRightY));

                tiles[2] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorRight3")), tempRoom.transform);
                vectors.Add(tiles[2].transform.localPosition = new Vector2(posX + 3f, DoorRightY));

                tiles[3] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorRight4")), tempRoom.transform);
                vectors.Add(tiles[3].transform.localPosition = new Vector2(posX + 1f, DoorRightY + 1f));

                tiles[4] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorRight5")), tempRoom.transform);
                vectors.Add(tiles[4].transform.localPosition = new Vector2(posX + 2, DoorRightY + 1f));

                tiles[5] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("DoorRight6")), tempRoom.transform);
                vectors.Add(tiles[5].transform.localPosition = new Vector2(posX + 3, DoorRightY + 1f));
                setConstantObjects.Add("DoorRight", true);
            }
            return vectorsAroundSpawn;
        }

        public static void GenerateWalls(List<GameObject> tiles, int col, int row, int roomY, int roomX, int posX, int posY, List<GameObject> gameobjects, List<Vector2> vectors, GameObject tempRoom)
        {
            if (row == 0)
            {
                if (!vectors.Contains(new Vector2(posX, posY + 1f)))
                {
                    tiles[0] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("NorthWall1")), tempRoom.transform);
                    vectors.Add(tiles[0].transform.localPosition = new Vector2(posX, posY + 1f));
                }

                if (!vectors.Contains(new Vector2(posX, posY + 2f)))
                {
                    tiles[1] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("NorthWall2")), tempRoom.transform);
                    vectors.Add(tiles[1].transform.localPosition = new Vector2(posX, posY + 2f));
                }

                if (!vectors.Contains(new Vector2(posX, posY + 3f)))
                {
                    tiles[2] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("NorthWall3")), tempRoom.transform);
                    vectors.Add(tiles[2].transform.localPosition = new Vector2(posX, posY + 3f));
                    Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX, posY + 3f); ;
                }

            }
            if (col == roomY)
            {
                if (!vectors.Contains(new Vector2(posX + 1f, posY)))
                {
                    tiles[0] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("RightWall1")), tempRoom.transform);
                    vectors.Add(tiles[0].transform.localPosition = new Vector2(posX + 1f, posY));
                }
                if (!vectors.Contains(new Vector2(posX + 2f, posY)))
                {
                    tiles[1] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("RightWall2")), tempRoom.transform);
                    vectors.Add(tiles[1].transform.localPosition = new Vector2(posX + 2f, posY));
                }
                if (!vectors.Contains(new Vector2(posX + 3f, posY)))
                {
                    tiles[2] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("RightWall3")), tempRoom.transform);
                    vectors.Add(tiles[2].transform.localPosition = new Vector2(posX + 3f, posY));
                    Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX + 15f, posY - 1); ;
                }
            }
            if (row == roomX)
            {
                if (!vectors.Contains(new Vector2(posX, posY - 1f)))
                {
                    tiles[0] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("SouthWall1")), tempRoom.transform);
                    vectors.Add(tiles[0].transform.localPosition = new Vector2(posX, posY - 1f));
                }

                if (!vectors.Contains(new Vector2(posX, posY - 2f)))
                {
                    tiles[1] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("SouthWall2")), tempRoom.transform);
                    vectors.Add(tiles[1].transform.localPosition = new Vector2(posX, posY - 2f));
                }

                if (!vectors.Contains(new Vector2(posX, posY - 3f)))
                {
                    tiles[2] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("SouthWall3")), tempRoom.transform);
                    vectors.Add(tiles[2].transform.localPosition = new Vector2(posX, posY - 3f));
                    Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("backgroundWall")), tempRoom.transform).transform.localPosition = new Vector2(posX, posY - 18f); ;

                }
            }
            if (col == 0)
            {
                if (!vectors.Contains(new Vector2(posX - 1f, posY)))
                {
                    tiles[0] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("LeftWall1")), tempRoom.transform);
                    vectors.Add(tiles[0].transform.localPosition = new Vector2(posX - 1f, posY));
                }

                if (!vectors.Contains(new Vector2(posX - 2f, posY)))
                {
                    tiles[1] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("LeftWall2")), tempRoom.transform);
                    vectors.Add(tiles[1].transform.localPosition = new Vector2(posX - 2f, posY));
                }

                if (!vectors.Contains(new Vector2(posX - 3f, posY)))
                {
                    tiles[2] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("LeftWall3")), tempRoom.transform);
                    vectors.Add(tiles[2].transform.localPosition = new Vector2(posX - 3f, posY));
                    Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("BackgroundWallSideways")), tempRoom.transform).transform.localPosition = new Vector2(posX - 22f, posY - 1); ;
                }
            }
        }

        public static void GenerateFloors(List<GameObject> tiles, int posX, float posY, List<GameObject> gameobjects, List<Vector2> vectors, GameObject tempRoom)
        {
            if (!vectors.Contains(new Vector2(posX + 1f, posY + 1f)) && !vectors.Contains(new Vector2(posX, posY)) && !vectors.Contains(new Vector2(posX - 1f, posY)) && !vectors.Contains(new Vector2(posX, posY + 1f)))
            {
                tiles[0] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("Floor1")), tempRoom.transform);
                tiles[0].transform.localPosition = new Vector2(posX + 1f, posY + 1f);
                vectors.Add(new Vector2(posX + 1f, posY + 1f));

                tiles[1] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("Floor2")), tempRoom.transform);
                tiles[1].transform.localPosition = new Vector2(posX, posY);
                vectors.Add(new Vector2(posX, posY));

                tiles[2] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("Floor3")), tempRoom.transform);
                tiles[2].transform.localPosition = new Vector2(posX - 1, posY);
                vectors.Add(new Vector2(posX - 1f, posY));

                tiles[3] = Instantiate(gameobjects.FirstOrDefault(s => s.name.StartsWith("Floor4")), tempRoom.transform);
                tiles[3].transform.localPosition = new Vector2(posX, posY + 1f);
                vectors.Add(new Vector2(posX, posY + 1f));
            }
        }
    }
}