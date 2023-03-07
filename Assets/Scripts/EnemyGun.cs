using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyGun : MonoBehaviour
{
    private GameObject _player;
    private Vector3 _playerPos;
    [SerializeField] private GameObject _enemyBullet;
    [SerializeField] private Transform _bulletSpawnPoint;

    [SerializeField] bool _canFire;
    private float _timer;
    [SerializeField] private float _timeBetweenFiring;

    [SerializeField] private GameObject _EnemyWithGun;
    private Vector3 _gunDir;
    private Vector3 _unflippedScale = new Vector3(1, 1, 1);
    private Vector3 _flippedScale = new Vector3(1, -1, 1);

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        _playerPos = _player.GetComponent<Transform>().position;

        Vector3 _gunDir = _playerPos - transform.position;
        float rotZ = Mathf.Atan2(_gunDir.y, _gunDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, rotZ);

        if (!_canFire)
        {
            _timer += Time.deltaTime;
            if (_timer > _timeBetweenFiring)
            {
                _canFire = true;
                _timer = 0;
            }
        }

        Fire();
    }

    private void FixedUpdate()
    {
        // PlayerÑØxÖá·­×ª
        if (_playerPos.x < _EnemyWithGun.transform.position.x)
            transform.localScale = _flippedScale;
        else
            transform.localScale = _unflippedScale;
    }

    public void Fire()
    {
        if (_canFire)
        {
            Instantiate(_enemyBullet, _bulletSpawnPoint.position, Quaternion.identity);
            _canFire = false;
        }
    }
}
