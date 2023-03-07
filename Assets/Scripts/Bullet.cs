using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _mousePos;
    private Camera _mainCam;
    private Rigidbody2D _rb;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float life;
    // [SerializeField] private int _damageToEnemy;

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
        //transform.rotation = Quaternion.Euler(0, 0, _rot + 90);
        transform.rotation = Quaternion.Euler(0, 0, _angle + 90 + 45); // ¡Ÿ ±∑Ω∞∏
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            Destroy(other.gameObject);
        } else if (other.gameObject.CompareTag("EnemyWithGun"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            Destroy(other.gameObject);
            GameObject.FindObjectOfType<EnemiesSpawner>().GetComponent<EnemiesSpawner>()._amount--;
        } else if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }
}
