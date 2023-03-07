using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public static event Action<List<InventoryItem>> OnInventoryChange;

    public List<InventoryItem> _inventory = new List<InventoryItem>();
    private Dictionary<ItemData, InventoryItem> _itemDictionary = new Dictionary<ItemData, InventoryItem>();

    private void OnEnable() {
        // Coin
        Coin.OnCoinCollected += Add;
        Coin.OnCoinCollected += PlayPickupSound;
        // Juice
        Juice.OnJuiceCollected += Add;
        Juice.OnJuiceCollected += PlayPickupSound;
        // Chips
        Chips.OnChipsCollected += Add;
        Chips.OnChipsCollected += PlayPickupSound;
        // Cookie
        Cookie.OnCookieCollected += Add;
        Cookie.OnCookieCollected += PlayPickupSound;
    }

    private void OnDisable() {
        // Coin
        Coin.OnCoinCollected -= Add;
        Coin.OnCoinCollected -= PlayPickupSound;
        // Juice
        Juice.OnJuiceCollected -= Add;
        Juice.OnJuiceCollected -= PlayPickupSound;
        // Chips
        Chips.OnChipsCollected -= Add;
        Chips.OnChipsCollected -= PlayPickupSound;
        // Cookie
        Cookie.OnCookieCollected -= Add;
        Cookie.OnCookieCollected -= PlayPickupSound;
    }

    public void Add(ItemData _itemData) {
        if (_itemDictionary.TryGetValue(_itemData, out InventoryItem _item)) {
            _item.AddToStack();
            Debug.Log($"{_item._itemData._displayName} total stack is now {_item._stackSize}");
            OnInventoryChange?.Invoke(_inventory);
        } else {
            InventoryItem _newItem = new InventoryItem(_itemData);
            _inventory.Add(_newItem);
            _itemDictionary.Add(_itemData, _newItem);
            Debug.Log($"Added {_itemData._displayName} to the inventory for the first time");
            OnInventoryChange?.Invoke(_inventory);
        }
    }

    public void Remove(ItemData _itemData) {
        if (_itemDictionary.TryGetValue(_itemData, out InventoryItem _item)) {
            _item.RemoveFromStack();
            if (_item._stackSize == 0) {
                _inventory.Remove(_item);
                _itemDictionary.Remove(_itemData);
            }
            OnInventoryChange?.Invoke(_inventory);
        }
    }

    private void PlayPickupSound(ItemData _itemData) {
        FindObjectOfType<AudioManager>().Play("PickupSound");
    }
}
