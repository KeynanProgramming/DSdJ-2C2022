using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takedamagetest : MonoBehaviour
{
    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
        _health.OnConsumed += () => print(_health.CurrentHealth);
        _health.OnDeath += () => Destroy(gameObject);
    }
}
