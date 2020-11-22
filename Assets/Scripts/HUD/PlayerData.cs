using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string sceneName;
    public int health;
    public int mana;
    public int gold;
    public float[] position; // transforming vector3 position to array, because of unity policy for non serializable vector3


    public PlayerData(Player player)
    {
        sceneName = player.currentSceneName;
        health = player.currentHealth;
        mana = player.currentMana;
        gold = player.coins;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
