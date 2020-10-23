using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static string path = Application.persistentDataPath + "/player.save";
    public static bool fileExists = true;
    public static void SavePlayer (Player player)
    {
        BinaryFormatter bform = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData pdata = new PlayerData(player);
        bform.Serialize(stream, pdata);
        stream.Close();
    }
    public static PlayerData LoadPlayer()
    {
        if (File.Exists(path))
        {
            BinaryFormatter bform = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = bform.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file does not exist in " + path);
            fileExists = false;
            return null;
        }
    }
}
