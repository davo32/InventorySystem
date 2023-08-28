using UnityEngine;
using InventoryBackend;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    private InventoryStruct inventory = new InventoryStruct(25,25);
    private List<GameObject> slots = new List<GameObject>();
    [SerializeField] private GameObject SlotPrefab;
    [SerializeField] private ActionMenu ActionScript;
    [SerializeField] private bool isPlayerInventory;
    [SerializeField] private Inventory PlayerInventory;
    private void Start()
    {
        if (isPlayerInventory)
        {
            PlayerStarterPack();
            SetupInventory();
            ActionScript.SetReferenceInventory(ref inventory);
        }
        else
        {
            EnemyStarterPack();
            SetupInventory();
        }
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
        
    }
    
    void PlayerStarterPack()
    {
        inventory.AddItem(new Inv_Weapon(LoadSprite("BrokenSword"), "Broken Sword", 10,1,false, Quality.COMMON));
        inventory.AddItem(new Inv_Shield(LoadSprite("BrokenShield"), "Broken Shield",10, 1,false, Quality.COMMON));
        inventory.AddItem(new Inv_Consumable(LoadSprite("MinHP"), "Minor Health Potion",20, 5,true, Quality.RARE));
    }
    void EnemyStarterPack()
    {
        inventory.AddItem(new Inv_Weapon(LoadSprite("WoodenSpear"), "Goblin's Spear", 5, 1, false, Quality.COMMON));
        inventory.AddItem(new Inv_Shield(LoadSprite("WoodenShield"),"Goblin's Shield",5,1,false,Quality.COMMON));
    }

    public void TakeAll()
    {
        if(!isPlayerInventory)
            inventory.TakeAllItems(PlayerInventory.inventory,inventory);
            PlayerInventory.SetupInventory();
            SetupInventory();
    }

    void Test()
    {
        inventory.AddItem(new Inv_QuestItem(Resources.Load<Sprite>("PoisonBottle"), "Juliette's Poison", 2,true, Quality.RARE));
        SetupInventory();
    }

    //shorthand way of loading sprite from resources
    Sprite LoadSprite(string path)
    {
        return Resources.Load<Sprite>(path);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            Test();
        }
    }


}
