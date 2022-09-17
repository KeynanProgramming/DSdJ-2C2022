using UnityEngine;

public class takedamagetest : MonoBehaviour
{
    private Health _health;
    
    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        _health.OnConsumed += () => print(_health.CurrentHealth);
        _health.OnDeath += () => Destroy(gameObject);
    }
}
