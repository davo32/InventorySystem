using UnityEngine;
using InventoryBackend;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    private InventoryStruct inventory = new InventoryStruct(25,25);
    private List<GameObject> slots = new List<GameObject>();
    [SerializeField] private GameObject SlotPrefab;
    [SerializeField] private ActionMenu actionMenuScript;

    private void Start()
    {
        StarterPack();
        SetupInventory();
    }

    void SetupInventory()
    {
        if (slots.Count == 0)
        {
            for (int i = 0; i < inventory.GetMaxSize(); i++)
            {
                GameObject slot = Instantiate(SlotPrefab);
                slot.transform.SetParent(gameObject.transform);
                slots.Add(slot);
            }
        }
        int counter = 0;

        foreach (Inv_Item item in inventory.GetInventory())
        {
            slots[counter].GetComponent<Inv_Slot>().SetupSlot(item);
            counter++;
        }

        
            actionMenuScript.SetReferenceInventory(ref inventory);
        
    }
    void StarterPack()
    {
        inventory.AddItem(new Inv_Weapon(Resources.Load<Sprite>("BrokenSword"), "Broken Sword", 10,1, Quality.COMMON));
        inventory.AddItem(new Inv_Armor(Resources.Load<Sprite>("BrokenShield"), "Broken Shield",10, 1, Quality.COMMON));
        inventory.AddItem(new Inv_Consumable(Resources.Load<Sprite>("minHP"), "Minor Health Potion",20, 5, Quality.RARE));
    }

    void Test()
    {
        inventory.AddItem(new Inv_QuestItem(Resources.Load<Sprite>("PoisonBottle"), "Juliette's Poison", 2, Quality.RARE));
        SetupInventory();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            Test();
        }
    }


}
