using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class TreasureProps : MonoBehaviour
{
    public string name;
    public string price;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool dialogActive;
    private bool touchingItem;
    private Image dialogBackground;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox = GameObject.FindWithTag("dialogBox");
        dialogText = GameObject.FindWithTag("dialogText").GetComponent<Text>();
        dialogBackground = GameObject.FindWithTag("dialogBox").GetComponent<Image>();
        dialog = "Do you want to buy " + name + " for " + price + " coins? Y/N";
        //todo add buttons yes & no
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && touchingItem)
        {

            dialogText.text = dialog;
            dialogBackground.enabled = true;
            dialogText.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "pelaaja")
        {
            touchingItem = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("pelaaja"))
        {
            touchingItem = false;
            dialogBackground.enabled = false;
            dialogText.enabled = false;
        }
    }
}
