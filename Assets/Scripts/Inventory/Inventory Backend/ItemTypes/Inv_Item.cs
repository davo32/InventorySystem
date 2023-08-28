using TMPro;
using UnityEngine;
namespace InventoryBackend
{
    public enum Quality
    {
        NONE,
        COMMON,
        RARE,
        EPIC,
        EXOTIC,
        MYTHIC
    }

    public class Inv_Item 
    {
        public Sprite itemSprite;
        public string ItemName;
        public int Quantity;
        public bool isStackable;
        public Quality quality;

        public Inv_Item() { }
        //Constructor - Default
        public Inv_Item(Sprite s, string name, int quantity,bool stackable, Quality q)
        {
            itemSprite = s;
            ItemName = name;
            Quantity = quantity;
            isStackable = stackable;
            quality = q;
        }

        //Copy Constructor
        public Inv_Item(Inv_Item copyData)
        {
            itemSprite = copyData.itemSprite;
            ItemName = copyData.ItemName;
            Quantity = copyData.Quantity;
            isStackable = copyData.isStackable;
            quality = copyData.quality;
        }

        public virtual void Use(TextMeshProUGUI text)
        {
            Debug.Log("[SYSTEM] - This is the Base Class for Items");
        }
    }
}
