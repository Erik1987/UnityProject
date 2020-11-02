using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    private Item item;
    private string data;
    private GameObject tooltip;

    void Start()
    {
        tooltip = GameObject.Find("Tooltip");
        tooltip.SetActive(false);
    }
    // if someone finds a better solution to Input.mousePosition to follow gameobject
    void Update()
    {
        if (tooltip.activeInHierarchy)
        {
            tooltip.GetComponent<RectTransform>();
            tooltip.transform.localScale = new Vector3((float)3.5, (float)3.5, 1);
            tooltip.transform.localPosition = new Vector3(-350, 80, 0);
            //tooltip.transform.localposition = (input.mouseposition / (float)11) + new vector3(-100,-10,0);
        }
    }
    public void Activate(Item item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }
    public void Deactivate()
    {
        tooltip.SetActive(false);
    }
    public void ConstructDataString()
    {
        if (item.type != "" && item.id != -3) ;
        {
            data = "<color=#f2f9f9><b>" + item.name + "</b></color>" + "\n<color=#f2f9f9>Type: " + item.type + "</color>" 
                + "\n<color=#dd2d08>Damage: + " + item.damage + "</color>" + "\n<color=#2de005>Defence: + " + item.defence + "</color>" 
                + "\n<color=#dd2d08>AP: - " + item.consumption + "</color>" + "\n<color=#2de005> Gain: + " + item.gain + "</color>" 
                + "\n<color=#ebcb04>Cost: " + item.cost + "</color>";
            tooltip.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data;
        }
        if(item.id == -3)
        {
            data = "<color=#f2f9f9><b>" + item.name + "</b></color>" + "\n<color=#ebcb04>Cost: " + item.storage + "</color>";
            tooltip.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data;
        }
    }
}
