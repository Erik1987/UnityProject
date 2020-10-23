using UnityEngine;
using UnityEngine.EventSystems;

//[RequireComponent(typeof(Image))]
public class ItemData : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler,
    IPointerExitHandler
{
    [SerializeField] private Canvas canvas; // = GameObject.Find();

    public Item item;
    public int amount = 1;
    public int canv;
    public char x = 'x';
    private Vector3 vectorPos;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Inventory inv;
    private float scaleFactor = 1.0f, width1, height1, width2, height2;
    private Tooltip tooltip;


    // needs to disable ranged attack
    public bool enableRangedAttack = true;

    private void Start()
    {
        inv = GameObject.Find("InventoryPanel").GetComponent<Inventory>();
        tooltip = inv.GetComponent<Tooltip>();

    }
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        width1 = Screen.width;
        height1 = Screen.height;
        

    }
    private bool ItemIsValid()
    {
        return item.id != -2 && item != null;
        
    }
    private void ifScreenSizeChanges(float x, float y)
    {
        width2 = Screen.width;
        height2 = Screen.height;
      
        if (width2 != x || height2 != y)
        {
            scaleFactor = ((width2 / width1) + (height2 / height1)) / 2;   
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        enableRangedAttack = true;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        if (ItemIsValid()) 
        {
            enableRangedAttack = false;
            rectTransform.anchoredPosition += eventData.delta;
            canvasGroup.alpha = .6f;
            canvasGroup.transform.localScale = new Vector3((float)2,(float)2, 1);
            canvasGroup.blocksRaycasts = false;
            //Debug.Log("Screen resol: " + Screen.currentResolution);
            //Debug.Log("Camera aspect ratio: " + Camera.main.aspect);
            ifScreenSizeChanges(width1, height1);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (ItemIsValid())
        {
            enableRangedAttack = false;
            rectTransform.anchoredPosition += eventData.delta / 1.5f; // rectTransform.localScale; // (float)scaleFactor; //or do  / canvas.scaleFactor;
            var mousepos = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (ItemIsValid())
        {
            canvasGroup.alpha = 1f;
            enableRangedAttack = true;
            rectTransform.SetParent(inv.canvases[canv].transform);
            rectTransform.transform.position = inv.canvases[canv].transform.position; // maybe unwanted
            canvasGroup.transform.localScale = new Vector3((float)1, (float)1, 1); 
            vectorPos = ItemSlotDrop.vectorPos;
            rectTransform.anchoredPosition3D = vectorPos;
            canvasGroup.blocksRaycasts = true;
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(ItemIsValid())
        {
            tooltip.Activate(item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
    } 
}
