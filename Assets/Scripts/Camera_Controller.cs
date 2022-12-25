using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    [SerializeField] private float _smoothSpeed;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - _ball.position;
    }

    void FixedUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, offset + _ball.position, _smoothSpeed);
        transform.position = newPos;
    }
}
