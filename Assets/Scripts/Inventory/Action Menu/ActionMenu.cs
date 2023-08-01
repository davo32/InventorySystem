using InventoryBackend;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionMenu : MonoBehaviour
{
    private InventoryStruct inventory;
    private Inv_Slot activeSlot;

    private CanvasGroup ActionMenuUI;
    private ActionMenu ActionScript;

    [SerializeField] private TextMeshProUGUI Text;

    private void Start()
    {
        ActionMenuUI = gameObject.GetComponent<CanvasGroup>();
        ActionScript = gameObject.GetComponent<ActionMenu>();
    }

    public void SetReferenceInventory(ref InventoryStruct inv)
    { 
        inventory = inv;
    }

    public void SetActiveSlot(Inv_Slot active)
    {
        activeSlot = active;
    }

    public void Use()
    {
        activeSlot.item.Use(Text);
    }

    public void Examine()
    {
        
    }

    public void Drop()
    {
        Debug.Log($"[SYSTEM] - {activeSlot.item?.ItemName} has been dropped!");
        inventory.RemoveItem(activeSlot.item);
        activeSlot.SetupSlot();

        ActionMenuUI.alpha = 0.0f;
        ActionMenuUI.interactable = false;
        ActionMenuUI.blocksRaycasts = false;
        activeSlot.ResetSlot();
        ActionScript.SetActiveSlot(null);


    }
}
