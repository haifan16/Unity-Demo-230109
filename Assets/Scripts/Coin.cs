using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    public static event HandleCoinCollected OnCoinCollected;
    public delegate void HandleCoinCollected(ItemData _itemData);
    [SerializeField] private ItemData _coinData;

    public void Collect() {
        Debug.Log("Coin collected");
        Destroy(gameObject);
        OnCoinCollected?.Invoke(_coinData);
    }
}