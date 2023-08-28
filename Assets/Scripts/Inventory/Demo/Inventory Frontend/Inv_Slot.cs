using InventoryBackend;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class Inv_Slot : MonoBehaviour
{
    public Inv_Item item = null;
    private Sprite _defaultImage;
    [SerializeField] private Image slotImage;
    [SerializeField] private TextMeshProUGUI stackCountSlot;
    [SerializeField] private GameObject quantPanel;

    private GameObject ItemInfo;

    private CanvasGroup ActionMenuUI;

    public bool isShown = false;

    private void Awake()
    {
        _defaultImage = slotImage.sprite;
        ItemInfo = GameObject.FindGameObjectWithTag("ItemInfo");
    }
    private void Start()
    {
        ActionMenuUI = GameObject.FindGameObjectWithTag("ActionMenu").GetComponent<CanvasGroup>();

        GetComponent<Button>().onClick.AddListener(ActionMenu);
    }
    public void ActionMenu()
    {
        isShown = !isShown;
        if (item != null)
        {
            if (isShown)
            {
                ActionMenuUI.GetComponent<global::ActionMenu>().SetActiveSlot(this);
                ActionMenuUI.gameObject.transform.position = transform.position;
                ShowUI(ActionMenuUI);
            }
            else
            {
                ActionMenuUI.GetComponent<global::ActionMenu>().SetActiveSlot(null);
                HideUI(ActionMenuUI);
            }
        }
    }
    public void RefreshStack()
    {
        stackCountSlot.text = item?.Quantity.ToString();
    }
    public void SetupSlot(Inv_Item newItem = null)
    {
        item = newItem;
        if (item != null)
        {
            slotImage.sprite = newItem?.itemSprite;
        }
        else
        {
            slotImage.sprite = _defaultImage;
        }

        stackCountSlot.text = newItem?.Quantity.ToString();
    }
    public void ResetSlot()
    {
        slotImage.sprite = _defaultImage;
    }
    public void SetItem(Inv_Item newItem)
    {
        item = newItem;
    }
    public Inv_Item GetItem()
    {
        return item;
    }

    public void MouseOver()
    {
        if (item != null)
        {
           ShowUI(ItemInfo.GetComponent<CanvasGroup>());
           ItemInfo.GetComponent<ItemInfoScript>().Setup(item);
        }
    }
    public void MouseExit()
    {
        if (item != null)
        {
            HideUI(ItemInfo.GetComponent<CanvasGroup>());
        }
    }

    private void Update()
    {
        quantPanel.SetActive(item?.Quantity > 1);
        RefreshStack();
        if(item?.Quantity < 1)
            SetupSlot();
            //Destroy(gameObject);
        
    }

    void ShowUI(CanvasGroup cg)
    { 
        cg.alpha = 1.0f;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    void HideUI(CanvasGroup cg)
    {
        cg.alpha = 0.0f;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
}
