using TMPro;
using UnityEngine;

namespace InventoryBackend
{
    public class Inv_QuestItem : Inv_Item
    {
        public Inv_QuestItem() { }
        public Inv_QuestItem(Sprite s, string name, int quantity,bool stackable, Quality q)
        {
            itemSprite = s;
            ItemName = name;
            Quantity = quantity;
            isStackable = stackable;
            quality = q;
        }

        public Inv_QuestItem(Inv_QuestItem copyData)
        {
            itemSprite = copyData.itemSprite;
            ItemName = copyData.ItemName;
            Quantity = copyData.Quantity;
            isStackable = copyData.isStackable;
            quality = copyData.quality;
        }

        public override void Use(TextMeshProUGUI text)
        {
            Debug.Log("[SYSTEM] - This is the QuestItem Class for Items");
            text.text = $"{ItemName} has been handed in";
        }
    }
}
