using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private List<InventorySlot> _inventorySlots = new List<InventorySlot>(8);

    private void OnEnable() {
        Inventory.OnInventoryChange += DrawInventory;
    }

    private void OnDisable() {
        Inventory.OnInventoryChange -= DrawInventory;
    }

    private void ResetInventory() {
        foreach (Transform _childTransform in transform) {
            Destroy(_childTransform.gameObject);
        }
        _inventorySlots = new List<InventorySlot>(8);
    }

    private void DrawInventory(List<InventoryItem> _inventory) {
        ResetInventory();

        for (int i = 0; i < _inventorySlots.Capacity; i++) {
            CreateInventorySlot();
        }

        for (int i = 0; i < _inventory.Count; i++) {
            _inventorySlots[i].DrawSlot(_inventory[i]);
        }
    }

    private void CreateInventorySlot() {
        GameObject _newSlot = Instantiate(_slotPrefab);
        _newSlot.transform.SetParent(transform, false);

        InventorySlot _newSlotComponent = _newSlot.GetComponent<InventorySlot>();
        _newSlotComponent.ClearSlot();

        _inventorySlots.Add(_newSlotComponent);
    }
}
