using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using JetBrains.Annotations;
using System.Linq;

public static class hasComponent
{
    public static bool HasNotComponent<T>(this GameObject flag) where T : Component
    {
        return flag.GetComponent<T>() == null;
    }
}
public class Inventory : MonoBehaviour
{
    InventoryDatabase inventoryDB;
    private GameObject inventoryPanel;
    private GameObject slotPanel;
    public GameObject inventorySlot;
    public GameObject inventoryItem;
    public GameObject inventoryCanvas;
    public Scene activeScene;
    int slotAmount;

    public List<Item> items = new List<Item>();
    public List<Item> itemsToFlush = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();
    public List<GameObject> canvases = new List<GameObject>();
    private GameObject coinObject;
    public static int coins = 0;
    private int currentCoins = 0;
    private int itemsCount = 0;
    public static bool destroyBool = false;
    private bool resetCompleted = false;
    private bool addAllToInstantiate = false;
    private bool addOneToInstantiate = false;
    public int uniqueShopID { get; set; }


    public void Start()
    {

       

        slotAmount = 6;
        if (resetCompleted == false)
        {

            GetAndSetComponents();

            // preferred way to add new item to jsonDB, delete after first run (remember to add last value to true if you want to save an item to JsonDB)
            //inventoryDB.AddNewItem("shield_wood_basic_1", "Wooden Shield", "Shield", 0, 2, 0, 0, false, 0, 30, true);
            InstantiateSlotsAndCanvases();

            // here items are added based on storage in JSON file
            AddItemsToList();

            // here coins are instantiated
            InstantiateCoins();


        }
            activeScene = SceneManager.GetActiveScene();
        // try this if you want to add items
        //inventoryDB.OnChange("life_large", 3);
        destroyBool = false;

           



    }
    private void Update()
    {
        var pleia = GameObject.FindGameObjectsWithTag("pelaaja").FirstOrDefault();
        var player = pleia.transform.GetComponent<Player>();

        if (player.coins != coins)
        {
            currentCoins = player.coins;
            coinObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentCoins.ToString();
        }


        

        if (destroyBool == true)
        {
            ResetInventory();
        }

        if (SceneManager.GetActiveScene() != activeScene)
        {
            for (int i = 0; i < slotAmount; i++)
            {
                canvases[i].GetComponent<Canvas>().sortingOrder = 32767;
            } 
        }
    }

    public void GetAndSetComponents()
    {
        
        inventoryDB = GetComponent<InventoryDatabase>();
        inventoryPanel = GameObject.Find("InventoryPanel");
        if (inventoryPanel.HasNotComponent<Canvas>())
        {
            inventoryPanel.AddComponent<Canvas>();
        }
        slotPanel = inventoryPanel.transform.Find("SlotPanel").gameObject;
        if (slotPanel.HasNotComponent<Canvas>())
        {
            slotPanel.AddComponent<Canvas>();
        }
        inventoryPanel.GetComponent<Canvas>().overrideSorting = true;
        inventoryPanel.GetComponent<Canvas>().sortingOrder = 32765;
        slotPanel.GetComponent<Canvas>().overrideSorting = true;
        slotPanel.GetComponent<Canvas>().sortingOrder = 32765;
    }
    public void ResetInventory()
    {
        if (itemsCount > 0)
        {
            GameObject[] tempObj = GameObject.FindGameObjectsWithTag("item");


            for (int i = 0; i < tempObj.Length; i++)
            {
                if (tempObj.Length > i)
                {
                    gameObjects.Remove(tempObj[i]);
                    Destroy(tempObj[i]);
                    //canvases[i].transform.GetChild(1).GetComponent<ItemData>().amount = 1;
                }
                else
                {
                    destroyBool = false;
                    break;
                }
            }
            for (int k = 0; k < slotAmount; k++)
            {
                if (items[k] == itemsToFlush[k] /*&& itemsToFlush[k].id != -1*/)
                {
                    for (int a = 0; a < slotAmount; a++)
                    {
                        Item removeItem = itemsToFlush[a];
                        items.Remove(removeItem);
                        if (a == slotAmount)
                        {
                            itemsToFlush.Clear();
                        }
                    }

                }
                if (items.Count() < slotAmount)
                {
                    break;
                }
            }

            foreach (var item in tempObj)
            {
                items.Add(new Item());
                //itemsToFlush.Add(new Item());
            }
            resetCompleted = true;
            value = 0;
        }
        else
        {
            Debug.Log("No items in inventory to reset!");
            destroyBool = false;
        }
    }
    public void ResetSlotsAndCanvases()
    {
        GameObject[] tempObjs = GameObject.FindGameObjectsWithTag("slot_canvas");
        GameObject[] tempObjs2 = GameObject.FindGameObjectsWithTag("slot");
    }
    public void InstantiateSlotsAndCanvases()
    {
        // instantiate Slots in inventory panel
        for (int i = 0; i < slotAmount; i++)
        {
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
            slots[i].transform.localScale = new Vector3((float)3.427969, (float)2.114224, 1);
            slots[i].transform.name = "Slot_" + i;
            slots[i].tag = "slot";
            if (slots[i].HasNotComponent<Canvas>())
            {
                slots[i].AddComponent<Canvas>();
            }
            slots[i].GetComponent<Canvas>().overrideSorting = true;
            slots[i].GetComponent<Canvas>().sortingOrder = 32766;
        }
        // instantiate Canvases for items
        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            itemsToFlush.Add(new Item());
            canvases.Add(Instantiate(inventoryCanvas));
            canvases[i].GetComponent<ItemSlotDrop>().idx = i;
            canvases[i].transform.SetParent(slots[i].transform);
            canvases[i].transform.localScale = Vector3.one;
            canvases[i].transform.name = "Canvas_" + i;
            canvases[i].tag = "slot_canvas";
            if (canvases[i].HasNotComponent<Canvas>())
            {
                canvases[i].AddComponent<Canvas>();
            }
            canvases[i].GetComponent<Canvas>().overrideSorting = true;
            canvases[i].GetComponent<Canvas>().sortingOrder = 32767;

            GameObject placeholder = Instantiate(Resources.Load($"Items/Placeholder") as GameObject);
            placeholder.GetComponent<ItemData>().canv = i;
            placeholder.transform.name = "Placeholder";
            placeholder.transform.SetParent(canvases[i].transform);
            placeholder.transform.position = Vector3.zero;
            placeholder.transform.localScale = Vector3.one;
            placeholder.GetComponent<Image>().raycastTarget = enabled;
        }
    }
    public void InstantiateCoins()
    {
        coinObject = Instantiate(Resources.Load($"Items/coins_for_inventory") as GameObject);
        coinObject.transform.SetParent(inventoryPanel.transform);
        coinObject.transform.name = "Coins";
        coinObject.transform.position = Vector3.zero;
        coinObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        coinObject.transform.localScale = new Vector3(3, 3, 1);
        coinObject.transform.localPosition = new Vector3(-570, 350, (float)-26.11531);
        if (currentCoins >= 0)
        {
            coinObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            coinObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentCoins.ToString();
        }
        else
        {
            coinObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            coinObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Tommi's famous quotes: \"Valtteri why you broke the game?\" ";
        }
    }
    public void AddItemsToList()
    {
        int id = 0;
        bool query = false;
        addAllToInstantiate = true;

        if (resetCompleted == true)
        {
            inventoryDB = new InventoryDatabase();
            inventoryDB.ReadJsonData();
            addAllToInstantiate = true;
            addOneToInstantiate = false;
        }
        foreach (var item in inventoryDB.items)
        {
            id = item.id;
            Item checkItemsInStorage = inventoryDB.FetchItemByID(id);

            if (checkItemsInStorage.storage > 1 && checkItemsInStorage.id != -3 && checkItemsInStorage.id != -2)
            {
                for (int i = 0; i < checkItemsInStorage.storage; i++)
                {
                    InstantiateAddedItems(checkItemsInStorage.id);
                }
                query = true;
            }
            if (checkItemsInStorage.storage == 1 && checkItemsInStorage.id != -3 && checkItemsInStorage.id != -2)
            {
                for (int i = 0; i < checkItemsInStorage.storage; i++)
                {
                    InstantiateAddedItems(checkItemsInStorage.id);
                }
                query = true;
            }

        }
        resetCompleted = false;
        if (query == false)
        {
            Debug.Log("No items in storage!");
            resetCompleted = false;
        }

        // here you can test instantiate if all item storages are 0
    }

    public int value { get; set; }
    public List<GameObject> gameObjects;
    // Add item by id, check if they exists in database, instantiate them
    public void InstantiateAddedItems(int id)
    {
        if(resetCompleted == true)
        {
            inventoryDB = new InventoryDatabase();
            inventoryDB.ReadJsonData();
        }
        
        Item itemToAdd = inventoryDB.FetchItemByID(id);
        // Checks if item exists in database and stacks them by number
        if (itemToAdd.stackable == true && CheckIfItemExists(itemToAdd) && itemToAdd.id != -2)
        {
            for (int i = 0; i < items.Count; i++)
            {

                if (items[i].id == id && items[i].id != -2)
                {
                    ItemData data = canvases[i].transform.GetChild(1).GetComponent<ItemData>();
                    if (data.amount != itemToAdd.storage)
                    {
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.amount.ToString();
                    }
                    if (resetCompleted == true && itemToAdd.name == gameObjects[i].name)
                    {
                        GameObject go = gameObjects[i];
                        go.GetComponent<ItemData>().amount = data.amount;
                        go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.amount.ToString();
                    }
                    break;
                }
            }
        }
        else
        {
            // loops all added items and instantiates objects
            for (int i = 0; i < items.Count; i++)
            {
                if (canvases[i].transform.Find("Placeholder") != null && canvases[i].transform.childCount == 1)
                {
                    if (itemToAdd.id != -2)
                    {
                        if (resetCompleted == true)
                        {
                            i = 0 + (value);
                            value++;
                        }
                        items[i] = itemToAdd;
                        GameObject itemObj = Instantiate(Resources.Load($"Items/{itemToAdd.location}") as GameObject);
                        itemObj.GetComponent<ItemData>().item = itemToAdd;
                        itemObj.GetComponent<ItemData>().canv = i;
                        itemObj.transform.SetParent(canvases[i].transform);
                        itemObj.name = itemToAdd.name;
                        itemObj.tag = "item";
                        itemObj.transform.position = Vector3.zero;
                        itemObj.transform.localScale = Vector3.one;
                            // testausta varten if
                        if (itemObj.transform.position != GameObject.Find("Placeholder").transform.position)
                        {
                            itemObj.transform.position = canvases[i].transform.Find("Placeholder").position;
                        }
                        itemObj.GetComponent<Image>().raycastTarget = enabled;
                        gameObjects.Add(itemObj);
                        itemsCount++;
                        itemsToFlush[i] = items[i];
                    }
                    break;
                }
            }
            
        }
    }
    // checks if empty item exists
    private bool CheckIfItemExists(Item item)
    {
        for (int i = 0; i < items.Count; i++)

            if (items[i].id == item.id)
                return true;
        return false;
    }

}