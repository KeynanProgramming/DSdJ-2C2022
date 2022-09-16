using System;
using JetBrains.Annotations;
using UnityEngine;

public class CharacterM : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Camera cameraObject;
    [SerializeField] private LayerMask mouseColliderLayerMask;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectilePrefab;
    
    private Rigidbody _rb;
    public CharacterStats Stats { get; private set; }

    public Vector3 GetMouseWorldPosition()
    {
        Ray ray = cameraObject.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out RaycastHit raycastHit, 100f, mouseColliderLayerMask) ? raycastHit.point : Vector3.zero;
    }
    
    public bool IsInInteractRange
    {
        get => _isInInteractRange;
        set
        {
            _isInInteractRange = value;
            OnCharacterInteractRange?.Invoke(Interactable != null ? Interactable.InteractionType : InteractionType.None);
        } 
    }
    [CanBeNull] public Interactable Interactable { get; set; }
    private bool _isInInteractRange;
    public event Action OnCharacterInteract;
    public event Action<InteractionType> OnCharacterInteractRange;
    private void CharacterInteraction()
    {
        if (!(Interactable is null)) Interactable.Interaction();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsInInteractRange)
        {
            OnCharacterInteract?.Invoke();
            CharacterInteraction();
        }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        Stats = GetComponent<CharacterStats>();
    }
    
    public void Move(Vector3 dir)
    {
        var value = Vector3.ClampMagnitude(dir, 1);
        _rb.velocity = new Vector3(value.x * speed,0, value.z * speed);
    }

    public void Shoot()
    {
        switch (Stats.TotalSimultaneousArrows)
        {
            case 1:
                ProjectileSpawn(0f);
                break;
            case 2:
                ProjectileSpawn(-15f);
                ProjectileSpawn(15f);
                break;
            case 3:
                ProjectileSpawn(-15f);
                ProjectileSpawn(0f);
                ProjectileSpawn(15f);
                break;
            case 4:
                ProjectileSpawn(-45f);
                ProjectileSpawn(-15f);
                ProjectileSpawn(15f);
                ProjectileSpawn(45f);
                break;
            case 5:
                ProjectileSpawn(-45f);
                ProjectileSpawn(-15f); 
                ProjectileSpawn(0f);
                ProjectileSpawn(15f);
                ProjectileSpawn(45f);
                break;
        }
    }

    private void ProjectileSpawn(float angle)
    {
        var go = Instantiate(projectilePrefab,firePoint.position,Quaternion.identity);
        var projectile = go.GetComponent<Projectile>();
        projectile.StatSetup(Stats.TotalAttackDamage,Stats.TotalAttackPierce,Stats.TotalAttackKnockBack);
        projectile.transform.forward = Quaternion.Euler(0f,angle,0f) * transform.forward;
    }
}
