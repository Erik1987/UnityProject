using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = SaveSystem.path;
        if (File.Exists(path))
        {
        Debug.Log("Persistentpath: " +path);
        }
        else
        {
            GameObject go = GameObject.Find("LoadGame");
            //go.GetComponent<Button>().colors = new Color(231, 98, 76, 255);
            go.GetComponent<Button>().interactable = false;
            go.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(231, 98, 76, 255);
          
        }
    }
}
