using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWithGun : MonoBehaviour
{
    private Vector3 _playerPos;
    Vector3 _dir;
    [SerializeField] private int _translateSpeed;
    [SerializeField] private float _damageRate;
    [SerializeField] private int _damageToPlayer;
    private GameObject _player;

    //private bool _canDamage;
    //private float _timer;

    private void Update()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        _dir = (_playerPos - transform.position).normalized;
        Debug.DrawRay(transform.position, _dir, Color.black);
    }

    private void FixedUpdate()
    {
        transform.Translate(_dir * Time.deltaTime * _translateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _player = other.gameObject;
            InvokeRepeating("Damage", 0, _damageRate);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CancelInvoke("Damage");
    }

    private void Damage()
    {
        _player.GetComponent<PlayerHealth>().Damage(_damageToPlayer);
    }

}
