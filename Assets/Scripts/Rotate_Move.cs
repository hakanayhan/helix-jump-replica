using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Move : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    private float _moveX;
    void Update()
    {
        _moveX = Input.GetAxis("Mouse X");

        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0f, _moveX * _rotateSpeed * Time.deltaTime, 0f);
        }
    }
}
