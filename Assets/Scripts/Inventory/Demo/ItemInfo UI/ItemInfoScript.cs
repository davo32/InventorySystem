using InventoryBackend;
using TMPro;
using UnityEngine;


public class ItemInfoScript : MonoBehaviour
{
    public Inv_Item itemToDisplay;
    [SerializeField] private GameObject itemDescriptionContainer;
    [SerializeField] private TextMeshProUGUI itemNameText;

    [SerializeField] private GameObject contentPrefab;
    

    public void Setup(Inv_Item DisplayItem)
    {
        itemToDisplay = DisplayItem;

        
        itemNameText.text = itemToDisplay.ItemName;
        
        if (itemDescriptionContainer.transform.childCount > 0)
        {
            for (int i = 0; i < itemDescriptionContainer.transform.childCount; i++)
            {
                Destroy(itemDescriptionContainer.transform.GetChild(i).gameObject);
            }
        }


        switch (itemToDisplay)
        {
            case Inv_Consumable:
                {
                    Debug.Log("Consumable Item");
                    Inv_Consumable consumableItem = (Inv_Consumable)itemToDisplay;

                    GameObject go1 = Instantiate(contentPrefab);
                    go1.transform.SetParent(itemDescriptionContainer.transform);
                    go1.GetComponent<StatSlot>().SetStat("Quantity: ",consumableItem.Quantity);

                    GameObject go2 = Instantiate(contentPrefab);
                    go2.transform.SetParent(itemDescriptionContainer.transform);
                    go2.GetComponent<StatSlot>().SetStat("Heal: ", consumableItem.Amount);

                    break;
                }
            case Inv_Armor:
                {
                    Debug.Log("Armor Item");
                    Inv_Armor ArmorItem = (Inv_Armor)itemToDisplay;

                    GameObject go1 = Instantiate(contentPrefab);
                    go1.transform.SetParent(itemDescriptionContainer.transform);
                    go1.GetComponent<StatSlot>().SetStat("Defense: ",ArmorItem.Defense);

                    break;
                }
            case Inv_QuestItem:
                {
                    Debug.Log("Quest Item");
                    Inv_QuestItem questItem = (Inv_QuestItem)itemToDisplay;

                    GameObject go1 = Instantiate(contentPrefab);
                    go1.transform.SetParent(itemDescriptionContainer.transform);
                    go1.GetComponent<StatSlot>().SetStat("Quest #",1);


                    break;
                }
            case Inv_Shield:
                {
                    Debug.Log("Shield Item");
                    Inv_Shield shieldItem = (Inv_Shield)itemToDisplay;

                    GameObject go1 = Instantiate(contentPrefab);
                    go1.transform.SetParent(itemDescriptionContainer.transform);
                    go1.GetComponent<StatSlot>().SetStat("Defense: ",shieldItem.Defense);

                    break;
                }
            case Inv_Weapon: 
                {
                    Debug.Log("Weapon Item");
                    Inv_Weapon weaponItem = (Inv_Weapon)itemToDisplay;

                    GameObject go1 = Instantiate(contentPrefab);
                    go1.transform.SetParent (itemDescriptionContainer.transform);
                    go1.GetComponent<StatSlot>().SetStat("Damage: ",weaponItem.Damage);

                    break;
                }
        }
    }
}
