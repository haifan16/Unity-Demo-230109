using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    private Camera _mainCam;
    private Vector3 _mousePos;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawnPoint;

    [SerializeField] bool _canFire;
    private float _timer;
    [SerializeField] private float _timeBetweenFiring;

    [SerializeField] private GameObject _player;
    private Vector3 _gunDir;
    private Vector3 _unflippedScale = new Vector3(1, 1, 1);
    private Vector3 _flippedScale = new Vector3(1, -1, 1);

    [SerializeField] private GameObject _audioManager;

    private void Start()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    
    private void Update()
    {
        //_mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition); // old way
        _mousePos = _mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector3 _gunDir = _mousePos - transform.position;
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
    }

    private void FixedUpdate()
    {
        // PlayerÑØxÖá·­×ª
        if (_mousePos.x < _player.transform.position.x)
            transform.localScale = _flippedScale;
        else
            transform.localScale = _unflippedScale;
    }

    public void Fire()
    {
        //if (_canFire && Input.GetMouseButton(0))
        if (_canFire)
        {
            Instantiate(_bullet, _bulletSpawnPoint.position, Quaternion.identity);
            _audioManager.GetComponent<AudioManager>().Play("FireSound");
            _canFire = false;
        }
    }
}
