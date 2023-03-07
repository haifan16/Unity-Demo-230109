using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image _icon;
    public TextMeshProUGUI _labelText;
    public TextMeshProUGUI _stackSizeText;

    public void ClearSlot() {
        _icon.enabled = false;
        _labelText.enabled = false;
        _stackSizeText.enabled = false;
    }

    public void DrawSlot(InventoryItem _item) {
        if (_item == null) {
            ClearSlot();
            return;
        }

        _icon.enabled = true;
        _labelText.enabled = true;
        _stackSizeText.enabled = true;

        _icon.sprite = _item._itemData._icon;
        _labelText.text = _item._itemData._displayName;
        _stackSizeText.text = _item._stackSize.ToString();
    }
}
