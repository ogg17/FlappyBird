using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlyAnimationBirdScript : MonoBehaviour
{
    [SerializeField] private float fallValue;
    
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;

    private Vector3 _fall;
    private Vector3 _rise;
    private void Start()
    {
        _transform = transform;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        //_rigidbody2D.simulated = false;

        _fall = new Vector3(fallValue, -1, 0);
        _rise = new Vector3(fallValue, 1, 0);
    }

    private void Update()
    {
        switch (_rigidbody2D.velocity.y)
        {
            case > 0:
                _transform.right = _rise;
                break;
            case < 0:
                _transform.right = _fall;
                break;
            default:
                _transform.right = Vector3.right;
                break;
        }
    }
}
