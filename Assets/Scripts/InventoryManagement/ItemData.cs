using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//[RequireComponent(typeof(Image))]
public class ItemData : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler,
    IPointerExitHandler
{
    //[SerializeField] private Canvas canvas; // = GameObject.Find();

    public Item item;
    public int amount = 1;
    public int canv;
    private char x = 'x';
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
            //eventData.selectedObject = GameObject.Find(rectTransform.transform.name);
            //Transform got = GameObject.Find($"Canvas_{canv}").transform;
            //transform.SetParent(got);
            //Debug.Log("RectAnchoredpos: " + rectTransform.anchoredPosition);
            //Debug.Log("WorldToScreenPoint: " + Camera.main.ScreenToViewportPoint(rectTransform.anchoredPosition));
        }
    }

    public async void OnDrag(PointerEventData eventData)
    {
        var screenModifier = 0;
        var modifier = 1.0f;
        if (ItemIsValid())
        {
            enableRangedAttack = false;
            if (Screen.width == 1280 && Screen.height == 547)
            {
                screenModifier = 1;
                modifier = 1 + 0.547f;
                //Debug.Log("Using Free aspect scaling factor");
            }
            else if(Screen.width == 684 && Screen.height == 547)
            {
                screenModifier = 2;
                modifier = 1 + 0.547f;
                //Debug.Log("Using 5:4 acpect scaling factor");
            }
            else if (Screen.width == 729 && Screen.height == 547)
            {
                screenModifier = 3;
                modifier = 1 + 0.547f;
                //Debug.Log("Using 4:3 acpect scaling factor");
            }
            else if (Screen.width == 820 && Screen.height == 547)
            {
                screenModifier = 4;
                modifier = 1 + 0.547f;
                //Debug.Log("Using 3:2 acpect scaling factor");
            }
            else if (Screen.width == 875 && Screen.height == 547)
            {
                screenModifier = 5;
                modifier = 1 + 0.547f;
                //Debug.Log("Using 16:10 acpect scaling factor");
            }
            else if (Screen.width == 972 && Screen.height == 547)
            {
                screenModifier = 6;
                modifier = 1 + 0.547f;
                //Debug.Log("Using 16:9 acpect scaling factor");
            }
            else if (Screen.width == 1024 && Screen.height == 768)
            {
                screenModifier = 7;
                modifier = 1 + 0.768f;
                //Debug.Log("Using standalone acpect scaling factor");
            }
            else if (Screen.width == 1920 && Screen.height == 1080)
            {
                screenModifier = 8;
                modifier = 1 + 1.080f;
                //Debug.Log("Using HD acpect scaling factor");
            }
            //rectTransform.anchoredPosition += eventData.delta / 1.547f; // rectTransform.localScale; // (float)scaleFactor; //or do  / canvas.scaleFactor;
            switch (screenModifier)
        {
                // for freeaspect = 1280x547
                case 1:
                    rectTransform.anchoredPosition += new Vector2(eventData.delta.x / 1.5f, eventData.delta.y / 1.5f);
                    break;
                // for 5:4 = 684x547
                case 2:
                    rectTransform.anchoredPosition += new Vector2(eventData.delta.x / 1.5f, eventData.delta.y / 1.5f);
                    break;
                // for 4:3 = 729x547
                case 3:
                    rectTransform.anchoredPosition += new Vector2(eventData.delta.x / 1.5f, eventData.delta.y / 1.5f);
                    break;
                // for 3:2 = 820x547
                case 4:
                    rectTransform.anchoredPosition += new Vector2(eventData.delta.x / 1.5f, eventData.delta.y / 1.5f);
                    break;
                // for 16:10 = 875x547
                case 5:
                    rectTransform.anchoredPosition += new Vector2(eventData.delta.x / 1.5f, eventData.delta.y / 1.5f);
                    break;
                // for 16:9 = 972x547
                case 6:
                    rectTransform.anchoredPosition += new Vector2(eventData.delta.x / 1.5f, eventData.delta.y / 1.5f);
                    break;
                // for standalone = 1024x768
                case 7:
                    rectTransform.anchoredPosition += new Vector2(eventData.delta.x / 1.6f, eventData.delta.y / 1.6f);
                    break;
                // for HD = 1920x1080
                case 8:
                    rectTransform.anchoredPosition += new Vector2(eventData.delta.x / 4.920f, eventData.delta.y / 4.080f);
                    break;
                default:
                    rectTransform.anchoredPosition += new Vector2(eventData.delta.x / 1.5f, eventData.delta.y / 1.5f);
                    break;
        }
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
