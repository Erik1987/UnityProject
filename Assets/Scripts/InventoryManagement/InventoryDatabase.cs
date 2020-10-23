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
    Item newItem = new Item();
    string data;

    // these are attributes for a new item to be saved for JsonDB (if these are not called no item will be savad)
    public bool setAddItemTrue = false;
    
    // JsonDB path (Do not change it unless you implement IOS/Android system)
    string PATH = Application.streamingAssetsPath + "/Items.json";
   

     void Start()
    {
        // if you want to add an item, set item before ReadJsonDAta()
        // and AddNewItem()
        ReadJsonData();
    }

    //AddNewItem(setLocation, setName, setType, setDamage, setDefence, setConsumption, setGain, setStackable, setItemsInStorage, setCost, saveItem);
    public void AddNewItem(string setLocation, string setName, string setType, int setDamage, int setDefence, int setConsumption
        , int setGain, bool setStackable, int setItemsInStorage, int setCost, bool saveItem)
    {   
        
        if(saveItem == true)
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
            if (items != null)
            {
                if (itemsToJson != null && newItem != null)
                {
                    File.WriteAllText(PATH, itemsToJson);

                for (int i = 0; i < items.Length; i++)
                {
                    database.Add(items[i]);
                }
                }
            } else if(itemsToJson != null && newItem == null)
            {
                    File.WriteAllText(PATH, itemsToJson);

                    for (int i = 0; i < items.Length; i++)
                    {
                        database.Add(items[i]);
                    }
            }
            else
            {
                File.WriteAllText(PATH, "{ }");
                database = null;
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
    public Item[] ReadJsonData()
    {
        data = File.ReadAllText(PATH);
        //print(data);
        if (data != "")
        {
            items = JsonHelper.FromJson<Item>(data);
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
