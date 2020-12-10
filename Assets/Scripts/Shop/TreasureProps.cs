using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TreasureProps : MonoBehaviour
{
    private V2Inventory v2Inventory;
    public GameObject itemButton;
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
    public bool isSpawned = false;
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

    private void Start()
    {
        v2Inventory = GameObject.FindGameObjectWithTag("pelaaja").GetComponent<V2Inventory>();
    }

    // Update is called once per frame
    void Update()
    {

        var player = GameObject.FindGameObjectsWithTag("pelaaja").FirstOrDefault();
        var inv = player.transform.GetComponentInChildren<Inventory>();

        if (!storeInitiated)
        {
            InitiateStore();
        };

        if (Input.GetKeyDown(KeyCode.F) && touchingItem)
        {

            dialogText.text = dialog;
            dialogBackground.enabled = true;
            dialogText.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Y) && dialogBackground.enabled && touchingItem)
        {
            if (GameObject.Find("Player").GetComponent<Player>().coins >= price /*&& inv.inventoryFull != true*/)
            {
                for (int i = 0; i < v2Inventory.slots.Length; i++)
                {
                    if(v2Inventory.isInventoryFull[i] == false)
                    {
                        v2Inventory.isInventoryFull[i] = true;
                        GameObject.Find("Player").GetComponent<Player>().coins -= price;
                        Instantiate(itemButton, v2Inventory.slots[i].transform, false);
                        Destroy(gameObject);
                        break;
                    }
                }

                //Destroy(this.gameObject);
                
                var split = gameObject.name.Split('(');
                FindObjectOfType<AudioManager>().Play("buyfromshop");
                
                //HUOM tämä crashaa pelin jos jostain syystä inventory pääsee täyttymään kokonaan pelikerran aikana
               /* if (inv.inventoryFull != true)
                {
                    inventoryDatabase.OnChange(split[0], 1);
                }*/
                // to use item call it like in below
                //inventoryDatabase.OnChange(split[0], -1);

            } /*else if (GameObject.Find("Player").GetComponent<Player>().coins >= price && inv.inventoryFull)
            {
                dialogText.text = "Your inventory is full";
            }*/
            else
            {
                dialogText.text = "You need to have more money";
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
