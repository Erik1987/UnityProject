using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class GenericListExtensions
{
    public static string ToString<T>(this IList<T> list)
    {
        return string.Join(", ", list);
    }
}
// this module is a database for adding new items only
// to be instantiated later
// todo more functionality to store player stats and items possibly through Inventory.cs
public class InventoryDatabase : MonoBehaviour
{

    List<Item> database = new List<Item>();
    public Item[] items = new Item[0];
    public Item[] itemsForStorage = new Item[0];
    public static string storageName = "";
    public static int storageAmount = 0;
    public bool ifOnChangedAndSaved = false;
    Item newItem = new Item();
    string data;
    public bool storageChange = false;
    public int uniqueIDForInventory = -5;

    // these are attributes for a new item to be saved for JsonDB (if these are not called no item will be savad)
    public bool setAddItemTrue = false;

    // JsonDB path (Do not change it unless you implement IOS/Android system)
    string PATH = Application.streamingAssetsPath + "/Items.json";
    string BackUpPath = Application.streamingAssetsPath + "/Backup/Items.json";


    void Start()
    {
        // if you want to add an item, set item before ReadJsonDAta()
        // and AddNewItem()
        ReadJsonData();
    }
    public void OnChange(string locationName, int newAmount)
    {
        storageName = locationName;
        storageAmount = newAmount;
        ReadJsonData();
        ItemsToBeInstantiated();
        ReadJsonData();
        if (ifOnChangedAndSaved == true)
        {
            var player = GameObject.FindGameObjectsWithTag("pelaaja").FirstOrDefault();
            if (player)
            {
                var inv = player.transform.GetComponentInChildren<Inventory>();

                if (inv)
                {
                    inv.ResetInventory();
                    inv.AddItemsToList();
                    storageName = "";
                }
            }
        }
    }
    public void ItemsToBeInstantiated()
    {
        // Inventory.cs where Instantiates are
        FetchItemByLocation(storageName, storageAmount);
        if (storageName != "")
        {
            foreach (var item in items)
            {
                if (item.location == storageName)
                {
                    var player = GameObject.FindGameObjectsWithTag("pelaaja").FirstOrDefault();
                    if (player)
                    {
                        var inv = player.transform.GetComponentInChildren<Inventory>();
                        if (inv)
                        {
                            storageChange = true;
                            Debug.Log("Storage changed.");
                            uniqueIDForInventory = item.id;
                            inv.uniqueShopID = item.id;

                            if (storageName == "coins_for_inventory")
                            {
                                Inventory.coins = item.storage;
                            }
                        }
                    }
                }
            }
        }
        if (items != null && storageChange != false && storageName != "Placeholder")
        {
            SaveJsonData();
            ifOnChangedAndSaved = true;
        }
    }
   

    //AddNewItem(setLocation, setName, setType, setDamage, setDefence, setConsumption, setGain, setStackable, setItemsInStorage, setCost, saveItem);
    public void AddNewItem(string setLocation, string setName, string setType, int setDamage, int setDefence, int setConsumption
        , int setGain, bool setStackable, int setItemsInStorage, int setCost, bool saveItem)
    {

        if (saveItem == true)
        {
            setAddItemTrue = true;
        }
        // new item added only if true is given
        // only prefabs with same setLocation names will be instantiated
        if (setAddItemTrue == true)
        {
            Array.Resize<Item>(ref items, items.Length + 1);

            newItem = new Item((items.Length - 1), setLocation, setName, setType, setDamage, setDefence, setConsumption,
                setGain, setStackable, setItemsInStorage, setCost);
            items[items.Length - 1] = newItem;
            Debug.Log("Item :" + items[items.Length - 1].name + " added.");

            for (int i = 0; i < items.Length; i++)
            {
                database.Add(items[i]);
            }
            setAddItemTrue = false;
            if (saveItem == true && FetchItemByID(items.Length - 1) != null)
            {
                SaveJsonData();
            }
            else
            {
                Debug.Log("Item already exists in JsonDB");
            }
        }
    }
    public void SaveJsonData()
    {
        string itemsToJson = JsonHelper.ToJson(items, true);
        string itemsToJson2 = JsonHelper.ToJson(itemsForStorage, true);
        File.WriteAllText(BackUpPath, itemsToJson2);
        //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(itemsToJson2);
        // System.Text.Encoding.UTF8.GetString(bytes);
        //File.WriteAllBytes(BackUpPath, bytes);

        if (items != null && itemsToJson != null && newItem != null && storageChange == false && File.Exists(PATH))
        {
            File.WriteAllText(PATH, itemsToJson);
            UnityEngine.Debug.Log("JSON Saved");

            for (int i = 0; i < items.Length; i++)
            {
                database.Add(items[i]);
            }

        }
        else if (items != null && itemsToJson != null && newItem == null && storageChange == false && File.Exists(PATH))
        {
            File.WriteAllText(PATH, itemsToJson);
            UnityEngine.Debug.Log("JSON Saved");

            for (int i = 0; i < items.Length; i++)
            {
                database.Add(items[i]);
            }
        }
        else if (items != null && itemsToJson != null && newItem != null && storageChange == true && File.Exists(PATH))
        {
            File.WriteAllText(PATH, itemsToJson);
            UnityEngine.Debug.Log("JSON Saved");

            for (int i = 0; i < items.Length; i++)
            {
                database.Add(items[i]);
            }
        }
        else if (items != null && itemsToJson != null && newItem == null && storageChange == true && File.Exists(PATH))
        {
            File.WriteAllText(PATH, itemsToJson);
            UnityEngine.Debug.Log("JSON Saved");

            for (int i = 0; i < items.Length; i++)
            {
                database.Add(items[i]);
            }
        }
        else
        {
            File.WriteAllText(PATH, "{ }");
            database = null;
            Debug.Log("JSON database emptied. ");
        }
    }


    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < items.Count(); i++)
            if (items[i].id == id)
            {
                return items[i];
            }
        return null;
    }

    public Item FetchItemByLocation(string location, int amount)
    {
        for (int i = 0; i < items.Count(); i++)
            if (items[i].location == location)
            {
                items[i].storage = items[i].storage + amount;
                Debug.Log("Item added to inventory or storage changed. ");
                return items[i];

            }
        return null;
    }

    public Item[] ReadJsonData()
    {
        data = File.ReadAllText(PATH);

        //print(data);
        if (data != "")
        {
            items = JsonHelper.FromJson<Item>(data);
            itemsForStorage = JsonHelper.FromJson<Item>(data);
            int count = items.Length;
            int lastIndex = count - 1;
        }
        return items;
    }
    void ReadJsonDataString()
    {
        string data = File.ReadAllText(PATH);
    }
}
