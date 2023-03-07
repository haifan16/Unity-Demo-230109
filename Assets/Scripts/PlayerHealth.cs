using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float _health;
    [SerializeField] float _maxHealth;
    [SerializeField] Image _topHealthBar;

    private void Start()
    {
        _maxHealth = _health;
    }
    
    private void Update()
    {
        if (_health > _maxHealth) _health = _maxHealth;
        _topHealthBar.fillAmount = Mathf.Clamp(_health / _maxHealth, 0, 1);
    }
    public void Damage(int _damage)
    {
        _health -= _damage;
        FindObjectOfType<AudioManager>().Play("PlayerDamageSound");
    }
}
