using UnityEngine;
using UnityEngine.UI;

public class TreasureProps : MonoBehaviour
{
    public string name;
    public int price;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool dialogActive;
    private bool touchingItem;
    private Image dialogBackground;
    InventoryDatabase inventoryDatabase = new InventoryDatabase();
    private bool storeInitiated = false;
    //GameObject player = GameObject.Find("Player");
    //Player playerScript = player.GetComponent<Player>();
    // Start is called before the first frame update

    private void InitiateStore()
    {
        dialogBox = GameObject.FindWithTag("dialogBox");
        dialogText = GameObject.FindWithTag("dialogText").GetComponent<Text>();
        dialogBackground = GameObject.FindWithTag("dialogBox").GetComponent<Image>();
        dialog = "Do you want to buy " + name + " for " + price + " coins? Y/N";
        storeInitiated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!storeInitiated)
        {
            InitiateStore();
        };

        if (Input.GetKeyDown(KeyCode.Q) && touchingItem)
        {

            dialogText.text = dialog;
            dialogBackground.enabled = true;
            dialogText.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Y) && dialogBackground.enabled && touchingItem)
        {
            if (GameObject.Find("Player").GetComponent<Player>().coins >= price)
            {
                Destroy(this.gameObject);
                GameObject.Find("Player").GetComponent<Player>().coins -= price;
                var split = gameObject.name.Split('(');
                inventoryDatabase.OnChange(split[0], 1);
                // to use item call it like in below
                //inventoryDatabase.OnChange(split[0], -1);

            }

        }
        else if (Input.GetKeyDown(KeyCode.N) && dialogBackground.enabled && touchingItem)
        {
            dialogBackground.enabled = false;
            dialogText.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "pelaaja")
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
