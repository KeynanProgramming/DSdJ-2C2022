using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifespan = 3f;
    [SerializeField] private Collider sphereSolid;

    private Rigidbody _rb;

    public int Damage { get; private set; }
    public int Pierce { get; private set; }
    public float KnockBack { get; private set; }

    public void StatSetup(int damage, int pierce, float knockBack)
    {
        Damage = damage;
        Pierce = pierce;
        KnockBack = knockBack;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
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
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy")) return;
        var contact = collision.contacts[0];
        var contactPos = contact.point;
        var projectileDir = (collision.gameObject.transform.position - contactPos).normalized;
        projectileDir *= (KnockBack * 10000);
        collision.gameObject.GetComponent<Rigidbody>().AddForce(projectileDir,ForceMode.Force);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            sphereSolid.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            sphereSolid.enabled = true;
        }
    }
}
