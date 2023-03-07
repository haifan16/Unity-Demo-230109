using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chips : MonoBehaviour, ICollectible {
    public static event HandleChipsCollected OnChipsCollected;
    public delegate void HandleChipsCollected(ItemData _itemData);
    [SerializeField] private ItemData _chipsData;

    public void Collect() {
        Debug.Log("Chips collected");
        Destroy(gameObject);
        OnChipsCollected?.Invoke(_chipsData);
    }
}