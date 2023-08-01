using InventoryBackend;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Inv_Slot : MonoBehaviour
{
    public Inv_Item item = null;
    private Sprite defaultImage;
    [SerializeField] private Image slotImage;
    [SerializeField] private TextMeshProUGUI stackCountSlot;

    [SerializeField] private GameObject QuantPanel;

    private CanvasGroup ActionMenuUI;
    private ActionMenu ActionScript;

    private bool isShown = false;
    private bool hasItem;

    private void Awake()
    {
        defaultImage = slotImage.sprite;
    }
    private void Start()
    {

        ActionMenuUI = GameObject.FindGameObjectWithTag("ActionMenu").GetComponent<CanvasGroup>();
        ActionScript = ActionMenuUI.gameObject.GetComponent<ActionMenu>();

        GetComponent<Button>().onClick.AddListener(ActionMenu);
    }
    public void ActionMenu()
    {
        isShown = !isShown;
        if (item != null)
        {
            if (isShown)
            {
                ActionMenuUI.alpha = 1.0f;
                ActionMenuUI.interactable = true;
                ActionMenuUI.blocksRaycasts = true;
                ActionScript.SetActiveSlot(this);
            }
            else
            {
                ActionMenuUI.alpha = 0.0f;
                ActionMenuUI.interactable = false;
                ActionMenuUI.blocksRaycasts = false;
                ActionScript.SetActiveSlot(null);
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
        slotImage.sprite = newItem?.itemSprite;
        stackCountSlot.text = newItem?.Quantity.ToString();

        //if (newItem == null) hasItem = false;
        //else hasItem = true;
    }

    public void ResetSlot()
    {
        slotImage.sprite = defaultImage;
    }
    public void SetItem(Inv_Item newItem)
    {
        item = newItem;
    }
    public Inv_Item GetItem()
    {
        return item;
    }
    private void Update()
    {
        QuantPanel.SetActive(item?.Quantity > 1);
    }
}
