using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 _mousePos;
    private Camera _mainCam;
    private Rigidbody2D _rb;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float life;
    private GameObject _player;
    [SerializeField] private int _damageToPlayer;

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void Start()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _rb = GetComponent<Rigidbody2D>();
        _mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 _direction = _mousePos - transform.position;
        Vector3 _rotation = transform.position - _mousePos;
        _rb.velocity = new Vector2(_direction.x, _direction.y).normalized * _bulletSpeed;
        float _angle = Mathf.Atan2(_rotation.y, _rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _angle + 90 + 90);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _player = other.gameObject;
            _player.GetComponent<PlayerHealth>().Damage(_damageToPlayer);
        } else if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
