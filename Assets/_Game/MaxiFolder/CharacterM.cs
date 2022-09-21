using UnityEngine;

public class CharacterM : MonoBehaviour
{
    [SerializeField] private Camera cameraObject;
    [SerializeField] private LayerMask mouseColliderLayerMask;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectilePrefab;

    private Rigidbody _rb;
    public CharacterStats Stats { get; private set; }
    public Health Health { get; private set; }

    public Vector3 GetMouseWorldPosition()
    {
        var ray = cameraObject.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out var raycastHit, 100f, mouseColliderLayerMask) ? raycastHit.point : Vector3.zero;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        Stats = GetComponent<CharacterStats>();
        Health = GetComponent<Health>();
    }

    private void Start()
    {
        Health.SetStartingMaxHealth(Stats.MaxHealth);
    }

    public void Move(Vector3 dir)
    {
        var value = Vector3.ClampMagnitude(dir, 1);
        _rb.velocity = new Vector3(value.x * Stats.TotalMoveSpeed, 0, value.z * Stats.TotalMoveSpeed);
    }

    public void Shoot()
    {
        switch (Stats.TotalSimultaneousArrows)
        {
            case 1:
                ProjectileSpawn(0f);
                break;
            case 2:
                ProjectileSpawn(-10f);
                ProjectileSpawn(10f);
                break;
            case 3:
                ProjectileSpawn(-10f);
                ProjectileSpawn(0f);
                ProjectileSpawn(10f);
                break;
            case 4:
                ProjectileSpawn(-20f);
                ProjectileSpawn(-10f);
                ProjectileSpawn(10f);
                ProjectileSpawn(20f);
                break;
            case 5:
                ProjectileSpawn(-20f);
                ProjectileSpawn(-10f);
                ProjectileSpawn(0f);
                ProjectileSpawn(10f);
                ProjectileSpawn(20f);
                break;
            default:
                ProjectileSpawn(0f);
                break;
        }
    }

    private void ProjectileSpawn(float angle)
    {
        var go = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        var projectile = go.GetComponent<Projectile>();
        projectile.StatSetup(Stats.TotalAttackDamage, Stats.TotalAttackPierce, Stats.TotalAttackKnockBack);
        projectile.transform.forward = Quaternion.Euler(0f, angle, 0f) * transform.forward;
    }

    public void CharacterInteraction(Interactable interactable)
    {
        interactable.Interaction();
    }
}