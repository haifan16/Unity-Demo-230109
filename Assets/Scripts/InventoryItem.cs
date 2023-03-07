using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public ItemData _itemData;
    public int _stackSize;

    public InventoryItem(ItemData _item) {
        _itemData = _item;
        AddToStack();
    }

    public void AddToStack() {
        _stackSize++;
    }

    public void RemoveFromStack() {
        _stackSize--;
    }
}
