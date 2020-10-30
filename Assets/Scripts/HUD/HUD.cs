using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    private int MAX_health;
    private int MAX_mana;
    private int index_health;
    private int index_mana;
    private Canvas HUDcanvas;
    private Player player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

        var loadInventoryPanel = Resources.Load("Inventory/InventoryPanel");
        GameObject instantiateInventoryPanel = (GameObject)Instantiate(loadInventoryPanel, new Vector3((float)151.8261, (float)382.8076, (float)0), Quaternion.identity);
        instantiateInventoryPanel.transform.SetParent(GameObject.FindGameObjectWithTag("HUDcanvas").transform);
        instantiateInventoryPanel.transform.name = "InventoryPanel";
        instantiateInventoryPanel.transform.localPosition += Vector3.right;
        instantiateInventoryPanel.transform.localScale = new Vector3(0.5124438f, 0.81991f, 0.81991f);
        instantiateInventoryPanel.GetComponent<RectTransform>().anchoredPosition3D = new Vector3((float)151.8261, (float)382.8076, (float)0);
        instantiateInventoryPanel.GetComponent<RectTransform>().offsetMin = new Vector2(250, -30); // left + bottom
        instantiateInventoryPanel.GetComponent<RectTransform>().offsetMax = new Vector2(-50, -430); // right + top

        bool tempbool = false;
        //Find the object you're looking for
        GameObject tempObject = GameObject.Find("HUDcanvas");
        if (tempObject != null)
        {
            //If we found the object , get the Canvas component from it.
            HUDcanvas = tempObject.GetComponent<Canvas>();
            if (HUDcanvas == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
            tempbool = true;
        }

        // @test
        MAX_health = player.currentHealth;
        MAX_mana = player.currentMana;
        InstantiateHUDContent(MAX_health, MAX_mana);

    }
    private void Update()
    {
        var tempHealth = player.currentHealth;
        var tempMana = player.currentMana;
        if (MAX_health != tempHealth | MAX_mana != tempMana)
        {
            MAX_health = tempHealth;
            MAX_mana = tempMana;
            DestroyObjectHealthAndMana(index_health, index_mana);
            InstantiateHUDContent(MAX_health, MAX_mana);
        }
    }
    public void DestroyObjectHealthAndMana(int idx_health, int idx_mana)
    {
        // destroy all health from scene
        for (int i = 0; i <= idx_health; i++)
        {
            Destroy(GameObject.Find("heart_" + i));
        }
        // destroy all mana from scene
        for (int i = 0; i <= idx_mana; i++)
        {
            Destroy(GameObject.Find("mana_" + i));
        }

    }

    public void InstantiateHUDContent(int MAX_health, int MAX_mana)
    {
        int x = 1;
        int y = 1;


        var loadedObjects = Resources.LoadAll("HUDelements");
        List<GameObject> gameObjects = new List<GameObject>();
        foreach (var loadedObject in loadedObjects)
        {
            gameObjects.Add(loadedObject as GameObject);
        }
        for (int i = 0; i < MAX_health; i++)
        {
            GameObject heart = (GameObject)Instantiate(gameObjects[0], new Vector3(((float)(x + -293.34)), (float)136.05, (float)0),
                Quaternion.identity);
            heart.transform.SetParent(GameObject.FindGameObjectWithTag("HUDcanvas").transform, false);
            heart.transform.localScale = new Vector3((float)48.62824, (float)54.06241, (float)0);
            heart.GetComponent<SpriteRenderer>().sortingOrder = 32767;
            heart.name = "heart_" + i;
            // i * 2.0F, 0, 0
            heart.SetActive(true);
            x += 20;
            index_health = i;
        }
        for (int i = 0; i < MAX_mana; i++)
        {
            GameObject mana = (GameObject)Instantiate(gameObjects[1], new Vector3(((float)(y + -293.34)), (float)116, (float)0),
                Quaternion.identity);
            mana.transform.SetParent(GameObject.FindGameObjectWithTag("HUDcanvas").transform, false);
            mana.transform.localScale = new Vector3((float)14.24891, (float)10.10564, (float)0);
            mana.GetComponent<SpriteRenderer>().sortingOrder = 32767;
            mana.name = "mana_" + i;
            mana.SetActive(true);
            y += 20;
            index_mana = i;
        }
    }

}