using InventoryBackend;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inv_Shield : Inv_Item
{
    public int Defense;
    public Inv_Shield() { }

    public Inv_Shield(Sprite s, string name, int defense, int quantity, Quality q)
    { 
        itemSprite = s;
        ItemName = name;
        Defense = defense;
        Quantity = quantity;
        quality = q;
    }

    public Inv_Shield(Inv_Shield copyData)
    { 
        itemSprite = copyData.itemSprite;
        ItemName = copyData.ItemName;
        Defense = copyData.Defense;
        Quantity = copyData.Quantity;
        quality = copyData.quality;
    }

    public override void Use(TextMeshProUGUI text)
    {
        Debug.Log("[SYTSTEM] - This is the Shield Class for Items");
        text.text = $"{ItemName} has been Equipped";
    }

    //OVERLOADS - EQUAL : NOT EQUAL
    public static bool operator ==(Inv_Shield item1, Inv_Shield item2)
    {
        return (item1.itemSprite == item2.itemSprite)
            && (item1.ItemName == item2.ItemName)
            && (item1.Quantity == item2.Quantity)
            && (item1.quality == item2.quality)
            && (item1.Defense == item2.Defense);
    }
    public static bool operator !=(Inv_Shield item1, Inv_Shield item2)
    {
        return (item1.itemSprite != item2.itemSprite)
            && (item1.ItemName != item2.ItemName)
            && (item1.Quantity != item2.Quantity)
            && (item1.quality != item2.quality)
            && (item1.Defense == item2.Defense);
    }
}
