using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice : MonoBehaviour, ICollectible {
    public static event HandleJuiceCollected OnJuiceCollected;
    public delegate void HandleJuiceCollected(ItemData _itemData);
    [SerializeField] private ItemData _juiceData;

    public void Collect() {
        Debug.Log("Juice collected");
        Destroy(gameObject);
        OnJuiceCollected?.Invoke(_juiceData);
    }
}
