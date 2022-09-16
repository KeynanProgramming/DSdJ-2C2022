using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takedamagetest : MonoBehaviour
{
    private Health _health;
    private Rigidbody _rb;
    [SerializeField] private float force;


    private void Awake()
    {
        _health = GetComponent<Health>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _health.OnConsumed += () => print(_health.CurrentHealth);
        _health.OnDeath += () => Destroy(gameObject);
    }
}
