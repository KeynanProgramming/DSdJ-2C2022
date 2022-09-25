using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField] private Collider triggerCollider;

    private int _damage;

    private void Awake()
    {
        triggerCollider = GetComponent<Collider>();
    }

    public void TurnCollisionOn()
    {
        triggerCollider.enabled = true;
    }

    public void TurnCollisionOff()
    {
        triggerCollider.enabled = false;
    }

    public void SetDamage(int amount)
    {
        _damage = amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        var hp = other.gameObject.GetComponent<Health>();
        if (hp == null) return;
        hp.TakeDamage(_damage);
        TurnCollisionOff();
    }
}