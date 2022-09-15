using UnityEngine;

public class CharacterM : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Camera cameraObject;
    [SerializeField] private LayerMask mouseColliderLayerMask;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectilePrefab;
    
    private Rigidbody _rb;
    private CharacterStats _characterStats;

    public Vector3 GetMouseWorldPosition()
    {
        Ray ray = cameraObject.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out RaycastHit raycastHit, 100f, mouseColliderLayerMask) ? raycastHit.point : Vector3.zero;
    }
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _characterStats = GetComponent<CharacterStats>();
    }
    
    public void Move(Vector3 dir)
    {
        var value = Vector3.ClampMagnitude(dir, 1);
        _rb.velocity = new Vector3(value.x * speed,0, value.z * speed);
    }

    public void Shoot()
    {
        ProjectileSpawn(0f);
    }

    private void ProjectileSpawn(float angle)
    {
        var go = Instantiate(projectilePrefab,firePoint.position,Quaternion.identity);
        var projectile = go.GetComponent<Projectile>();
        projectile.StatSetup(_characterStats.TotalAttackDamage,_characterStats.TotalAttackPierce,_characterStats.TotalAttackKnockBack);
        projectile.transform.forward = Quaternion.Euler(0f,angle,0f) * transform.forward;
    }
}
