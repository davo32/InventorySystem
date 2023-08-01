using TMPro;
using UnityEngine;

namespace InventoryBackend
{
    public class Inv_Armor : Inv_Item
    {
        public int Defense;

        public Inv_Armor(Sprite s, string name, int defense, int quantity, Quality q)
        {
            itemSprite = s;
            ItemName = name;
            Defense = defense;
            Quantity = quantity;
            quality = q;
        }

        public Inv_Armor(Inv_Armor copyData)
        {
            itemSprite = copyData.itemSprite;
            ItemName = copyData.ItemName;
            Defense = copyData.Defense;
            Quantity = copyData.Quantity;
            quality = copyData.quality;
        }

        public override void Use(TextMeshProUGUI text)
        {
            Debug.Log("[SYSTEM] - This is the Armor Class for Items");
            text.text = $"{ItemName} has been Equipped";
        }

        //OVERLOADS - EQUAL : NOT EQUAL
        public static bool operator ==(Inv_Armor item1, Inv_Armor item2)
        {
            return (item1.itemSprite == item2.itemSprite)
                && (item1.ItemName == item2.ItemName)
                && (item1.Quantity == item2.Quantity)
                && (item1.quality == item2.quality)
                && (item1.Defense == item2.Defense);
        }
        public static bool operator !=(Inv_Armor item1, Inv_Armor item2)
        {
            return (item1.itemSprite != item2.itemSprite)
                && (item1.ItemName != item2.ItemName)
                && (item1.Quantity != item2.Quantity)
                && (item1.quality != item2.quality)
                && (item1.Defense == item2.Defense);
        }
    }
}
