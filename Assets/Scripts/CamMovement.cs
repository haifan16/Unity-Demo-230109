using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] Vector3 _offset;
    [SerializeField] float _speed;
    private Vector3 _desirePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        _desirePos = _playerTransform.position + _offset;
        transform.position = Vector3.Lerp(transform.position, _desirePos, _speed * Time.deltaTime);
    }
}
