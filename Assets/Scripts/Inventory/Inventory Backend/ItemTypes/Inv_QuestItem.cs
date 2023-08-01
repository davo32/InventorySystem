using TMPro;
using UnityEngine;

namespace InventoryBackend
{
    public class Inv_QuestItem : Inv_Item
    {
        public Inv_QuestItem() { }
        public Inv_QuestItem(Sprite s, string name, int quantity, Quality q)
        {
            itemSprite = s;
            ItemName = name;
            Quantity = quantity;
            quality = q;
        }

        public Inv_QuestItem(Inv_QuestItem copyData)
        {
            itemSprite = copyData.itemSprite;
            ItemName = copyData.ItemName;
            Quantity = copyData.Quantity;
            quality = copyData.quality;
        }

        public override void Use(TextMeshProUGUI text)
        {
            Debug.Log("[SYSTEM] - This is the QuestItem Class for Items");
            text.text = $"{ItemName} has been handed in";
        }

        //OVERLOADS - EQUAL : NOT EQUAL
        public static bool operator ==(Inv_QuestItem item1, Inv_QuestItem item2)
        {
            return (item1.itemSprite == item2.itemSprite)
                && (item1.ItemName == item2.ItemName)
                && (item1.Quantity == item2.Quantity)
                && (item1.quality == item2.quality);
        }
        public static bool operator !=(Inv_QuestItem item1, Inv_QuestItem item2)
        {
            return (item1.itemSprite != item2.itemSprite)
                && (item1.ItemName != item2.ItemName)
                && (item1.Quantity != item2.Quantity)
                && (item1.quality != item2.quality);
        }
    }
}
