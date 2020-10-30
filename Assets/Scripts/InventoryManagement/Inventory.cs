using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

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
    int slotAmount;

    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();
    public List<GameObject> canvases = new List<GameObject>();
    private GameObject coinObject;
    public static int coins = 0;
    private int currentCoins;

   
    private void Start()
    {
        inventoryDB = GetComponent<InventoryDatabase>();
        slotAmount = 6;
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

        // preferred way to add new item to jsonDB, delete after first run (remember to add last value to true if you want to save an item to JsonDB)
        //inventoryDB.AddNewItem("shield_wood_basic_1", "Wooden Shield", "Shield", 0, 2, 0, 0, false, 0, 30, true);

        InstantiateSlotsAndCanvases();

        // here items are instantiated based on storage in JSON file
        InstantiatedItems();

        // here coins are instantiated
        if (coins >= 0 || coins < 0)
        {
            InstantiateCoins();
        }
    }

    private void Update()
    {
        if (currentCoins != coins)
        {
            currentCoins = coins;
            coinObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentCoins.ToString();
        }
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
            canvases.Add(Instantiate(inventoryCanvas));
            canvases[i].GetComponent<ItemSlotDrop>().idx = i;
            canvases[i].transform.SetParent(slots[i].transform);
            canvases[i].transform.localScale = Vector3.one;
            canvases[i].transform.name = "Canvas_" + i;
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
        coinObject.transform.localPosition = new Vector3(-760, 350, (float)-26.11531);
        if (currentCoins >= 0)
        {
            coinObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            coinObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentCoins.ToString();
        }
        else
        {
            coinObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            coinObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentCoins.ToString();
        }
    }
    public void InstantiatedItems()
    {
        int id = 0;
        bool query = false;
        foreach (var item in inventoryDB.items)
        {
            id = item.id;
            Item checkItemsInStorage = inventoryDB.FetchItemByID(id);

            if (checkItemsInStorage.storage > 1 && checkItemsInStorage.id != -3 && checkItemsInStorage.id != -2)
            {
                for (int i = 0; i < checkItemsInStorage.storage; i++)
                {
                    AddItemAndInstantiate(checkItemsInStorage.id);
                }
                query = true;
            }
            if(checkItemsInStorage.storage == 1 && checkItemsInStorage.id != -3 && checkItemsInStorage.id != -2)
            {
                for (int i = 0; i < checkItemsInStorage.storage; i++)
                {
                    AddItemAndInstantiate(checkItemsInStorage.id);
                }
                query = true;
            }

        }
            if(query == false)
            {
                Debug.Log("No items in storage!");
            }
        // here you can test instantiate if all item storages are 0
    }

    // Add item by id, check if they exists in database, instantiate them
    public void AddItemAndInstantiate(int id)
    {
        Item itemToAdd = inventoryDB.FetchItemByID(id);
        // Checks if item exists in database and stacks them by number
        if (itemToAdd.stackable == true && CheckIfItemExists(itemToAdd) && itemToAdd.id != -2)
        {
            for (int i = 0; i < items.Count; i++)
            {

                if (items[i].id == id && items[i].id != -2)
                {
                    ItemData data = canvases[i].transform.GetChild(1).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.amount.ToString();
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
                        items[i] = itemToAdd;
                        GameObject itemObj = Instantiate(Resources.Load($"Items/{itemToAdd.location}") as GameObject);
                        itemObj.GetComponent<ItemData>().item = itemToAdd;
                        itemObj.GetComponent<ItemData>().canv = i;
                        itemObj.transform.SetParent(canvases[i].transform);
                        itemObj.name = itemToAdd.name;
                        itemObj.transform.position = Vector3.zero;
                        itemObj.transform.localScale = Vector3.one;
                        itemObj.GetComponent<Image>().raycastTarget = enabled;
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
