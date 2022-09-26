using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float lifespan = 2f;
    [SerializeField] private Collider sphereSolid;

    public int Damage { get; private set; }
    public int Pierce { get; private set; }
    public float KnockBack { get; private set; }

    public void StatSetup(int damage, int pierce, float knockBack, float speed = 0, float life = 0)
    {
        Damage = damage;
        Pierce = pierce;
        KnockBack = knockBack;
        if (speed != 0) moveSpeed = speed;
        if (life != 0) lifespan = life;
    }

    private void Start()
    {
        Destroy(gameObject, lifespan);
    }

    private void Update()
    {
        var t = transform;
        t.position += t.forward * (moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Health>())
        {
            var go = other.gameObject.GetComponent<Health>();
            go.TakeDamage(Damage);
            Pierce--;
            if (Pierce <= 0) Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy")) return;
        var contact = collision.contacts[0];
        var contactPos = contact.point;
        var projectileDir = (collision.gameObject.transform.position - contactPos).normalized;
        projectileDir *= KnockBack * 10000;
        collision.gameObject.GetComponent<Rigidbody>().AddForce(projectileDir, ForceMode.Force);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("CanPierce"))
            sphereSolid.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("CanPierce"))
            sphereSolid.enabled = true;
    }
}