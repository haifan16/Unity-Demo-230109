using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        ICollectible _collectible = collision.gameObject.GetComponent<ICollectible>();
        if (_collectible != null) {
            _collectible.Collect();
        }
    }
}
