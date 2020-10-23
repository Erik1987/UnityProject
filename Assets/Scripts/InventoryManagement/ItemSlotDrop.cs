using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotDrop : MonoBehaviour, IDropHandler
{
    private Inventory inv;
    public int idx;
    public static Vector3 vectorPos;
    void Start()
    {
        inv = GameObject.Find("InventoryPanel").GetComponent<Inventory>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) 
        {
            ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();

            // do this if empty slot
            if (inv.items[idx].id == -1 && droppedItem.item.id != -2)
            {
                inv.items[droppedItem.canv] = new Item();
                inv.items[idx] = droppedItem.item;
                droppedItem.canv = idx;
                RectTransform transf = (RectTransform)this.transform.GetChild(0);
                transf.GetComponent<ItemData>().canv = droppedItem.canv;
                transf.transform.SetParent(inv.canvases[droppedItem.canv].transform);
                transf.transform.localPosition = inv.canvases[droppedItem.canv].transform.localPosition;
                transf.transform.localPosition *= -1;
                transf.transform.localScale = new Vector3(1, 1, 1);
                vectorPos = transf.localPosition;
            }
            // if not empty
            else if(droppedItem.canv != idx && droppedItem.item.id != -2)
            {
                RectTransform transf = (RectTransform)this.transform.GetChild(1);
                transf.GetComponent<ItemData>().canv = droppedItem.canv;
                transf.transform.SetParent(inv.canvases[droppedItem.canv].transform);
                transf.transform.localPosition = inv.canvases[droppedItem.canv].transform.localPosition;
                transf.transform.localPosition *= -1;
                transf.transform.localScale = new Vector3(1, 1 ,1);
                vectorPos = transf.localPosition;
                droppedItem.canv = idx;
                droppedItem.transform.SetParent(this.transform);
                droppedItem.transform.position = vectorPos;
                inv.items[droppedItem.canv] = transf.GetComponent<ItemData>().item;
                inv.items[idx] = droppedItem.item;
            } 
            else if(droppedItem.canv == 0)
            {
                RectTransform transf = (RectTransform)this.transform.GetChild(0);
                transf.GetComponent<ItemData>().canv = droppedItem.canv;
                transf.transform.SetParent(inv.canvases[droppedItem.canv].transform);
                transf.transform.localPosition = inv.canvases[droppedItem.canv].transform.localPosition;
                transf.transform.localPosition *= -1;
                transf.transform.localScale = new Vector3(1, 1, 1);
                vectorPos = transf.localPosition;
            }
        }
    }
}
