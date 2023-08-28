using System.Collections.Generic;
using UnityEngine;
namespace InventoryBackend
{
    public struct InventoryStruct
    {
        private List<Inv_Item> _inventoryItems;
        private int _maxInventorySize;
        private int _stackLimit;


        public InventoryStruct(int newInvSize, int newStackLimit)
        {
            _maxInventorySize = newInvSize;
            _stackLimit = newStackLimit;
            _inventoryItems = new List<Inv_Item>();
        }

        public int GetMaxSize()
        {
            return _maxInventorySize;
        }

        private bool CheckInventoryLimit()
        {
            Debug.Log($"*******************************************************************");
            Debug.Log($"[SYSTEM] - InventoryLimit is:  ({_maxInventorySize})");
            Debug.Log($"[SYSTEM] - Current InventorySize is:  ({_inventoryItems.Count + 1})");
            Debug.Log($"*******************************************************************");
            return (_inventoryItems.Count < _maxInventorySize);
        }

        private bool CheckItem(Inv_Item itemData)
        {
            if (_inventoryItems.Contains(itemData))
            {
                Debug.Log($"[SYSTEM] - Inventory Contains ({itemData.ItemName})");
                return true;
            }
            Debug.Log($"[SYSTEM] - Inventory Does NOT Contain ({itemData.ItemName})");
            return false;
        }

        public List<Inv_Item> GetInventory()
        {
            return _inventoryItems;
        }

        public void RemoveAll()
        {
            for (int i = 0; i < _inventoryItems.Count; i++)
            {
                _inventoryItems.RemoveAt(i);
            }
        }

        public void TakeAllItems(InventoryStruct invAddTo, InventoryStruct invRemoveFrom)
        {
            int itemAmount = invRemoveFrom.GetInventory().Count;
            for (int i = 0; i < itemAmount;i++)
            {
                invAddTo.AddItem(invRemoveFrom.GetInventory()[i]);
            }
            RemoveAll();
        }
        public void SetInventoryLimit(int newInvLimit)
        {
            _maxInventorySize = newInvLimit;
            Debug.Log($"[SYSTEM] - Inventory Limit ({_maxInventorySize})");
        }
        public void SetStackLimit(int newStackLimit)
        {
            _stackLimit = newStackLimit;
            Debug.Log($"[SYSTEM] - Stack Limit ({_stackLimit})");
        }
        public void JoinStack(Inv_Item itemData)
        {
            if (CheckItem(itemData) && itemData.Quantity < _stackLimit)
            {
                Inv_Item item = _inventoryItems.Find(x => x == itemData);
                int combinedQuantity = item.Quantity + itemData.Quantity;
                if (item.Quantity < _stackLimit && combinedQuantity < _stackLimit)
                {
                    _inventoryItems.Remove(item);
                    itemData.Quantity = combinedQuantity;
                    Debug.Log("[SYSTEM] - Stack Joined (SUCCESS)");
                }
            }
            else
            {
                Debug.Log("[ERROR] - Stack Joined (FAILURE)");
            }
        }
        public void SplitStack(Inv_Item itemData)
        {
            if (!CheckInventoryLimit())
            {
                Debug.Log("[ERROR] - INVENTORY FULL");
            }
            else
            {
                if (itemData.Quantity > 1)
                {
                    itemData.Quantity /= 2;
                    Inv_Item newStack = new Inv_Item(itemData);
                    _inventoryItems.Add(newStack);
                    Debug.Log($"[SYSTEM] - Item Split (SUCCESS)");
                }
            }
        }
        public void AddItem(Inv_Item itemData)
        {
            if (!CheckInventoryLimit())
            {
                Debug.Log("[ERROR] - INVENTORY FULL");
            }
            else
            {
                if (CheckItem(itemData) && itemData.isStackable)
                {
                    Inv_Item item = _inventoryItems.Find(x => x == itemData);
                    item.Quantity++;
                }
                else
                {
                    _inventoryItems.Add(itemData);
                }
                Debug.Log($"[SYSTEM] - Item Added ({itemData.ItemName})");
            }
        }
        public void RemoveItem(Inv_Item itemData)
        {
            if (!CheckItem(itemData))
            {
                Debug.Log($"[ERROR] - Item Removed (FAILURE)");
            }
            else
            {
                Inv_Item item = _inventoryItems.Find(x => x == itemData);
                if (item.Quantity > 1)
                {
                    item.Quantity--;
                }
                else 
                {
                    _inventoryItems.Remove(itemData);
                }
                Debug.Log($"[SYSTEM] - Item Removed (SUCCESS)");
            }
        }
    }
}
