using System.Collections;
using System.Collections.Generic;
using EventSystem;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdScript : MonoBehaviour
{
    [SerializeField] private float riseStrength;
    
    private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.simulated = false;

        EventsInstance.Events.StartGame += OnStart;
        EventsInstance.Events.OnTap += Rise;
    }

    private void OnStart()
    {
        _rigidbody2D.simulated = true;
    }

    private void Rise()
    {
        _rigidbody2D.totalForce = (riseStrength * Vector2.up);
    }
}
