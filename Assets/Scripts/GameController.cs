using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //private Rigidbody2D _rigidbody2D;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Transform _playerTransform;
    private PlayerInputActions _playerInputActions;
    [SerializeField] private float _translateSpeed;
    private GameObject _player;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _gameManager;

    private Vector3 _unflippedScale = new Vector3(1, 1, 1);
    private Vector3 _flippedScale = new Vector3(1, -1, 1);

    private void Awake()
    {
        //_rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _playerTransform = GetComponent<Transform>();

        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();

        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        Vector2 _inputVector = _playerInputActions.Player.Movement.ReadValue<Vector2>(); //Debug.Log(_inputVector);
        _playerTransform.Translate(_inputVector * Time.deltaTime * _translateSpeed);
        
        
        if (_playerInputActions.Player.Fire.IsPressed())
        {
            _player.GetComponentInChildren<Gun>().Fire(); 
        }

        if (_inputVector != Vector2.zero)
            _animator.SetBool("IsPlayerMoving", true);
        else
            _animator.SetBool("IsPlayerMoving", false);

        //if (_playerInputActions.UI.Pause.IsPressed())
    }
}
