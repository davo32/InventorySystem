
using TMPro;
using UnityEngine;

namespace InventoryBackend
{
    public class Inv_Consumable : Inv_Item
    {
        public int Amount;

        public Inv_Consumable() { }
        public Inv_Consumable(Sprite s, string name, int amount, int quantity, Quality q)
        {
            itemSprite = s;
            ItemName = name;
            Amount = amount;
            Quantity = quantity;
            quality = q;
        }
        public Inv_Consumable(Inv_Consumable copyData)
        {
            itemSprite = copyData.itemSprite;
            ItemName = copyData.ItemName;
            Amount = copyData.Amount;
            Quantity = copyData.Quantity;
            quality = copyData.quality;
        }

        public override void Use(TextMeshProUGUI text)
        {
            Debug.Log("[SYSTEM] - This is the Consumable Class for Items");
            text.text = $"{ItemName} has been used";
        }

        //OVERLOADS - EQUAL : NOT EQUAL
        public static bool operator ==(Inv_Consumable item1, Inv_Consumable item2)
        {
            return (item1.itemSprite == item2.itemSprite)
                && (item1.ItemName == item2.ItemName)
                && (item1.Quantity == item2.Quantity)
                && (item1.quality == item2.quality)
                && (item1.Amount == item2.Amount);
        }
        public static bool operator !=(Inv_Consumable item1, Inv_Consumable item2)
        {
            return (item1.itemSprite != item2.itemSprite)
                && (item1.ItemName != item2.ItemName)
                && (item1.Quantity != item2.Quantity)
                && (item1.quality != item2.quality)
                && (item1.Amount == item2.Amount);
        }
    }
}
