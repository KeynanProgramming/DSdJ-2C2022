using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifespan = 3f;

    public int Damage { get; private set; }
    public int Pierce { get; private set; }
    public float KnockBack { get; private set; }

    public void StatSetup(int damage, int pierce, float knockBack)
    {
        Damage = damage;
        Pierce = pierce;
        KnockBack = knockBack;
    }

    private void Start()
    {
        Destroy(gameObject,lifespan);
    }

    private void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Health>())
        {
            var go = other.gameObject.GetComponent<Health>();
            go.TakeDamage(Damage);
            Pierce--;
            if (Pierce <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
