using UnityEngine;

namespace Traps
{
    public class PressurePlateTrap : MonoBehaviour
    {
        [Header("Stats")] [Space(5)] [SerializeField]
        private float shootDelay = 1;

        [SerializeField] private int projectileDamage = 1;
        [SerializeField] private int projectilePierce = 1;
        [SerializeField] private float projectileKnockBack = 1;

        [Header("References")] [Space(5)] [SerializeField]
        private Transform shootingPoint;

        [SerializeField] private Projectile projectilePrefab;

        private float _currShootDelay;
        private bool _countdown;

        private void Start()
        {
            ResetTimer();
        }

        private void Update()
        {
            ShootTimer();
        }

        private void ShootTimer()
        {
            if (!_countdown) return;
            if (_currShootDelay > 0) _currShootDelay -= Time.deltaTime;
            if (_currShootDelay <= 0) ShootProjectile();
        }

        private void ShootProjectile()
        {
            var go = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);
            go.StatSetup(projectileDamage, projectilePierce, projectileKnockBack);
            go.transform.forward = transform.forward;
            ResetTimer();
        }

        private void ResetTimer()
        {
            _countdown = false;
            _currShootDelay = shootDelay;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_countdown) _countdown = true;
        }

        private void OnTriggerStay(Collider other)
        {
            if (!_countdown) _countdown = true;
        }
    }
}