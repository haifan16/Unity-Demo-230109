using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _maxAmount;
    public int _amount;
    [SerializeField] private bool _canSpawn;
    private float _timer = 0;
    [SerializeField] private float _spawnRate;
    private Vector3 _spawnPos;
    [SerializeField] private float _minX, _maxX, _minY, _maxY;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _minDistance;

    private void Awake() {
        _spawnRate = 0.5f;
        _minX = -22.5f;
        _maxX = 22.5f;
        _minY = -16.5f;
        _maxY = 16.5f;
        _minDistance = 5f;
    }

    private void Update() {
        if (!_canSpawn) {
            _timer += Time.deltaTime;
            if (_timer > _spawnRate) {
                _canSpawn = true;
                _timer = 0;
            }
        }
    }

    private void FixedUpdate() {
        do {
            _spawnPos = new Vector3(UnityEngine.Random.Range(_minX, _maxX), UnityEngine.Random.Range(_minY, _maxY), 0);
        } while (Mathf.Pow((_spawnPos.x - _playerTransform.position.x), 2) + Mathf.Pow((_spawnPos.y - _playerTransform.position.y), 2) < _minDistance);

        if (_canSpawn && _amount <= _maxAmount) {
            Instantiate(_prefab, _spawnPos, Quaternion.identity, transform);
            _canSpawn = false;
            _amount++;
        }
    }
}
