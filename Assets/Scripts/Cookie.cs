using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour, ICollectible {
    public static event HandleCookieCollected OnCookieCollected;
    public delegate void HandleCookieCollected(ItemData _itemData);
    [SerializeField] private ItemData _cookieData;

    public void Collect() {
        Debug.Log("Cookie collected");
        Destroy(gameObject);
        OnCookieCollected?.Invoke(_cookieData);
    }
}
